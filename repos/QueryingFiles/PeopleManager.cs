using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryingFiles
{
    public class PeopleManager
    {
        private Collection<Person> People;

        public PeopleManager()
        {
            People = new Collection<Person> { };
        }

        public Collection<Person> GetPeople()
        {
            if (People is null)
            {
                People = new Collection<Person> { };
            }
            return People;
        }

        public void AddPerson(Person p)
        {
            if (!People.Contains(p))
                People.Add(p);
        }

        public void RemovePerson (Person p)
        {
            if (!People.Contains(p))
                People.Remove(p);
        }


    }
}

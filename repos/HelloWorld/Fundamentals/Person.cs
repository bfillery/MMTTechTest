using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Fundamentals
{
    public class Person
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public DateTime Birthdate { get; private set; }


        public Person(DateTime birthDate)
        {
            Birthdate = birthDate;
        }



        public int Age
        {
            get 
            {
                var timeSpan = DateTime.Today - Birthdate;
                var years = timeSpan.Days / 365;

                return years;
             }
        }
    }
}

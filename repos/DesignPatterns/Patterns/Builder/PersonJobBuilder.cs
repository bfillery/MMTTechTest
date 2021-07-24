using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Patterns.Builder
{

    //new requirement and, following open-closed principle, rather than
    //editing the PersonInfoBuilder class, you inherit from it...
    public class PersonJobBuilder <SELF>
        : PersonInfoBuilder<PersonJobBuilder<SELF>>
        where SELF : PersonJobBuilder<SELF>
    {
        public SELF WorksAsA (string position)
        {
            person.Position = position;
            return (SELF)this;
        }
    }
}

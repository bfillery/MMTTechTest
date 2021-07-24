using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Patterns.Builder
{
    public class PersonInfoBuilder<SELF> 
        : PersonBuilder
        where SELF : PersonInfoBuilder<SELF>
    {

        //protected not private as we're using inheritance...

        protected Person person = new Person();

        public SELF Called(string name)
        {
            person.Name = name;

            //fluent builder - return object refernce to 
            //the object you're working with, so the caller 
            //can 'chain' method calls, as with e.g. StringBuilder.Add.Add.Add...

            //safe to cast to same type as self, due to the contraint on the constructor. Apparently.
            return (SELF)this; 
        }
    }
}

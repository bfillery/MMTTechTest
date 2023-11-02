using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryingFiles
{
    public class AgeSpecification : ISpecification<Person>
    {

        private int MinAge;
        private int MaxAge;

        public AgeSpecification(int minAge, int maxAge)
        {
            this.MinAge = minAge;
            this.MaxAge = maxAge;
        }

        public bool IsSatisfied(Person p)
        {
            return p.Age >=this.MinAge &&  p.Age<=this.MaxAge ;
        }
    }
}

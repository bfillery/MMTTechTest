using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryingFiles
{
    public class PeopleFilter :IFilter<Person>
    {

        public IEnumerable<Person> Filter(IEnumerable<Person> items, ISpecification<Person> spec)
        {
            foreach (var i in items)
            {
                if (spec.IsSatisfied(i))
                    yield return i;
            }
        }
    }
}

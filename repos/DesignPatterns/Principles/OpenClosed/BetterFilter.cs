using DesignPatterns.Principles.OpenClosed.Interfaces;
using System.Collections.Generic;

namespace DesignPatterns.Principles.OpenClosed
{
    public class BetterFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
        {
            foreach(var i in items) 
            {
                if (spec.IsSatisfied(i))
                    yield return i;
            }
        }
    }
}

using System.Collections.Generic;

namespace DesignPatterns.Principles.OpenClosed.Interfaces
{
    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
    }
}

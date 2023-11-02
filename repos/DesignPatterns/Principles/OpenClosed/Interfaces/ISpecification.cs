namespace DesignPatterns.Principles.OpenClosed.Interfaces
{
    public interface ISpecification<T>
    {
        bool IsSatisfied(T t);
    }
}

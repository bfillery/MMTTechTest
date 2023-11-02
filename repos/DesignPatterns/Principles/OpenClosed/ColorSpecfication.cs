using DesignPatterns.Principles.OpenClosed.Interfaces;
using static DesignPatterns.Principles.OpenClosed.Enums;

namespace DesignPatterns.Principles.OpenClosed
{
    public class ColorSpecfication : ISpecification<Product>
    {
        private readonly Color color;

        public ColorSpecfication(Color color)
        {
            this.color = color;
        }


        public bool IsSatisfied(Product t)
        {
            return this.color == t.color;
        }
    }
}

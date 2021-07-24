using System;
using static DesignPatterns.Principles.OpenClosed.Enums;

namespace DesignPatterns.Principles.OpenClosed
{
    public class Product
    {
        //public fields like this is BAAAD
        public string Name;

        public Color color;
        public Size size;

        public Product(string name, Color color, Size size)
        {
            if(name== null)
            {
                throw new ArgumentNullException(paramName: nameof(name));
            }
            this.Name = name;
            this.color = color;
            this.size = size;
        }


    }
}

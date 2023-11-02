namespace DesignPatterns.Principles.Liskov
{
    public class Rectangle
    {
        //virtual means you CAN (not HAVE TO) override
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }

        public Rectangle()
        {

        }

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }
        public override string ToString()
        {
            return $"{nameof(Width)}: {Width}, {nameof(Height)}: {Height}";
        }

        public class Square : Rectangle
        {
            //public new int Width
            //if we use the "new" keyword here, so the inheriting class field replaces thebase class
            //we violate Liskov - try and say a Rectangle is a square and the area calculation fails
            //BUT if you make the base class field virtual, and override it in the inheriting class, 
            //the code you write in the inheriting class is what gets called
            public override int Width
            {
                set
                {
                    base.Width = base.Height = value;
                }
            }

            public override int Height
            {
                set
                {
                    base.Width = base.Height = value;
                }
            }
        }
    }
}

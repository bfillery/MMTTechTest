using System;
using static DesignPatterns.Principles.Liskov.Rectangle;



//you should be able to substitute a base type for a subtype - e.g. swap out string and in Object
namespace DesignPatterns.Principles.Liskov
{
    public class LiskovSubstitution
    {
        public LiskovSubstitution()
        {

            static int Area(Rectangle r) => r.Width * r.Height;

            Rectangle rc = new Rectangle(2,3);

            //Square sq = new Square();
            Rectangle sq = new Square(); //this works because we made hieght and width virtual in base class (rectange) nd overrode them in Square
            sq.Width = 4;
            Console.WriteLine($"{sq} has area {Area(sq)}");
            Console.WriteLine($"{rc} has area {Area(rc)}");
        }
    }
}

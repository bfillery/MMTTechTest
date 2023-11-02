using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Fundamentals
{
    public class Orientation
    {
        public static bool IsPortrait (int Height, int Width)
        {
            return Height >= Width;
        }
    }
}

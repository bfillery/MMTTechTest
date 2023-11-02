using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Fundamentals
{
    public static class Demerits
    {



        public static int CalculateDemerits(int CarSpeed, int SpeedLimit)
        {
            if (CarSpeed <= SpeedLimit || CarSpeed <=0) return 0;

            return (int)Math.Abs(SpeedLimit - CarSpeed) / 5;
        }

    }
}

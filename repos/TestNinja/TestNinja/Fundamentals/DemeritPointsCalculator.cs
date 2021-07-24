using System;

namespace TestNinja.Fundamentals
{


    public class DemeritPointsCalculator
    {
        private const int SpeedLimit = 65;
        private const int MaxSpeed = 300;
        private const int kmPerDemeritPoint = 5;


        public static int GetMaxSpeed()
        {
            return MaxSpeed;
        }

        public static int GetSpeedLimit()
        {
            return SpeedLimit;
        }

        public static int GetKmPerDemeritPoint()
        {
            return kmPerDemeritPoint;

        }


        public int CalculateDemeritPoints(int speed)
        {
            if (speed < 0 || speed > MaxSpeed) 
                throw new ArgumentOutOfRangeException();
            
            if (speed <= SpeedLimit || (speed - SpeedLimit) <= 0) return 0; 
            

            var demeritPoints = (speed - SpeedLimit)/kmPerDemeritPoint;

            return demeritPoints;
        }        
    }
}
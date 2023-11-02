using System;
using Gately.Repository;


namespace Gately.Console
{


    class Program
    {
        static void Main()
        {



            string MyGate = "1";
            string MyAirport = "Gatwick";

            var Gate = new Gate(MyAirport, MyGate);




       
            //Gate.Latitude = result["Latitude"];
            //Gate.Longitude = result["Longitude"];

            //Console.WriteLine(MyGate.ToString());
            


            //https://docs.microsoft.com/en-us/dotnet/api/system.device.location.geocoordinate.latitude?view=netframework-4.8

            //GeoCoordinateWatcher watcher;
            //watcher = new GeoCoordinateWatcher();
            //// Begin listening for location updates.

            //watcher.Start();
            //var start = watcher.Position;
            //Console.WriteLine("Lat: {0}, Long: {1}", start.Location.Latitude, start.Location.Longitude);

            

            //watcher.PositionChanged += (sender, e) =>
            //{
            //    var coordinate = e.Position.Location;
            //    Console.WriteLine("Lat: {0}, Long: {1}", coordinate.Latitude,
            //        coordinate.Longitude);
            //    // Uncomment to get only one event.
            //    // watcher.Stop();
            //};

 



        }


    }
}

using Gately.Domain;
using System;
using System.Data;

using System.Device.Location;
using System.Linq;

namespace Gately.Repository
{
    public class Gate
    {
        private string GateID { get; set; }
        private string Airport { get; set; }
        private double Latitude { get; set; }
        private double Longitude { get; set; }

        // The coordinate watcher.
        private GeoCoordinateWatcher Watcher = null;

        public override string ToString()
        {
            return String.Format("Airport: {0} Gate: {1} \n\t Latitude: {2}, Longitude: {3}",
                     this.Airport,
                     this.GateID,
                     this.Latitude.ToString(),
                     this.Longitude.ToString());
        }

        public Gate(string MyAirport, string MyGateID)
        {
            this.GateID = MyGateID;
            this.Airport = MyAirport;

            // Create the watcher.
            Watcher = new GeoCoordinateWatcher();

            // Catch the StatusChanged event.
            Watcher.StatusChanged += Watcher_StatusChanged;
            // Start the watcher.

            Watcher.Start();
        }
        private void GetGateLocation()
        {
            var fl = new FileDataSource(AppDomain.CurrentDomain.BaseDirectory, "Gates.csv");

            DataTable dt = fl.GetDatatable();

            //https://stackoverflow.com/questions/10855/linq-query-on-a-datatable

            var result = dt;             //using System.Data.DataSetExtensions;??

            //.AsEnumerable()
            //.Where(myRow => myRow.Field<string>("Airport") == this.Airport)
            //.Where(myRow => myRow.Field<string>("Gate") == this.GateID)
            //.FirstOrDefault();
        }
        // The watcher’s status has change. See if it is ready.
        private void Watcher_StatusChanged(object sender, GeoPositionStatusChangedEventArgs e)
        {
            if (e.Status == GeoPositionStatus.Ready)
            {
                // Display the latitude and longitude.
                if (Watcher.Position.Location.IsUnknown)
                {
                    throw new ArgumentException("Cannot find location data");
                }
                else
                {
                    this.Latitude = Watcher.Position.Location.Latitude;
                    this.Longitude = Watcher.Position.Location.Longitude;
                }
            }
        }
    }

}


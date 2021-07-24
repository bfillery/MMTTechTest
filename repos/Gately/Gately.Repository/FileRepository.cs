using Gately.Repository.Interfaces;
using System;

namespace Gately.Repository
{
    public class FileRepository : IRepository
    {
        public string GateToCheck { get; set; }

        public string AirportToCheck { get; set; }

        public bool? IsGateListedAtAirport(string GateToTest, string Airport)
        {
            throw new NotImplementedException();
        }




    }
}

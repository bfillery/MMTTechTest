using System;
using System.Collections.Generic;
using System.Text;

namespace Gately.Repository.Interfaces
{
    interface IRepository
    {
        bool? IsGateListedAtAirport(string GateToTest, string Airport);

    }
}

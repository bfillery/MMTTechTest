using Gately.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gately.Domain.Interfaces
{
    interface IDataSource
    {
        public DataTable GetDatatable();

        public SourceName Source { get; set; }

    }
}

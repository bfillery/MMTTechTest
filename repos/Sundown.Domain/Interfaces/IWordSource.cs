using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundown.Domain.Interfaces
{
    public interface IWordSource
    {

        SourceName sourceName { get; set; }
        string SourceConnection { get; set; }
    }
}

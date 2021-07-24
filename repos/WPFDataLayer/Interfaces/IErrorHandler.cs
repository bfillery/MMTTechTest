using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFDataLayer.Interfaces
{
    public interface IErrorHandler
    {
        void RecordError(object Sender, string Message);
    }
}

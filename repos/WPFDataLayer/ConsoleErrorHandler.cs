using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFDataLayer.Interfaces;

namespace WPFDataLayer
{
    public class ConsoleErrorHandler : IErrorHandler
    {
        public void RecordError(object Sender, string Message)
        {
            Console.WriteLine($"Oh, no: {Message}");
        }
    }
}

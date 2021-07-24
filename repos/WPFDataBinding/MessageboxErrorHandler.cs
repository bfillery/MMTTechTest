using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFDataLayer.Interfaces;

namespace WPFDataBinding
{
    public class MessageboxErrorHandler : IErrorHandler
    {
        public void RecordError(object Sender, string Message)
        {
            MessageBox.Show($"Oh, no: {Message}");
        }
    }
}

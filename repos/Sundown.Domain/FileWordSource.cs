using Sundown.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundown.Domain
{
    public class FileWordSource : IWordSource
    {
        public SourceName sourceName { get; set; }
        public string SourceConnection { get;set; }
        public FileWordSource(string fileName)
        {
            sourceName = SourceName.CsvFile;
            SourceConnection = fileName;
        }
    }
}

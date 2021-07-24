using Sundown.Domain.Interfaces;

namespace Sundown.Domain
{
    public class DBWordSource : IWordSource
    {
        public SourceName sourceName { get; set; }
        public string SourceConnection { get; set; }
        public DBWordSource (string ConnString)
        {
            sourceName = SourceName.DB;
            SourceConnection = ConnString;
        }
    }
}

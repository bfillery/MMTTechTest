using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundown.Repository.Interfaces
{
    public interface IRepository
    {
        bool? IsWordInDictionary(string WordToTest);
    }
}

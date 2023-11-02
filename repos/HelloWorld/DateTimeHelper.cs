using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    public class DateTimeHelper
    {
        public static bool IsValidTime(string entry)
        {
            return DateTime.TryParseExact(
                entry,
                "HH:mm", 
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime time);
        }
    }
}

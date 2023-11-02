using System;
using System.Linq;

namespace System
{

    //note naming convention - #{class we're extending}Exensions
    //note too that even though class and method static, it's an instance thing
    //Finally, define in System namespace to avoid lot of namespaces
    public static class StringExtensions
    {
        public static string Shorten(this String str, int numberOfWords)
        {
            if (numberOfWords < 0)
                throw new ArgumentOutOfRangeException("numberOfWords should be greater than or equal to 0.");

            if (numberOfWords == 0)
                return "";

            var words = str.Split(' ');

            if (words.Length <= numberOfWords)
                return str;

            return string.Join(" ", words.Take(numberOfWords)) + "...";
        }
    }
}
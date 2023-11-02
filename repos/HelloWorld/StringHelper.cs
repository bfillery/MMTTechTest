using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace HelloWorld
{
    public class StringHelper
    {
        public static string ReverseString (string text)
        {
            char[] textArray = text.ToCharArray();

            Array.Reverse(textArray);
                
            return new string(textArray);
        }


        public static bool IsConsecutive(string entries, char separator)
        {

            bool increasingList = false;


            //is it an empty string?
            if (string.IsNullOrWhiteSpace(entries))
                return false;

            //are there *any* separators? If not, hardly a consecutive list
            if (entries.Count(f => f == separator) == 0)
                return false;
            

            var members = entries.Split(separator);
            int member = 0;

            //are all members a parsable integer?
            for (int i = 0; i < members.Count()-1; i++)
            {
                if (!int.TryParse(members[i], out member))
                    return false;
            }

            //first two items are the same?
            if (members[0] == members[1])
                return false;

            //convert string array to int array
            int[] theNumbers = Array.ConvertAll(members, int.Parse);

            //is it going up or down?
            increasingList = theNumbers[0] < theNumbers[1];

        
            for (int i = 1; i < members.Length - 1; i++)
            {
                int current = theNumbers[i];
                int next = theNumbers[i + 1];

                if (
                    ( increasingList && next != (current + 1))
                    ||
                    (! increasingList && next  != (current - 1))
                   )
                    return false;
            }
            
            return true;
            
        }

        public static bool CheckForDuplicates(string entries, char separator)
        {
            string[] members = entries.Split(separator);

            if (members.Distinct().Count() != members.Count())
                return true;

            return false;
        }


        //public static string PascalCase(string entries, char separator)
        //{

        //    entries.ToLower();

        //    var members = entries.Split(separator);
        //    StringBuilder result = new StringBuilder();

        //    for(int i = 0; i< members.Length - 1; i++)
        //    {
        //        if(result.Length!=0)
        //            result.Append (" ");
        //        result.Append(ToTitleCase(members[i]));
        //    }

        //    return result.ToString();
        //}

        public static string ToTitleCase(string text)
        {
            
            CultureInfo culture_info = CultureInfo.InvariantCulture;
            TextInfo text_info = culture_info.TextInfo;
            return text_info.ToTitleCase(text.ToLower());
        }

        public static int CountVowels(string text)
        {
            int result = 0;
            result += CountChars(text,'a');
            result += CountChars(text, 'e');
            result += CountChars(text, 'i');
            result += CountChars(text, 'o');
            result += CountChars(text, 'u');

            return result;
        }

        public static int CountChars(string text,char ch)
        {
            return text.Split(ch).Length - 1;
        }

        public static int CountWords(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return 0;

            return ReplaceNewLine(text, ' ').Split(' ').Length;
        }

        public static string GetLongestWord(string words)
        {
            return GetLongestWord(
                ReplaceNewLine(words.ToString(), ' ')
                .Split(' '));
        }

        private static string GetLongestWord(string[] words)
        {
            string longWord = "";

            foreach (string word in words)
            {
                if (word.Length > longWord.Length)
                    longWord = word;
            }
            return longWord;
        }

        public static string ReplaceNewLine(string text, char replacement)
        {
            return text.Replace(Environment.NewLine, " ");
        }
    }
}

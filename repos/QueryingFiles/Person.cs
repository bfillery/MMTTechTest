using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryingFiles
{
    public class Person
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Age { get; private set; }
        public string Sex { get; private set; }
        public string Address { get; private set; }
        public string Separator { get; private set; }

        public Person(string firstName,string lastName, int age, string sex, string address)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Sex = sex;
            Address = address;
        }
        public string ToString(char separator = '|')
        {
            StringBuilder sb = new StringBuilder();
            
            sb.Append(FirstName);
            sb.Append(separator);
            sb.Append(LastName);
            sb.Append(separator);
            sb.Append(Age);
            sb.Append(separator);
            sb.Append(Sex);
            sb.Append(separator);
            sb.Append(Address);

            return sb.ToString();
                
         }

        public static string GetRowHeaders(char separator = '|')
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(nameof(FirstName));
            sb.Append(separator);
            sb.Append(nameof(LastName));
            sb.Append(separator);
            sb.Append(nameof(Age));
            sb.Append(separator);
            sb.Append(nameof(Sex));
            sb.Append(separator);
            sb.Append(nameof(Address));

            return sb.ToString();
            
        }
    }
}

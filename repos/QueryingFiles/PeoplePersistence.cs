using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryingFiles
{
    public class PeoplePersistence
    {

        public static void LoadFromFile(Collection<Person> myPeople, string filePath, char separator = '|', bool discardFirstRow = true)
        {
            using var sr = new StreamReader(filePath);
            {

                string ln;

                if (discardFirstRow)
                    sr.ReadLine(); //skip the first line

                //People.Clear();

                ln = sr.ReadLine();

                while (ln != null)
                {

                    string[] parts = ln.Split(separator);

                    myPeople.Add(new Person(parts[0].Trim(),
                                            parts[1].Trim(),
                                            int.Parse(parts[2].Trim()),
                                            parts[3].Trim(),
                                            parts[4].Trim())
                    );

                    ln = sr.ReadLine();
                }

            }
        }

        public static void SaveToFile(Collection<Person> myPeople,string filePath, char separator = '|')
        {
            using var sr = new StreamWriter(filePath);

            sr.WriteLine(Person.GetRowHeaders(separator));

            foreach (Person p in myPeople)
            {
                sr.WriteLine(p.ToString(separator));
            }


        }
    }
}

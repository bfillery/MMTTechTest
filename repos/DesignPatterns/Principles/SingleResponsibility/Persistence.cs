using System;
using System.IO;

namespace DesignPatterns.Principles.SingleResponsibility
{
    public class Persistence
    {
        public void SaveToFile(Journal j, string filename, bool overwrite =false)
        {
            try
            {
                if (overwrite || !File.Exists(filename))
                {
                    File.WriteAllText(filename, j.ToString());
                }
                else
                {
                    throw new System.ArgumentException("If file exists, overwrite flag should be set to true");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception encountered: {e.Message}");
            }
               
        }

        public static Journal Load(string filename)
        {
            string line;
            Journal j = new Journal();

            try
            {
                StreamReader file = new StreamReader(filename);
                while ((line = file.ReadLine()) != null)
                {
                    j.AddEntry(line);
                }
                
                
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception encountered: {e.Message}");
            }

            return j;

        }
    }
}

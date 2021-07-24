using GradeBook.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;

namespace GradeBook
{
    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeAddedDelegate GradeAdded;


        private string GetFilename()
        {
            return String.Concat(
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    @"\",
                    base.GetName(),
                    ".txt");
        }
        public override void AddGrade(double grade)
        {

            //if (GradeAdded != null)
            //{
            //    GradeAdded(this, new EventArgs());
            //}
            base.AddGrade(grade);

            try
            {
                SaveToFile(grade.ToString(), GetFilename());
                //stream.Write(Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Whoops: {ex.Message}");
            }
        }

        public override void OutputResults()
        {
            try
            {
                var fileName = GetFilename();

                SaveToFile(@"\_/\_/\_/\_/\_/\_/\_/\_/\_/\_/\_/\_/\_/\_/\_/\_/\_/\_/", fileName);
                SaveToFile($"Count of grades: {Statistics.Count}", fileName);
                SaveToFile($"Total: {Statistics.Total}", fileName);
                SaveToFile($"Average: {Statistics.Average:N1}", fileName);
                SaveToFile($"High: {Statistics.HighGrade:N1}", fileName);
                SaveToFile($"Low: {Statistics.LowGrade:N1}", fileName);
                SaveToFile($"The letter grade is: {Statistics.Letter}", fileName);
                //stream.Write(Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Whoops: {ex.Message}");
            }
        }

        private void SaveToFile(string line, string path)
        {
            using var stream = File.AppendText(path);
            stream.WriteLine(line);
            //stream.Write(Environment.NewLine);

        }

        public override IStatistics GetStatistics()
        {
            this.Statistics.SetStatistics(base.GetGrades());

            return this.Statistics;
        }
                
    }
}
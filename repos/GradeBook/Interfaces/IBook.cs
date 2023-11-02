using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.Interfaces
{
    public interface IBook: IDisposable
    {

        public void OutputResults();

        public void SetName(string name);


        public void AddGrade(double grade);

        public string GetName();

        public List<double> GetGrades();

        public IStatistics GetStatistics();
        public event GradeAddedDelegate GradeAdded;

        
    }
}

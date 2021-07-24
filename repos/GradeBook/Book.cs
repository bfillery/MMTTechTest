using GradeBook.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Transactions;

namespace GradeBook
{

    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public  class Book : NamedObject, IBook
    {
        public virtual event GradeAddedDelegate GradeAdded;

        private List<double> Grades { get; set; }

        public Statistics Statistics;
        private bool disposedValue;


        public Book()
        {
            Grades = new List<double>();
            this.Statistics = new Statistics();
        }

        public Book(string name) : this()
        {
            SetName(name);
        }


        public string GetName()
        {
            return Name;
        }

        public void SetName(string name)
        {
            Name = name;
        }


        public virtual void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                Grades.Add(grade);

                if(GradeAdded !=null) //anyone subscribed?
                {
                    GradeAdded(this, new EventArgs());
                }
            }

            else
            {
                //Console.WriteLine("Invalid value") ;
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public List<double> GetGrades()
        {
            return Grades;
        }

        

        public virtual void OutputResults()
        {
            Console.WriteLine($"Count of grades: {GetGrades().Count}");
            Console.WriteLine($"Total: {Statistics.Total}");
            Console.WriteLine($"Average: {Statistics.Average:N1}");
            Console.WriteLine($"High: {Statistics.HighGrade:N1}");
            Console.WriteLine($"Low: {Statistics.LowGrade:N1}");
            Console.WriteLine($"The letter grade is: {Statistics.Letter}");
        }

        public virtual IStatistics GetStatistics()
        {
            this.Statistics.SetStatistics(this.Grades);

            return this.Statistics;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~Book()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }


    }
}


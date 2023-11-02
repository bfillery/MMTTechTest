using GradeBook.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace GradeBook
{
    public class Statistics : IStatistics
    {
        private bool disposedValue;

        public double Total { get; private set; }

        public double Average { get
            {
                return (Count == 0 || Total == 0 ? 0 : (Total / Count)) ;
            }

        }
        public double HighGrade { get; private set; }
        public double LowGrade { get; private set; }
        public int Count { get; private set; }


        public Statistics()
        {
            Total = 0;
            Count = 0;
            HighGrade = 0;
            LowGrade = 0;
        }


        public char Letter { 
            get
            {
                switch (Average)
                {
                    case var d when d >= 90.0:
                        return 'A';                       

                    case var d when d >= 80.0:
                        return 'B';

                    case var d when d >= 0.0:
                        return 'C';

                    default:
                        return 'F';
                }
            }

        }


        public void SetStatistics(List<double> Grades)
        {

            try
            {
           

                foreach (var grade in Grades)
                {
                    Total += grade;
                    Count++;

                    HighGrade = Math.Max(grade, HighGrade);

                    if (LowGrade == 0)
                    {
                        LowGrade = grade;
                    }
                    else
                    {
                        LowGrade = Math.Min(grade, LowGrade);
                    }
                }



    }
            catch (Exception e)
            {
               
                Console.WriteLine($"Oops: {e.Message}");
            }

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
        // ~Statistics()
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

        //void IStatistics.SetStatistics(List<double> Grades)
        //{
        //    throw new NotImplementedException();
        //}

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }
    }

}

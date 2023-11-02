using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.Interfaces
{
    public interface IStatistics: IDisposable
    {
        public double Total { get;  }
        public double Average { get;  }
        public double HighGrade { get;  }
        public double LowGrade { get;  }
        public char Letter { get;  }

        public void SetStatistics(List<double> Grades);
    }
}

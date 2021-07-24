using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQWithFiles
{
    public class Program
    {
        static void Main(string[] args)
        {
            //a list of all students whose score on the first test was greater than 90
            //and whose last score was less than 80
            IEnumerable<Student> studentQuery =
                from student in StudentManager.students
                where student.Scores[0] > 90 && student.Scores[3] < 80
                orderby student.Last descending
                select student;

            foreach (Student student in studentQuery)
            {
                Console.WriteLine("{0}, {1} {2}", student.Last, student.First, student.Scores[0]);
            }

            // studentQuery2 is an IEnumerable<IGrouping<char, Student>>
            var studentQuery2 =
                from student in StudentManager.students
                //orderby student.Last ascending
                group student by student.Last[0];

            // studentGroup is a IGrouping<char, Student>
            foreach (var studentGroup in studentQuery2)
            {
                Console.WriteLine(studentGroup.Key);
                foreach (Student student in studentGroup)
                {
                    Console.WriteLine("   {0}, {1}",
                              student.Last, student.First);
                }
            }
        }
    }
}

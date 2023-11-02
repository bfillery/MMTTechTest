using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //FieldInvestigation(typeof(System.Object));
            MethodInvestigation(typeof(System.Object));
        }

        static void FieldInvestigation(Type t)
        {
            Console.WriteLine("*********Fields*********");
            FieldInfo[] fld = t.GetFields();
            foreach (FieldInfo f in fld)
            {
                Console.WriteLine("-->{0}", f.Name);
            }
        }

        static void MethodInvestigation(Type t)
        {
            Console.WriteLine("*********Methods*********");
            MethodInfo[] mth = t.GetMethods();
            foreach (MethodInfo m in mth)
            {
                Console.WriteLine("-->{0}", m.Name);
            }
        }
    }
}

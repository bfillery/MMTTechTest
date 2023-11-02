using DesignPatterns.Patterns.Builder;
using DesignPatterns.Principles.DependencyInversion;
using DesignPatterns.Principles.Liskov;
using DesignPatterns.Principles.OpenClosed;
using DesignPatterns.Principles.SingleResponsibility;
using Person = DesignPatterns.Patterns.Builder.Person;

namespace DesignPatterns
{
    public class Program
    {

        public static void Main(string[] args)
        {
            //singleResponsibillity();
            //openClosed();
            //liskovSubstitution();
            //dependencyInversion();


            //builder();
            fluentBuilder();


        }

        #region principles
        private static void singleResponsibillity()
        {
            //discard(i.e. "_") is new in C#9 and avoid a variable declaration you won't use
            //i.e. 'SingleResponsibility.SingleResponsibility sr =...'
            
            _ = new SingleResponsibility(@"C:\Users\Bruce\Desktop\myJournal.txt");
        }

        private static void openClosed()
        {
            //discard(i.e. "_") is new in C#9 and avoid a variable declaration you won't use
            //i.e. 'OpenClosed.OpenClosed oc = ...'
            
            _ = new OpenClosed(Enums.Color.Green, Enums.Size.Large);
        }

        private static void liskovSubstitution()
        {
            _ = new LiskovSubstitution();
        }

        private static void dependencyInversion()
        {
            DependencyInversion.Run();
        }
        #endregion



        #region patterns
        private static void builder()
        {
            var builder = new HtmlBuilder("ul");
            builder.AddChild("li", "hello").AddChild("li", "world");
            System.Console.WriteLine(builder);
        }

        private static void fluentBuilder()
        {
            var me = Person.New                       
                        .Called("Bruce")
                        .WorksAsA("quant")
                        .Build();

            System.Console.WriteLine(me);
        
            
        }
            
        #endregion

    }
}

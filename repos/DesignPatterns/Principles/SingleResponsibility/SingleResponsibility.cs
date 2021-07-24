using System;
using System.Diagnostics;

namespace DesignPatterns.Principles.SingleResponsibility
{
    public class SingleResponsibility
    {

        public SingleResponsibility(string filename)
        {
            /*
             * each class does one thing and so has one reason to change.
             * We split populating a Journal out from persisting it => separate classes
            */
            var journal = new Journal();
            var persist = new Persistence();

            journal.AddEntry("Today sucks");
            journal.AddEntry("Yesterday sucks");
            journal.AddEntry("Tomorrow sucks");

            persist.SaveToFile(journal, filename);

            for (int i = journal.Count - 1; i > 0; i--)
            {
                journal.RemoveEntry(i);

            }
            journal = Persistence.Load(filename);
            Console.WriteLine(journal.ToString());


            Process.Start(filename);
        }
    }
}

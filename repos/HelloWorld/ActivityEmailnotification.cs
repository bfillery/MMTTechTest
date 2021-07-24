using HelloWorld.Interfaces;

namespace HelloWorld
{
    public class ActivityEmailnotification: IActivity
    {
        public void Execute()
        {
            System.Console.WriteLine("E-mailing notification of processsing...");
        }
    }
}

using HelloWorld.Interfaces;

namespace HelloWorld
{
    public class ActivityUpdateStatus : IActivity
    {
        public void Execute()
        {
            System.Console.WriteLine("Updating the database status...");
        }
    }
}

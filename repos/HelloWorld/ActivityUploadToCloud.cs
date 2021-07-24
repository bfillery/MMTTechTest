using HelloWorld.Interfaces;

namespace HelloWorld
{
    public class ActivityUploadToCloud : IActivity
    {
        public void Execute()
        {
            System.Console.WriteLine("Uploading to cloud...");
        }
    }
}

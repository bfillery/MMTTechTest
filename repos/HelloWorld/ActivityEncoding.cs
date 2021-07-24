using HelloWorld.Interfaces;

namespace HelloWorld
{
    public class ActivityEncoding : IActivity
    {
        public void Execute()
        {
            System.Console.WriteLine("Announcing ready for encoding...");
        }
    }
}

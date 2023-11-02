using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndDelegates
{
    public class MessageService
    {
        //even though EventHandler doesn't have a source parameter, it's implied and still required
        //see VideEncoder
        public void OnVideoEncoded(object source, VideoEventArgs e)
        {
            Console.WriteLine("Sending a text message...");
            Console.WriteLine($"...text message sent for {e.video.Title}");
        }
    }
}

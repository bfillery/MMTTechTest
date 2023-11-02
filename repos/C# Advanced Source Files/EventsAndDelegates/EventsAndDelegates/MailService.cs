using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndDelegates
{
    public class MailService
    {
        //the event HANDLER, conforms to the signature of the delegate in teh publisher, here: VideoEncoder.cs
        //even though EventHandler doesn't have a source parameter, it's implied and still required

        public void OnVideoEncoded(object source, VideoEventArgs e)
        {
            Console.WriteLine("MailService: sending an email...");
            Console.WriteLine($"...E-mail sent for {e.video.Title}");
        }
    }
}

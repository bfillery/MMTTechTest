using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndDelegates
{
    public class Program
    {
        static void Main(string[] args)
        {

            var video = new Video() { Title = "My first video" };
            var videoEncoder = new VideoEncoder(); // the event publisher
            var mailService = new MailService(); //the subscriber
            var messageService = new MessageService(); ;// another subscriber

            //now, we need to do the subscription - register a handler for this event
            videoEncoder.VideoEncoded += mailService.OnVideoEncoded; //a pointer, not a call to the method, so no brackets ()
            videoEncoder.VideoEncoded += messageService.OnVideoEncoded;


            videoEncoder.Encode(video);
        }
    }
}

using System;
using System.Threading;

namespace EventsAndDelegates
{
    public class VideoEncoder
    {
        //1- Degine a delegate
        //2- Define an event based on that delegate
        //3- Raise the event



        //1: note the naming convention {classname}{EventHandler}(object source, EventArgs args);
        //this determines the signature of the method in the subscriber
        //Note to illustrate sending a custom set o fargs - we've created a custom class that extends/ derives ffrom
        //EventArgs: 'VideoEventArgs'

        //public delegate void VideoEncodedEventHandler(object source, VideoEventArgs args);






        //2: the event - something has happened, and finished (past tense)
        //Whenever we raise this event, we want a method in the subscriber, that conforms to this signature, to be called

        //public event VideoEncodedEventHandler VideoEncoded;





        //Good ol' .Net: this replaces 1. and 2.:
        public event EventHandler<VideoEventArgs> VideoEncoded;
        //or this if didn't want to send args:
        //public event EventHandler VideoEncoded;



        //3: raise. Need a method responsible for this: the event publisher
        //Note convention - event publisher method should be protected, virtual, void, named: {On}{Name of event}
        protected virtual void OnVideoEncoded(Video video)
        {
            //check if any subscribers
            if (VideoEncoded != null)
                //if not, then - who is raising, and what args (or EventArgs.Empty for none)
                //Note: if using EventHandler, the built in event/deegate beastie, source is implicit in the 
                //event declaration, but still required in the raise call 
                VideoEncoded(this, new VideoEventArgs() { video = video});
        }




       public void Encode(Video video)
        {
            Console.WriteLine("Encoding video...");
            Thread.Sleep(3000);


            OnVideoEncoded(video);


        }
    }
}

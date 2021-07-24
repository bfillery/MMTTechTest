using System;
using System.Collections.Generic;

namespace HelloWorld.Fundamentals
{
    public class Stopwatch
    {
        public struct timing
        {
            public DateTime started;
            public DateTime stopped;
            public TimeSpan duration;
        }

        public DateTime StartTime { get; private set; }
        public DateTime StopTime { get; private set; }
        public bool IsStarted { get; private set; }


        private Dictionary<int, timing> timings = new Dictionary<int, timing>();

        public Dictionary<int, timing> GetTimings()
        {
            return timings;
        }

        public void Start()
        {
            if (IsStarted)
                throw new InvalidOperationException("Stopwatch is already running");

            StartTime = DateTime.Now;
            IsStarted = true;

            
        }

        public void Stop()
        {
            IsStarted = false;

            StopTime = DateTime.Now; ;

            timings.Add(
                timings.Count,
                    new timing
                    {
                        started = StartTime,
                        stopped = StopTime,
                        duration = TimeSpan.FromSeconds(StopTime.Subtract(StartTime).Seconds)
                    }
                ); 
        }
    }
}

using HelloWorld.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Fundamentals
{
    public class Workflow
    {
        private readonly IList<IActivity> activities;

        public Workflow()
        {
            activities = new List < IActivity >();
        }

        public void Execute()
        {
            foreach(var activity in activities)
            {
                activity.Execute();
            }
        }


        public void RegisterActivity(IActivity activity)
        {
            if (!activities.Contains(activity))
                activities.Add(activity);
        }
    }
}

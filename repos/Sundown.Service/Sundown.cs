using Microsoft.Owin.Hosting;
using Sundown.API;
using System;
using System.ServiceProcess;

namespace Sundown.Service
{
    public partial class Sundown : ServiceBase
    {
        public Sundown()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                IDisposable server = null;
                StartOptions opt = new StartOptions();

                opt.Urls.Add(@"http://localhost:10000/");
                opt.Urls.Add(string.Format("http://{0}:10000", Environment.MachineName));

                WebHost host = new WebHost(server, opt); //constructor starts it

            }
            catch (Exception e)
            {
                string a = e.ToString();
            }
        }

        protected override void OnStop()
        {
        }
    }
}

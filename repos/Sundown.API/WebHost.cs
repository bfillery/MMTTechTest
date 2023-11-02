using System;
using Microsoft.Owin.Hosting;


namespace Sundown.API
{
    public class WebHost
    {

        private IDisposable server;

        public WebHost(IDisposable server, StartOptions startOptions)
        {
            try
            {
                this.server = server;
                server = WebApp.Start<Startup>(startOptions);
            }
            catch(Exception e)
            {
                string a = e.Message;
            }
        }
    }
}

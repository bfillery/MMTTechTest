using System.ServiceProcess;

namespace Sundown.Service
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        //To create service: Open windows command prompt as run as administrator; 
        //Type sc.exe create SERVICE NAME binpath= "SERVICE FULL PATH" 
        //don't give space in SERVICE NAME
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Sundown()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}

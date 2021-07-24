using System;
using DEMO.Common;
using DEMO.DemoDataTransferObjects;

namespace DemoConsoleApplication
{
	/// <summary>
	/// Summary description for MainClass.
	/// </summary>
	class MainClass
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			DemoClass dc = new DemoClass();
			dc.StartDemo();

		}


		
		
	}
}

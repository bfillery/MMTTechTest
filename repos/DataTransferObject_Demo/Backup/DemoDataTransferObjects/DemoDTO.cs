using System;
using System.Xml.Serialization;
using DEMO.Common;

namespace DEMO.DemoDataTransferObjects
{
	/// <summary>
	/// Summary description for the DemoDTO.
	/// </summary>
	public class DemoDTO : DTO
	{
		// Variables encapsulated by class (private).
		private string demoId = "";
		private string demoName = "";
		private string demoProgrammer = "";

		public DemoDTO()
		{
		}

		///<summary>Public access to the DemoId field.</summary>
		///<value>String</value>
		[XmlElement(IsNullable=true)]
		public string DemoId
		{
			get
			{
				return this.demoId;
			}
			set
			{
				this.demoId = value;
			}
		}

		///<summary>Public access to the DemoId field.</summary>
		///<value>String</value>
		[XmlElement(IsNullable=true)]
		public string DemoName
		{
			get
			{
				return this.demoName;
			}
			set
			{
				this.demoName = value;
			}
		}

		///<summary>Public access to the DemoId field.</summary>
		///<value>String</value>
		[XmlElement(IsNullable=true)]
		public string DemoProgrammer
		{
			get
			{
				return this.demoProgrammer;
			}
			set
			{
				this.demoProgrammer = value;
			}
		}

	}
}

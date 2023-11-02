using System;
using System.Xml.Serialization;
using System.IO;

namespace DEMO.Common
{
	/// <summary>
	/// Summary description for DTOSerializerHelper.
	/// </summary>
	public class DTOSerializerHelper
	{
		public DTOSerializerHelper()
		{
		}

		/// <summary>
		/// Creates xml string from given dto.
		/// </summary>
		/// <param name="dto">DTO</param>
		/// <returns>XML</returns>
		public static string SerializeDTO(DTO dto)
		{
			try
			{
				XmlSerializer xmlSer = new XmlSerializer(dto.GetType());
				StringWriter sWriter = new StringWriter();
				// Serialize the dto to xml.
				xmlSer.Serialize(sWriter, dto);
				// Return the string of xml.
				return sWriter.ToString();
			}
			catch(Exception ex)
			{
				// Propogate the exception.
				throw ex;
			}
		}

		/// <summary>
		/// Deserializes the xml into a specified data transfer object.
		/// </summary>
		/// <param name="xml">string of xml</param>
		/// <param name="dto">type of dto</param>
		/// <returns>DTO</returns>
		public static DTO DeserializeXml(string xml, DTO dto)
		{
			try
			{
				XmlSerializer xmlSer = new XmlSerializer(dto.GetType());
				// Read the XML.
				StringReader sReader = new StringReader(xml);
				// Cast the deserialized xml to the type of dto.
				DTO retDTO = (DTO)xmlSer.Deserialize(sReader);
				// Return the data transfer object.
				return retDTO;
			}
			catch(Exception ex)
			{
				// Propogate the exception.
				throw ex;
			}			
		}

	}
}

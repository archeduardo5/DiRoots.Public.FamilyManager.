namespace DR.Public.FM.Helpers
{
	using System;
	using System.IO;
	using System.Xml.Serialization;

	public static class XmlUtility
	{
		/// <summary>
		///	Serializes the data in the object to the designated file path
		/// </summary>
		/// <typeparam name="T">Type of Object to serialize</typeparam>
		/// <param name="obj">Object to serialize</param>
		/// <param name="filePath">FilePath for the XML file</param>
		/// <returns></returns>
		public static bool SerialiseInfo<T>(T obj, string filePath)
		{
			try
			{
				XmlSerializer serializer = new XmlSerializer(typeof(T));
				XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
				ns.Add("", "");
				using (TextWriter writer = new StreamWriter(filePath))
				{
					serializer.Serialize(writer, obj, ns);
					writer.Flush();
				}

				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		/// <summary>
		/// Deserializes the data in the XML file into an object
		/// </summary>
		/// <typeparam name="T">Type of Object to serialize</typeparam>
		/// <param name="filePath">FilePath for the XML file	</param>
		/// <returns>Object containing deserialized data</returns>
		public static T DeserialiseInfo<T>(string filePath)
		{
			try
			{
				T objInfo = default(T);
				if (File.Exists(filePath))
				{
					XmlSerializer serializer = new XmlSerializer(typeof(T));
					StreamReader reader = new StreamReader(filePath);
					objInfo = (T) serializer.Deserialize(reader);
					reader.Close();

				}

				return objInfo;
			}
			catch (Exception)
			{
				return default(T);
			}
		}
	}
}
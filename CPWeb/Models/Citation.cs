using System;
using System.Xml.Serialization;

namespace CPWeb
{
	[Serializable]
	public class Citation
	{
		public int id { get; set; }

		public string citation { get; set; }

		[XmlElement("scene")]
		public virtual Scene scene { get; set; }

		public string title { get; set; }

		public Citation ()
		{
		}
	}
}


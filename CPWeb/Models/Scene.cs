using System;
using System.Xml.Serialization;

namespace CPWeb
{
	[Serializable]
	public class Scene
	{
		public int id { get; set; }
		
		public string name { get; set; }

		public Scene ()
		{
		}
	}
}


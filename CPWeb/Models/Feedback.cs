using System;

namespace CPWeb
{
	public class Feedback
	{
		public int id { get; set; }

		public string feedback { get; set; }

		public string user { get; set; }

		public DateTime date { get; set; }

		public virtual Assessment Assessment { get; set; }

		public Feedback ()
		{
		}
	}
}


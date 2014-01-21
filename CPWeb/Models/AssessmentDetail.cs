using System;

namespace CPWeb
{
	public class AssessmentDetail
	{
		public int id { get; set; }

		public string description { get; set; }

		public int points { get; set; }

		public virtual Assessment Assessment { get; set; }

		public AssessmentDetail ()
		{
		}
	}
}


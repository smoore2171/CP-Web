using System;
using System.Collections.Generic;

namespace CPWeb
{
	public class Assessment
	{
		public int id { get; set; }

		public int score { get; set; }

		public DateTime date { get; set; }

		public virtual Scene scene { get; set; }

		public virtual Student Student { get; set; }

		public List<Feedback> feedback { get; set; }

		public List<AssessmentDetail> assessmentDetails { get; set; }

		public Assessment ()
		{
			assessmentDetails = new List<AssessmentDetail> ();
		}
	}
}


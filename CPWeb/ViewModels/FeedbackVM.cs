using System;
using System.Collections.Generic;

namespace CPWeb
{
	public class FeedbackVM
	{
		public List<Feedback> feedback { get; set; }

		public Assessment assessment { get; set; }

		public Feedback response { get; set; }

		public FeedbackVM ()
		{
		}
	}
}


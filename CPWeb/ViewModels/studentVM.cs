using System;
using System.Collections.Generic;

namespace CPWeb
{
	/// <summary>
	/// Assessment view model. One per scene
	/// </summary>
	public class studentVM
	{
		// details with updated score and all feedback
		public Student student = new Student();

		public int averageScore;

		public studentVM ()
		{
		}
	}
}


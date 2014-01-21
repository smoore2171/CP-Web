using System;
using System.Collections.Generic;

namespace CPWeb
{
	/// <summary>
	/// Assessment view model. One per scene
	/// </summary>
	public class assessmentVM
	{
		// details with updated score and all feedback
		public Assessment assessment = new Assessment();

		public int averageScore;

		public int firstScore;

		public assessmentVM ()
		{
		}
	}
}


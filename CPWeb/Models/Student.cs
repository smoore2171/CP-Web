using System;
using System.Collections.Generic;

namespace CPWeb
{
	public class Student
	{
		public int id { get; set; }

		public string userName { get; set; }

		public string name { get; set; }

		public virtual List<Assessment> assessments { get; set; }

		public Student ()
		{
			assessments = new List<Assessment> ();
		}
	}
}


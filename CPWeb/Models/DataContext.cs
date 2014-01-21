using System;
using System.Data.Entity.Migrations;
using System.Data.Entity.Migrations.Design;
using System.IO;
using System.Resources;
using System.Data.Entity;

namespace CPWeb
{
	public class DataContext : DbContext
	{
		public DbSet<Student> students { get; set; }

		public DbSet<Assessment> assessments { get; set; }

		public DbSet<AssessmentDetail> assessmentDetails { get; set; }

		public DbSet<Citation> citation { get; set; }

		public DbSet<Feedback> feedback { get; set; }

		public DbSet<Scene> scenes { get; set; }

		public DataContext ()
		{
		}
	}
}


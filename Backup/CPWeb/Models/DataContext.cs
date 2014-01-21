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
		public DbSet<TestModel> tests { get; set; }

		public DataContext ()
		{
		}
	}
}


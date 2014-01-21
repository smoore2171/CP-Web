using System;
using System.Data.Entity.Migrations;
namespace CPWeb
{
	public class DataMigrations : DbMigrationsConfiguration<DataContext>
	{
		public DataMigrations()
		{
			AutomaticMigrationsEnabled = true;
		}

		protected override void Seed(CPWeb.DataContext context)
		{
			//WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);
		}
	}
}


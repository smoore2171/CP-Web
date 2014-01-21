using System;
using System.Data.Entity.Migrations;
using MySql.Data.Entity;


namespace CPWeb
{
	internal sealed class DataMigrations : DbMigrationsConfiguration<DataContext>
	{
		public DataMigrations()
		{
			AutomaticMigrationsEnabled = true;

			SetSqlGenerator("MySql.Data.MySqlClient", new MySqlMigrationSqlGenerator());
		}

		protected override void Seed(CPWeb.DataContext context)
		{
			//WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);
		}
	}
}


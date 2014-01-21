namespace CPWeb
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration5 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Students", "pid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "pid", c => c.String(unicode: false));
        }
    }
}

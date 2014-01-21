namespace CPWeb
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Students", "pid", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("Students", "pid", c => c.Int(nullable: false));
        }
    }
}

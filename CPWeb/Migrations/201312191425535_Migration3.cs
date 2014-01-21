namespace CPWeb
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("Citations", "scene_id", c => c.Int());
            AddForeignKey("Citations", "scene_id", "Scenes", "id");
            CreateIndex("Citations", "scene_id");
            DropColumn("Citations", "scene");
        }
        
        public override void Down()
        {
            AddColumn("Citations", "scene", c => c.Int(nullable: false));
            DropIndex("Citations", new[] { "scene_id" });
            DropForeignKey("Citations", "scene_id", "Scenes");
            DropColumn("Citations", "scene_id");
        }
    }
}

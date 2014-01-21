namespace CPWeb
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Scenes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "Feedbacks",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        feedback = c.String(unicode: false),
                        user = c.String(unicode: false),
                        date = c.DateTime(nullable: false),
                        Assessment_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("Assessments", t => t.Assessment_id)
                .Index(t => t.Assessment_id);
            
			//AddColumn("Students", "userName", c => c.String(unicode: false));
			//AddColumn("Students", "name", c => c.String(unicode: false));
			//AddColumn("Students", "pid", c => c.Int(nullable: false));
			//AddColumn("Assessments", "date", c => c.DateTime(nullable: false));
			//AddColumn("Assessments", "scene_id", c => c.Int());
            AddForeignKey("Assessments", "scene_id", "Scenes", "id");
            CreateIndex("Assessments", "scene_id");
            DropColumn("Assessments", "feedback");
        }
        
        public override void Down()
        {
            AddColumn("Assessments", "feedback", c => c.String(unicode: false));
            DropIndex("Feedbacks", new[] { "Assessment_id" });
            DropIndex("Assessments", new[] { "scene_id" });
            DropForeignKey("Feedbacks", "Assessment_id", "Assessments");
            DropForeignKey("Assessments", "scene_id", "Scenes");
            DropColumn("Assessments", "scene_id");
            DropColumn("Assessments", "date");
            DropColumn("Students", "pid");
            DropColumn("Students", "name");
            DropColumn("Students", "userName");
            DropTable("Feedbacks");
            DropTable("Scenes");
        }
    }
}

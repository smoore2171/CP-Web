namespace CPWeb
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Students",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "Assessments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        score = c.Int(nullable: false),
                        feedback = c.String(unicode: false),
                        Student_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("Students", t => t.Student_id)
                .Index(t => t.Student_id);
            
            CreateTable(
                "AssessmentDetails",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        description = c.String(unicode: false),
                        points = c.Int(nullable: false),
                        Assessment_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("Assessments", t => t.Assessment_id)
                .Index(t => t.Assessment_id);
            
            CreateTable(
                "Citations",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        citation = c.String(unicode: false),
                        scene = c.Int(nullable: false),
                        title = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropIndex("AssessmentDetails", new[] { "Assessment_id" });
            DropIndex("Assessments", new[] { "Student_id" });
            DropForeignKey("AssessmentDetails", "Assessment_id", "Assessments");
            DropForeignKey("Assessments", "Student_id", "Students");
            DropTable("Citations");
            DropTable("AssessmentDetails");
            DropTable("Assessments");
            DropTable("Students");
        }
    }
}

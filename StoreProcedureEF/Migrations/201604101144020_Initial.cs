namespace StoreProcedureEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Class",
                c => new
                    {
                        ClassId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.ClassId);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 500),
                        Age = c.Int(nullable: false),
                        ClassId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.Class", t => t.ClassId, cascadeDelete: true)
                .Index(t => t.ClassId);

            CreateStoredProcedure("dbo.spAllStudent", "SELECT * FROM Student");

            CreateStoredProcedure(
                "dbo.spFindStudent",
                c => new
                {
                    StudentId = c.Int()
                }, 
                "SELECT * FROM Student WHERE StudentId = @StudentId");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Student", "ClassId", "dbo.Class");
            DropIndex("dbo.Student", new[] { "ClassId" });
            DropTable("dbo.Student");
            DropTable("dbo.Class");
            DropStoredProcedure("dbo.spAllStudent");
            DropStoredProcedure("dbo.spFindStudent");
        }
    }
}

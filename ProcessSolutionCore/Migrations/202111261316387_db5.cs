namespace ProcessSolution.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LocationTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(unicode: false),
                        Password = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Researches", "StartTime", c => c.DateTime(nullable: false, precision: 0));
            AddColumn("dbo.Researches", "EndTime", c => c.DateTime(nullable: false, precision: 0));
            AddColumn("dbo.Researches", "Annotation", c => c.String(unicode: false));
            AddColumn("dbo.Researches", "Location_Id", c => c.Int());
            AddColumn("dbo.Researches", "Researcher_Id", c => c.Int());
            AddColumn("dbo.ResearchModels", "Number", c => c.String(unicode: false));
            CreateIndex("dbo.Researches", "Location_Id");
            CreateIndex("dbo.Researches", "Researcher_Id");
            AddForeignKey("dbo.Researches", "Location_Id", "dbo.LocationTypes", "Id");
            AddForeignKey("dbo.Researches", "Researcher_Id", "dbo.UserTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Researches", "Researcher_Id", "dbo.UserTypes");
            DropForeignKey("dbo.Researches", "Location_Id", "dbo.LocationTypes");
            DropIndex("dbo.Researches", new[] { "Researcher_Id" });
            DropIndex("dbo.Researches", new[] { "Location_Id" });
            DropColumn("dbo.ResearchModels", "Number");
            DropColumn("dbo.Researches", "Researcher_Id");
            DropColumn("dbo.Researches", "Location_Id");
            DropColumn("dbo.Researches", "Annotation");
            DropColumn("dbo.Researches", "EndTime");
            DropColumn("dbo.Researches", "StartTime");
            DropTable("dbo.UserTypes");
            DropTable("dbo.LocationTypes");
        }
    }
}

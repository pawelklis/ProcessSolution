namespace ProcessSolution.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ResearchModelItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Description = c.String(unicode: false),
                        ItemType = c.Int(nullable: false),
                        ListPossibleItems = c.String(unicode: false),
                        Value = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ResearchModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Description = c.String(unicode: false),
                        ResearchPlannedStartTime = c.DateTime(nullable: false, precision: 0),
                        ResearchPlannedEndTime = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ResearchModels");
            DropTable("dbo.ResearchModelItems");
        }
    }
}

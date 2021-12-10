namespace ProcessSolution.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ResearchEntries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ResearchItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(unicode: false),
                        Model_Id = c.Int(),
                        ResearchEntry_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ResearchModelItems", t => t.Model_Id)
                .ForeignKey("dbo.ResearchEntries", t => t.ResearchEntry_Id)
                .Index(t => t.Model_Id)
                .Index(t => t.ResearchEntry_Id);
            
            DropColumn("dbo.ResearchModelItems", "Value");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ResearchModelItems", "Value", c => c.String(unicode: false));
            DropForeignKey("dbo.ResearchItems", "ResearchEntry_Id", "dbo.ResearchEntries");
            DropForeignKey("dbo.ResearchItems", "Model_Id", "dbo.ResearchModelItems");
            DropIndex("dbo.ResearchItems", new[] { "ResearchEntry_Id" });
            DropIndex("dbo.ResearchItems", new[] { "Model_Id" });
            DropTable("dbo.ResearchItems");
            DropTable("dbo.ResearchEntries");
        }
    }
}

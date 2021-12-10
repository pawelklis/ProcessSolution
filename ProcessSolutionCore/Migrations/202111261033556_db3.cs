namespace ProcessSolution.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Researches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ResearchEntries", "Research_Id", c => c.Int());
            CreateIndex("dbo.ResearchEntries", "Research_Id");
            AddForeignKey("dbo.ResearchEntries", "Research_Id", "dbo.Researches", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ResearchEntries", "Research_Id", "dbo.Researches");
            DropIndex("dbo.ResearchEntries", new[] { "Research_Id" });
            DropColumn("dbo.ResearchEntries", "Research_Id");
            DropTable("dbo.Researches");
        }
    }
}

namespace ProcessSolution.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db9 : DbMigration
    {
        public override void Up()
        {
            //RenameTable(name: "dbo.ResearchEntries1", newName: "ResearchEntries");
            //DropTable("dbo.ResearchEntries");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ResearchEntries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Research_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            RenameTable(name: "dbo.ResearchEntries", newName: "ResearchEntries1");
        }
    }
}

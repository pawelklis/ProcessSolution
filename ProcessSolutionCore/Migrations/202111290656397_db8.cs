namespace ProcessSolution.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db8 : DbMigration
    {
        public override void Up()
        {
            //RenameTable(name: "dbo.ResearchEntries", newName: "ResearchEntries1");
            //CreateTable(
            //    "dbo.ResearchEntries",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Research_Id = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ResearchEntries");
            RenameTable(name: "dbo.ResearchEntries1", newName: "ResearchEntries");
        }
    }
}

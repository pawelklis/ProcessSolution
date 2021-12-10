namespace ProcessSolution.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ResearchModelItems", "ResearchModel_Id", c => c.Int());
            CreateIndex("dbo.ResearchModelItems", "ResearchModel_Id");
            AddForeignKey("dbo.ResearchModelItems", "ResearchModel_Id", "dbo.ResearchModels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ResearchModelItems", "ResearchModel_Id", "dbo.ResearchModels");
            DropIndex("dbo.ResearchModelItems", new[] { "ResearchModel_Id" });
            DropColumn("dbo.ResearchModelItems", "ResearchModel_Id");
        }
    }
}

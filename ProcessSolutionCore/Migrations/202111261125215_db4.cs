namespace ProcessSolution.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Researches", "Model_Id", c => c.Int());
            CreateIndex("dbo.Researches", "Model_Id");
            AddForeignKey("dbo.Researches", "Model_Id", "dbo.ResearchModels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Researches", "Model_Id", "dbo.ResearchModels");
            DropIndex("dbo.Researches", new[] { "Model_Id" });
            DropColumn("dbo.Researches", "Model_Id");
        }
    }
}

namespace ProcessSolution.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ResearchItems", "ItemTime", c => c.Time(nullable: false, precision: 0));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ResearchItems", "ItemTime");
        }
    }
}

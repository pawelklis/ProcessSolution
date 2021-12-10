namespace ProcessSolution.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db12 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ResearchItemNesteds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Description = c.String(unicode: false),
                        ResearchModelItem_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ResearchModelItems", t => t.ResearchModelItem_Id)
                .Index(t => t.ResearchModelItem_Id);
            
            DropColumn("dbo.ResearchModelItems", "ListPossibleItems");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ResearchModelItems", "ListPossibleItems", c => c.String(unicode: false));
            DropForeignKey("dbo.ResearchItemNesteds", "ResearchModelItem_Id", "dbo.ResearchModelItems");
            DropIndex("dbo.ResearchItemNesteds", new[] { "ResearchModelItem_Id" });
            DropTable("dbo.ResearchItemNesteds");
        }
    }
}

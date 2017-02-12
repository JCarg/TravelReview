namespace TravelReviewProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoryModels",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.ReviewModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Summary = c.String(),
                        Title = c.String(),
                        Comment = c.String(),
                        Location = c.String(),
                        PublishDate = c.DateTime(nullable: false),
                        VacationStart = c.DateTime(nullable: false),
                        VacationEnd = c.DateTime(nullable: false),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CategoryModels", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReviewModels", "CategoryID", "dbo.CategoryModels");
            DropIndex("dbo.ReviewModels", new[] { "CategoryID" });
            DropTable("dbo.ReviewModels");
            DropTable("dbo.CategoryModels");
        }
    }
}

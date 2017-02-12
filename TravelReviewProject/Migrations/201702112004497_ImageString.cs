namespace TravelReviewProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageString : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReviewModels", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ReviewModels", "Image");
        }
    }
}

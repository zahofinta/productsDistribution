namespace ProductsDistribution.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovePricePropertyFromProductToAnnouncementToProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AnnouncementToProducts", "price", c => c.Double(nullable: false));
            DropColumn("dbo.Products", "price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "price", c => c.Double(nullable: false));
            DropColumn("dbo.AnnouncementToProducts", "price");
        }
    }
}

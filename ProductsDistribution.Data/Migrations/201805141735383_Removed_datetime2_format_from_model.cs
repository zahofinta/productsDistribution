namespace ProductsDistribution.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Removed_datetime2_format_from_model : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Announcements", "arrive_date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Announcements", "publish_date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Products", "durability", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AspNetUsers", "LockoutEndDateUtc", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "LockoutEndDateUtc", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Products", "durability", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Announcements", "publish_date", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Announcements", "arrive_date", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
    }
}

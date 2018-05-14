namespace ProductsDistribution.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTime2_Format_Added : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Announcements", "arrive_date", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Announcements", "publish_date", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Products", "durability", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.AspNetUsers", "LockoutEndDateUtc", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "LockoutEndDateUtc", c => c.DateTime());
            AlterColumn("dbo.Products", "durability", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Announcements", "publish_date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Announcements", "arrive_date", c => c.DateTime(nullable: false));
        }
    }
}

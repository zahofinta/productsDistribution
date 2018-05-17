namespace ProductsDistribution.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remove_datetime2_format : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Announcements", "arrive_date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Announcements", "arrive_date", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
    }
}

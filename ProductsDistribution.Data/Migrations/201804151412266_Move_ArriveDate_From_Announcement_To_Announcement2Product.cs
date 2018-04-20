namespace ProductsDistribution.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Move_ArriveDate_From_Announcement_To_Announcement2Product : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AnnouncementToProducts", "arrive_date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Announcements", "arrive_date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Announcements", "arrive_date", c => c.DateTime(nullable: false));
            DropColumn("dbo.AnnouncementToProducts", "arrive_date");
        }
    }
}

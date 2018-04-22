namespace ProductsDistribution.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPublishDateAndTitleToAnnouncementTable_Moved_ArriveDate_To_AnnouncementTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Announcements", "arrive_date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Announcements", "title", c => c.String(nullable: false));
            AddColumn("dbo.Announcements", "publish_date", c => c.DateTime(nullable: false));
            DropColumn("dbo.AnnouncementToProducts", "arrive_date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AnnouncementToProducts", "arrive_date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Announcements", "publish_date");
            DropColumn("dbo.Announcements", "title");
            DropColumn("dbo.Announcements", "arrive_date");
        }
    }
}

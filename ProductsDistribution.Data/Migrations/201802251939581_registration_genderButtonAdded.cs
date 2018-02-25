namespace ProductsDistribution.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class registration_genderButtonAdded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "gender", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "gender", c => c.Int(nullable: false));
        }
    }
}

namespace ProductsDistribution.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCutDropdown_Menu : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "cut", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "cut", c => c.String(nullable: false));
        }
    }
}

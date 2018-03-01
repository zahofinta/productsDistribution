namespace ProductsDistribution.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Unit_field_added_to_productTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "unit", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "unit");
        }
    }
}

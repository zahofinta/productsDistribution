namespace ProductsDistribution.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Index_Added_to_ProducerName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Producers", "producer_name", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.Producers", "producer_name", unique: true, name: "producer_nameIndex");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Producers", "producer_nameIndex");
            AlterColumn("dbo.Producers", "producer_name", c => c.String(nullable: false));
        }
    }
}

namespace ProductsDistribution.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_Create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Announcements",
                c => new
                    {
                        announcement_id = c.Int(nullable: false, identity: true),
                        arrive_date = c.DateTime(nullable: false),
                        isEnabled = c.Boolean(nullable: false),
                        status = c.Int(nullable: false),
                        userId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.announcement_id)
                .ForeignKey("dbo.AspNetUsers", t => t.userId)
                .Index(t => t.userId);
            
            CreateTable(
                "dbo.AnnouncementToProducts",
                c => new
                    {
                        announcement_to_product_id = c.Int(nullable: false, identity: true),
                        max_quantity = c.Double(nullable: false),
                        announcement_id = c.Int(nullable: false),
                        product_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.announcement_to_product_id)
                .ForeignKey("dbo.Announcements", t => t.announcement_id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.product_id, cascadeDelete: true)
                .Index(t => t.announcement_id)
                .Index(t => t.product_id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        product_id = c.Int(nullable: false, identity: true),
                        product_name = c.String(nullable: false),
                        product_description = c.String(nullable: false),
                        cut = c.String(nullable: false),
                        price = c.Double(nullable: false),
                        weight = c.Double(nullable: false),
                        volume = c.Double(nullable: false),
                        durability = c.DateTime(nullable: false),
                        other = c.String(),
                        isEnabled = c.Boolean(nullable: false),
                        rating = c.Double(nullable: false),
                        categoryId = c.Int(nullable: false),
                        category_category_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.product_id)
                .ForeignKey("dbo.Categories", t => t.category_category_id, cascadeDelete: true)
                .Index(t => t.category_category_id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        category_id = c.Int(nullable: false, identity: true),
                        category_name = c.String(nullable: false, maxLength: 50),
                        category_description = c.String(nullable: false),
                        Category_parent_id = c.Int(),
                    })
                .PrimaryKey(t => t.category_id)
                .ForeignKey("dbo.Categories", t => t.Category_parent_id)
                .Index(t => t.category_name, unique: true, name: "category_nameIndex")
                .Index(t => t.Category_parent_id);
            
            CreateTable(
                "dbo.ProducerToProducts",
                c => new
                    {
                        producer_to_product_id = c.Int(nullable: false, identity: true),
                        producer_id = c.Int(nullable: false),
                        product_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.producer_to_product_id)
                .ForeignKey("dbo.Producers", t => t.producer_id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.product_id, cascadeDelete: true)
                .Index(t => t.producer_id)
                .Index(t => t.product_id);
            
            CreateTable(
                "dbo.Producers",
                c => new
                    {
                        producer_id = c.Int(nullable: false, identity: true),
                        producer_name = c.String(nullable: false),
                        telephone_number = c.String(nullable: false),
                        producer_address = c.String(nullable: false),
                        producer_email = c.String(nullable: false),
                        isEnabled = c.Boolean(nullable: false),
                        rating = c.Double(nullable: false),
                        userId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.producer_id)
                .ForeignKey("dbo.AspNetUsers", t => t.userId)
                .Index(t => t.userId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        first_name = c.String(nullable: false),
                        surname = c.String(nullable: false),
                        gender = c.Int(nullable: false),
                        years = c.Int(nullable: false),
                        post_address = c.String(nullable: false),
                        organization = c.String(nullable: false),
                        department = c.String(),
                        isEnabled = c.Boolean(nullable: false),
                        rating = c.Double(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Queries",
                c => new
                    {
                        query_id = c.Int(nullable: false, identity: true),
                        userId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.query_id)
                .ForeignKey("dbo.AspNetUsers", t => t.userId)
                .Index(t => t.userId);
            
            CreateTable(
                "dbo.QueryToProducts",
                c => new
                    {
                        query_to_product_id = c.Int(nullable: false, identity: true),
                        quantity = c.Double(nullable: false),
                        query_id = c.Int(nullable: false),
                        product_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.query_to_product_id)
                .ForeignKey("dbo.Products", t => t.product_id, cascadeDelete: true)
                .ForeignKey("dbo.Queries", t => t.query_id, cascadeDelete: true)
                .Index(t => t.query_id)
                .Index(t => t.product_id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ProducerToProducts", "product_id", "dbo.Products");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Queries", "userId", "dbo.AspNetUsers");
            DropForeignKey("dbo.QueryToProducts", "query_id", "dbo.Queries");
            DropForeignKey("dbo.QueryToProducts", "product_id", "dbo.Products");
            DropForeignKey("dbo.Producers", "userId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Announcements", "userId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProducerToProducts", "producer_id", "dbo.Producers");
            DropForeignKey("dbo.Products", "category_category_id", "dbo.Categories");
            DropForeignKey("dbo.Categories", "Category_parent_id", "dbo.Categories");
            DropForeignKey("dbo.AnnouncementToProducts", "product_id", "dbo.Products");
            DropForeignKey("dbo.AnnouncementToProducts", "announcement_id", "dbo.Announcements");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.QueryToProducts", new[] { "product_id" });
            DropIndex("dbo.QueryToProducts", new[] { "query_id" });
            DropIndex("dbo.Queries", new[] { "userId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Producers", new[] { "userId" });
            DropIndex("dbo.ProducerToProducts", new[] { "product_id" });
            DropIndex("dbo.ProducerToProducts", new[] { "producer_id" });
            DropIndex("dbo.Categories", new[] { "Category_parent_id" });
            DropIndex("dbo.Categories", "category_nameIndex");
            DropIndex("dbo.Products", new[] { "category_category_id" });
            DropIndex("dbo.AnnouncementToProducts", new[] { "product_id" });
            DropIndex("dbo.AnnouncementToProducts", new[] { "announcement_id" });
            DropIndex("dbo.Announcements", new[] { "userId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.QueryToProducts");
            DropTable("dbo.Queries");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Producers");
            DropTable("dbo.ProducerToProducts");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.AnnouncementToProducts");
            DropTable("dbo.Announcements");
        }
    }
}

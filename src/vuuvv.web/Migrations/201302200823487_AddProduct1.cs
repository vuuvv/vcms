namespace vuuvv.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProduct1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParentId = c.Int(),
                        Name = c.String(maxLength: 255),
                        Url = c.String(maxLength: 255),
                        Description = c.String(),
                        Image = c.String(maxLength: 255),
                        FeatureImage = c.String(maxLength: 255),
                        MetaDescription = c.String(maxLength: 1024),
                        MetaKeywords = c.String(maxLength: 1024),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductCategories", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Sku = c.String(maxLength: 255),
                        Name = c.String(maxLength: 255),
                        Slug = c.String(maxLength: 255),
                        Image = c.String(maxLength: 255),
                        Thumbnail = c.String(maxLength: 255),
                        Summary = c.String(),
                        Assembly = c.String(),
                        Manual = c.String(),
                        Ordering = c.Int(nullable: false),
                        Tags = c.String(maxLength: 255),
                        Active = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Technologies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        Description = c.String(),
                        Image = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Styles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StyleCategoryId = c.Int(nullable: false),
                        Name = c.String(maxLength: 255),
                        Slug = c.String(maxLength: 255),
                        Ordering = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Summary = c.String(),
                        Introduce = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StyleCategories", t => t.StyleCategoryId, cascadeDelete: true)
                .Index(t => t.StyleCategoryId);
            
            CreateTable(
                "dbo.StyleCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        Slug = c.String(maxLength: 255),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Properties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        PropertyKeyId = c.Int(nullable: false),
                        Value = c.String(maxLength: 255),
                        Description = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.PropertyKeys", t => t.PropertyKeyId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.PropertyKeyId);
            
            CreateTable(
                "dbo.PropertyKeys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        Description = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BannerImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.String(maxLength: 255),
                        ProductCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductCategories", t => t.ProductCategoryId, cascadeDelete: true)
                .Index(t => t.ProductCategoryId);
            
            CreateTable(
                "dbo.StyleImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.String(maxLength: 255),
                        Thumbnail = c.String(maxLength: 255),
                        StyleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Styles", t => t.StyleId, cascadeDelete: true)
                .Index(t => t.StyleId);
            
            CreateTable(
                "dbo.ProductProductCategories",
                c => new
                    {
                        Product_Id = c.Int(nullable: false),
                        ProductCategory_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_Id, t.ProductCategory_Id })
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("dbo.ProductCategories", t => t.ProductCategory_Id, cascadeDelete: true)
                .Index(t => t.Product_Id)
                .Index(t => t.ProductCategory_Id);
            
            CreateTable(
                "dbo.TechnologyProducts",
                c => new
                    {
                        Technology_Id = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Technology_Id, t.Product_Id })
                .ForeignKey("dbo.Technologies", t => t.Technology_Id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .Index(t => t.Technology_Id)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.StyleTechnologies",
                c => new
                    {
                        Style_Id = c.Int(nullable: false),
                        Technology_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Style_Id, t.Technology_Id })
                .ForeignKey("dbo.Styles", t => t.Style_Id, cascadeDelete: true)
                .ForeignKey("dbo.Technologies", t => t.Technology_Id, cascadeDelete: true)
                .Index(t => t.Style_Id)
                .Index(t => t.Technology_Id);
            
            CreateTable(
                "dbo.StyleProducts",
                c => new
                    {
                        Style_Id = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Style_Id, t.Product_Id })
                .ForeignKey("dbo.Styles", t => t.Style_Id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .Index(t => t.Style_Id)
                .Index(t => t.Product_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.StyleProducts", new[] { "Product_Id" });
            DropIndex("dbo.StyleProducts", new[] { "Style_Id" });
            DropIndex("dbo.StyleTechnologies", new[] { "Technology_Id" });
            DropIndex("dbo.StyleTechnologies", new[] { "Style_Id" });
            DropIndex("dbo.TechnologyProducts", new[] { "Product_Id" });
            DropIndex("dbo.TechnologyProducts", new[] { "Technology_Id" });
            DropIndex("dbo.ProductProductCategories", new[] { "ProductCategory_Id" });
            DropIndex("dbo.ProductProductCategories", new[] { "Product_Id" });
            DropIndex("dbo.StyleImages", new[] { "StyleId" });
            DropIndex("dbo.BannerImages", new[] { "ProductCategoryId" });
            DropIndex("dbo.Properties", new[] { "PropertyKeyId" });
            DropIndex("dbo.Properties", new[] { "ProductId" });
            DropIndex("dbo.Styles", new[] { "StyleCategoryId" });
            DropIndex("dbo.ProductCategories", new[] { "ParentId" });
            DropForeignKey("dbo.StyleProducts", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.StyleProducts", "Style_Id", "dbo.Styles");
            DropForeignKey("dbo.StyleTechnologies", "Technology_Id", "dbo.Technologies");
            DropForeignKey("dbo.StyleTechnologies", "Style_Id", "dbo.Styles");
            DropForeignKey("dbo.TechnologyProducts", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.TechnologyProducts", "Technology_Id", "dbo.Technologies");
            DropForeignKey("dbo.ProductProductCategories", "ProductCategory_Id", "dbo.ProductCategories");
            DropForeignKey("dbo.ProductProductCategories", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.StyleImages", "StyleId", "dbo.Styles");
            DropForeignKey("dbo.BannerImages", "ProductCategoryId", "dbo.ProductCategories");
            DropForeignKey("dbo.Properties", "PropertyKeyId", "dbo.PropertyKeys");
            DropForeignKey("dbo.Properties", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Styles", "StyleCategoryId", "dbo.StyleCategories");
            DropForeignKey("dbo.ProductCategories", "ParentId", "dbo.ProductCategories");
            DropTable("dbo.StyleProducts");
            DropTable("dbo.StyleTechnologies");
            DropTable("dbo.TechnologyProducts");
            DropTable("dbo.ProductProductCategories");
            DropTable("dbo.StyleImages");
            DropTable("dbo.BannerImages");
            DropTable("dbo.PropertyKeys");
            DropTable("dbo.Properties");
            DropTable("dbo.StyleCategories");
            DropTable("dbo.Styles");
            DropTable("dbo.Technologies");
            DropTable("dbo.Products");
            DropTable("dbo.ProductCategories");
        }
    }
}

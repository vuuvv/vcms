namespace vuuvv.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPressAndMagzine : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PressCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 4000),
                        Slug = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Presses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        Title = c.String(maxLength: 255),
                        SubTitle = c.String(maxLength: 255),
                        Author = c.String(maxLength: 255),
                        PressFrom = c.String(maxLength: 255),
                        Summary = c.String(maxLength: 511),
                        Content = c.String(),
                        Active = c.Boolean(nullable: false),
                        Thumbnail = c.String(maxLength: 511),
                        Tags = c.String(maxLength: 511),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PressCategories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Magzines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MagzineYearId = c.Int(nullable: false),
                        Name = c.String(maxLength: 255),
                        Slug = c.String(maxLength: 255),
                        Ordering = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Thumbnail = c.String(maxLength: 511),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MagzineYears", t => t.MagzineYearId, cascadeDelete: true)
                .Index(t => t.MagzineYearId);
            
            CreateTable(
                "dbo.MagzineYears",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Year = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MagzineImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Page = c.Int(nullable: false),
                        Image = c.String(maxLength: 511),
                        MagzineId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Magzines", t => t.MagzineId, cascadeDelete: true)
                .Index(t => t.MagzineId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.MagzineImages", new[] { "MagzineId" });
            DropIndex("dbo.Magzines", new[] { "MagzineYearId" });
            DropIndex("dbo.Presses", new[] { "CategoryId" });
            DropForeignKey("dbo.MagzineImages", "MagzineId", "dbo.Magzines");
            DropForeignKey("dbo.Magzines", "MagzineYearId", "dbo.MagzineYears");
            DropForeignKey("dbo.Presses", "CategoryId", "dbo.PressCategories");
            DropTable("dbo.MagzineImages");
            DropTable("dbo.MagzineYears");
            DropTable("dbo.Magzines");
            DropTable("dbo.Presses");
            DropTable("dbo.PressCategories");
        }
    }
}

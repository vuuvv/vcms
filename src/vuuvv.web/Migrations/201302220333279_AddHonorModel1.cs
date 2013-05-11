namespace vuuvv.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHonorModel1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HonorCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        Slug = c.String(maxLength: 255),
                        Ordering = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Honors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        Name = c.String(maxLength: 255),
                        Year = c.String(maxLength: 255),
                        Description = c.String(maxLength: 4000),
                        Image = c.String(maxLength: 511),
                        Ordering = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HonorCategories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Honors", new[] { "CategoryId" });
            DropForeignKey("dbo.Honors", "CategoryId", "dbo.HonorCategories");
            DropTable("dbo.Honors");
            DropTable("dbo.HonorCategories");
        }
    }
}

namespace vuuvv.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCaseModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CaseCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Slug = c.String(maxLength: 255),
                        Name = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        Name = c.String(maxLength: 255),
                        Description = c.String(),
                        Image = c.String(maxLength: 511),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CaseCategories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Cases", new[] { "CategoryId" });
            DropForeignKey("dbo.Cases", "CategoryId", "dbo.CaseCategories");
            DropTable("dbo.Cases");
            DropTable("dbo.CaseCategories");
        }
    }
}

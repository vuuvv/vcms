namespace vuuvv.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WebPages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParentId = c.Int(),
                        Url = c.String(maxLength: 255),
                        Title = c.String(maxLength: 255),
                        Content = c.String(),
                        MetaDescription = c.String(maxLength: 1024),
                        MetaKeywords = c.String(maxLength: 1024),
                        Order = c.Int(nullable: false),
                        Col = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        InNavigation = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WebPages", t => t.ParentId)
                .Index(t => t.ParentId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.WebPages", new[] { "ParentId" });
            DropForeignKey("dbo.WebPages", "ParentId", "dbo.WebPages");
            DropTable("dbo.WebPages");
        }
    }
}

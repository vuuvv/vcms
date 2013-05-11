namespace vuuvv.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDealerModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Areas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParentId = c.Int(),
                        Name = c.String(maxLength: 255),
                        boundary = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Areas", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.Dealers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        Address = c.String(maxLength: 255),
                        Contact = c.String(maxLength: 255),
                        Tel = c.String(maxLength: 255),
                        Mobile = c.String(maxLength: 255),
                        Fax = c.String(maxLength: 255),
                        Website = c.String(maxLength: 255),
                        Zipcode = c.String(maxLength: 255),
                        latitude = c.String(maxLength: 255),
                        longitude = c.String(maxLength: 255),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Areas", new[] { "ParentId" });
            DropForeignKey("dbo.Areas", "ParentId", "dbo.Areas");
            DropTable("dbo.Dealers");
            DropTable("dbo.Areas");
        }
    }
}

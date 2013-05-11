namespace vuuvv.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddConferenceModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ConferenceColumns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ConferenceArticles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        Name = c.String(maxLength: 255),
                        Content = c.String(),
                        Column_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ConferenceColumns", t => t.Column_Id)
                .Index(t => t.Column_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.ConferenceArticles", new[] { "Column_Id" });
            DropForeignKey("dbo.ConferenceArticles", "Column_Id", "dbo.ConferenceColumns");
            DropTable("dbo.ConferenceArticles");
            DropTable("dbo.ConferenceColumns");
        }
    }
}

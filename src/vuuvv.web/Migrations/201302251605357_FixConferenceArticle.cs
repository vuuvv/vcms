namespace vuuvv.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixConferenceArticle : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ConferenceArticles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ColumnId = c.Int(nullable: false),
                        Name = c.String(maxLength: 255),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ConferenceColumns", t => t.ColumnId)
                .Index(t => t.ColumnId);
        }
        
        public override void Down()
        {
        }
    }
}

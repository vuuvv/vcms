namespace vuuvv.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixEndConferenceArticle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ConferenceArticles", "Title", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ConferenceArticles", "Title");
        }
    }
}

namespace vuuvv.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLinkToSlide : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Slides", "Link", c => c.String(maxLength: 511));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Slides", "Link");
        }
    }
}

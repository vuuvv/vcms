namespace vuuvv.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHasBannerAtWebPage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WebPages", "HasBanner", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WebPages", "HasBanner");
        }
    }
}

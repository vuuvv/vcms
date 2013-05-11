namespace vuuvv.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBannerOrdering : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BannerImages", "Ordering", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BannerImages", "Ordering");
        }
    }
}

namespace vuuvv.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddActiveToSlide : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Slides", "Active", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Slides", "Active");
        }
    }
}

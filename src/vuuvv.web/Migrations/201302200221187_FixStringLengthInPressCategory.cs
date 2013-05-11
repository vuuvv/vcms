namespace vuuvv.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixStringLengthInPressCategory : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PressCategories", "Name", c => c.String(maxLength: 255));
            AlterColumn("dbo.PressCategories", "Slug", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PressCategories", "Slug", c => c.String(maxLength: 4000));
            AlterColumn("dbo.PressCategories", "Name", c => c.String(maxLength: 4000));
        }
    }
}

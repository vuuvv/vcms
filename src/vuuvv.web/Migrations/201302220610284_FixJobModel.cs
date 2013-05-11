namespace vuuvv.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixJobModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Jobs", "ExpiredDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Jobs", "ExpiredDate", c => c.DateTime(nullable: false));
        }
    }
}

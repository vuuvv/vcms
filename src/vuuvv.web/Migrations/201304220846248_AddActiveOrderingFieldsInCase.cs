namespace vuuvv.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddActiveOrderingFieldsInCase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cases", "Ordering", c => c.Int(nullable: false));
            AddColumn("dbo.Cases", "Active", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cases", "Active");
            DropColumn("dbo.Cases", "Ordering");
        }
    }
}

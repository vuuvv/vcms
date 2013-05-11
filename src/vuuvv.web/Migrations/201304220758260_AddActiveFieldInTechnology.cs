namespace vuuvv.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddActiveFieldInTechnology : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Technologies", "Active", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Technologies", "Active");
        }
    }
}

namespace vuuvv.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrderingInCaseCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CaseCategories", "Ordering", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CaseCategories", "Ordering");
        }
    }
}

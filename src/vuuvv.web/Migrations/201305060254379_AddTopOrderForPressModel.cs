namespace vuuvv.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTopOrderForPressModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Presses", "TopOrder", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Presses", "TopOrder");
        }
    }
}

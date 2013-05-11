namespace vuuvv.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelationDealerAndArea : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dealers", "AreaId", c => c.Int(nullable: false));
            AddColumn("dbo.Dealers", "Area", c => c.Int(nullable: false));
            AddForeignKey("dbo.Dealers", "AreaId", "dbo.Areas", "Id", cascadeDelete: true);
            CreateIndex("dbo.Dealers", "AreaId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Dealers", new[] { "AreaId" });
            DropForeignKey("dbo.Dealers", "AreaId", "dbo.Areas");
            DropColumn("dbo.Dealers", "Area");
            DropColumn("dbo.Dealers", "AreaId");
        }
    }
}

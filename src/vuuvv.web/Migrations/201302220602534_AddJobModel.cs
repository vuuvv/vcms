namespace vuuvv.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddJobModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        Experience = c.String(maxLength: 255),
                        Education = c.String(maxLength: 255),
                        Professional = c.String(maxLength: 255),
                        Age = c.String(maxLength: 255),
                        Gender = c.String(maxLength: 255),
                        Description = c.String(),
                        PublishDate = c.DateTime(nullable: false),
                        ExpiredDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Jobs");
        }
    }
}

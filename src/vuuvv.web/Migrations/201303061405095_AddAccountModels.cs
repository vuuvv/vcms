namespace vuuvv.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAccountModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 255),
                        RealName = c.String(maxLength: 255),
                        Password = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        Description = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ActionPermissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        Description = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MenuPermissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParentId = c.Int(nullable: false),
                        ActionName = c.String(maxLength: 255),
                        ControllerName = c.String(maxLength: 255),
                        Description = c.String(maxLength: 255),
                        Icon1 = c.String(maxLength: 255),
                        Icon2 = c.String(maxLength: 255),
                        IsLeaf = c.Boolean(nullable: false),
                        Url = c.String(maxLength: 255),
                        IsExt = c.Boolean(nullable: false),
                        Order = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MenuPermissions", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.RoleUsers",
                c => new
                    {
                        Role_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_Id, t.User_Id })
                .ForeignKey("dbo.Roles", t => t.Role_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Role_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.ActionPermissionRoles",
                c => new
                    {
                        ActionPermission_Id = c.Int(nullable: false),
                        Role_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ActionPermission_Id, t.Role_Id })
                .ForeignKey("dbo.ActionPermissions", t => t.ActionPermission_Id, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.Role_Id, cascadeDelete: true)
                .Index(t => t.ActionPermission_Id)
                .Index(t => t.Role_Id);
            
            CreateTable(
                "dbo.MenuPermissionRoles",
                c => new
                    {
                        MenuPermission_Id = c.Int(nullable: false),
                        Role_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MenuPermission_Id, t.Role_Id })
                .ForeignKey("dbo.MenuPermissions", t => t.MenuPermission_Id, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.Role_Id, cascadeDelete: true)
                .Index(t => t.MenuPermission_Id)
                .Index(t => t.Role_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.MenuPermissionRoles", new[] { "Role_Id" });
            DropIndex("dbo.MenuPermissionRoles", new[] { "MenuPermission_Id" });
            DropIndex("dbo.ActionPermissionRoles", new[] { "Role_Id" });
            DropIndex("dbo.ActionPermissionRoles", new[] { "ActionPermission_Id" });
            DropIndex("dbo.RoleUsers", new[] { "User_Id" });
            DropIndex("dbo.RoleUsers", new[] { "Role_Id" });
            DropIndex("dbo.MenuPermissions", new[] { "ParentId" });
            DropForeignKey("dbo.MenuPermissionRoles", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.MenuPermissionRoles", "MenuPermission_Id", "dbo.MenuPermissions");
            DropForeignKey("dbo.ActionPermissionRoles", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.ActionPermissionRoles", "ActionPermission_Id", "dbo.ActionPermissions");
            DropForeignKey("dbo.RoleUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.RoleUsers", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.MenuPermissions", "ParentId", "dbo.MenuPermissions");
            DropTable("dbo.MenuPermissionRoles");
            DropTable("dbo.ActionPermissionRoles");
            DropTable("dbo.RoleUsers");
            DropTable("dbo.MenuPermissions");
            DropTable("dbo.ActionPermissions");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
        }
    }
}

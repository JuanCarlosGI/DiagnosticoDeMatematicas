namespace DiagnosticoDeMatematicas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IncludeIdentity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Response", "UserId", "dbo.User");
            DropPrimaryKey("dbo.User");
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.User", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .Index(t => t.UserId)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.User", "Id", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.User", "EmailConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.User", "PasswordHash", c => c.String());
            AddColumn("dbo.User", "SecurityStamp", c => c.String());
            AddColumn("dbo.User", "PhoneNumber", c => c.String());
            AddColumn("dbo.User", "PhoneNumberConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.User", "TwoFactorEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.User", "LockoutEndDateUtc", c => c.DateTime());
            AddColumn("dbo.User", "LockoutEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.User", "AccessFailedCount", c => c.Int(nullable: false));
            AlterColumn("dbo.User", "Email", c => c.String());
            AddPrimaryKey("dbo.User", "Id");
            AddForeignKey("dbo.Response", "UserId", "dbo.User", "Id", cascadeDelete: true);
            DropColumn("dbo.User", "Role");
            DropColumn("dbo.User", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "Password", c => c.String(nullable: false));
            AddColumn("dbo.User", "Role", c => c.Int(nullable: false));
            DropForeignKey("dbo.Response", "UserId", "dbo.User");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.IdentityUserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.IdentityUserLogin", "User_Id", "dbo.User");
            DropForeignKey("dbo.IdentityUserClaim", "UserId", "dbo.User");
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "UserId" });
            DropIndex("dbo.IdentityUserLogin", new[] { "User_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "UserId" });
            DropPrimaryKey("dbo.User");
            AlterColumn("dbo.User", "Email", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.User", "AccessFailedCount");
            DropColumn("dbo.User", "LockoutEnabled");
            DropColumn("dbo.User", "LockoutEndDateUtc");
            DropColumn("dbo.User", "TwoFactorEnabled");
            DropColumn("dbo.User", "PhoneNumberConfirmed");
            DropColumn("dbo.User", "PhoneNumber");
            DropColumn("dbo.User", "SecurityStamp");
            DropColumn("dbo.User", "PasswordHash");
            DropColumn("dbo.User", "EmailConfirmed");
            DropColumn("dbo.User", "Id");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            AddPrimaryKey("dbo.User", "Email");
            AddForeignKey("dbo.Response", "UserId", "dbo.User", "Email", cascadeDelete: true);
        }
    }
}

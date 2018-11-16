namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Songs",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        SongName = c.String(),
                        SingerName = c.String(),
                        AlbumName = c.String(),
                        image = c.Binary(),
                        song = c.Binary(),
                        nationalID = c.Binary(),
                        user_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.user_Id)
                .Index(t => t.user_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Name = c.String(nullable: false, maxLength: 256),
                        AccountNumber = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        AspNetUsers_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AspNetUsers_Id)
                .Index(t => t.AspNetUsers_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        AspNetUsers_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.AspNetUsers_Id)
                .Index(t => t.AspNetUsers_Id);
            
            CreateTable(
                "dbo.AspNetRolesAspNetUsers",
                c => new
                    {
                        AspNetRoles_Id = c.String(nullable: false, maxLength: 128),
                        AspNetUsers_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.AspNetRoles_Id, t.AspNetUsers_Id })
                .ForeignKey("dbo.AspNetRoles", t => t.AspNetRoles_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.AspNetUsers_Id, cascadeDelete: true)
                .Index(t => t.AspNetRoles_Id)
                .Index(t => t.AspNetUsers_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Songs", "user_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "AspNetUsers_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "AspNetUsers_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetRolesAspNetUsers", "AspNetUsers_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetRolesAspNetUsers", "AspNetRoles_Id", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetRolesAspNetUsers", new[] { "AspNetUsers_Id" });
            DropIndex("dbo.AspNetRolesAspNetUsers", new[] { "AspNetRoles_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "AspNetUsers_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "AspNetUsers_Id" });
            DropIndex("dbo.Songs", new[] { "user_Id" });
            DropTable("dbo.AspNetRolesAspNetUsers");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Songs");
        }
    }
}

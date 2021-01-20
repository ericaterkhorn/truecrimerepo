namespace TrueCrimeRepo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeforeignkeyperpetrator : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        BookID = c.Int(nullable: false, identity: true),
                        CrimeID = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        Title = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 300),
                        BookAuthor = c.String(nullable: false, maxLength: 30),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.BookID)
                .ForeignKey("dbo.Crime", t => t.CrimeID, cascadeDelete: true)
                .ForeignKey("dbo.ApplicationUser", t => t.UserId)
                .Index(t => t.CrimeID)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Crime",
                c => new
                    {
                        CrimeID = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        Title = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false, maxLength: 2000),
                        Perpetrator = c.String(maxLength: 50),
                        Location = c.String(maxLength: 50),
                        IsCrimeSolved = c.Int(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.CrimeID)
                .ForeignKey("dbo.ApplicationUser", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Podcast",
                c => new
                    {
                        PodcastID = c.Int(nullable: false, identity: true),
                        CrimeID = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        Title = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 300),
                        WebsiteUrl = c.String(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.PodcastID)
                .ForeignKey("dbo.Crime", t => t.CrimeID, cascadeDelete: true)
                .ForeignKey("dbo.ApplicationUser", t => t.UserId)
                .Index(t => t.CrimeID)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.TVShow",
                c => new
                    {
                        TVShowID = c.Int(nullable: false, identity: true),
                        CrimeID = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        Title = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 300),
                        Channel_OnlineStream = c.String(),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.TVShowID)
                .ForeignKey("dbo.Crime", t => t.CrimeID, cascadeDelete: true)
                .ForeignKey("dbo.ApplicationUser", t => t.UserId)
                .Index(t => t.CrimeID)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Perpetrator",
                c => new
                    {
                        PerpetratorID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CrimeID = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.PerpetratorID)
                .ForeignKey("dbo.Crime", t => t.CrimeID, cascadeDelete: true)
                .ForeignKey("dbo.ApplicationUser", t => t.UserId)
                .Index(t => t.CrimeID)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Perpetrator", "UserId", "dbo.ApplicationUser");
            DropForeignKey("dbo.Perpetrator", "CrimeID", "dbo.Crime");
            DropForeignKey("dbo.Book", "UserId", "dbo.ApplicationUser");
            DropForeignKey("dbo.Book", "CrimeID", "dbo.Crime");
            DropForeignKey("dbo.Crime", "UserId", "dbo.ApplicationUser");
            DropForeignKey("dbo.TVShow", "UserId", "dbo.ApplicationUser");
            DropForeignKey("dbo.TVShow", "CrimeID", "dbo.Crime");
            DropForeignKey("dbo.Podcast", "UserId", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.Podcast", "CrimeID", "dbo.Crime");
            DropIndex("dbo.Perpetrator", new[] { "UserId" });
            DropIndex("dbo.Perpetrator", new[] { "CrimeID" });
            DropIndex("dbo.TVShow", new[] { "UserId" });
            DropIndex("dbo.TVShow", new[] { "CrimeID" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Podcast", new[] { "UserId" });
            DropIndex("dbo.Podcast", new[] { "CrimeID" });
            DropIndex("dbo.Crime", new[] { "UserId" });
            DropIndex("dbo.Book", new[] { "UserId" });
            DropIndex("dbo.Book", new[] { "CrimeID" });
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Perpetrator");
            DropTable("dbo.TVShow");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.Podcast");
            DropTable("dbo.Crime");
            DropTable("dbo.Book");
        }
    }
}

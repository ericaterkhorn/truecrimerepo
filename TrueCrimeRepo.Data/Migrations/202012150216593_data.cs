namespace TrueCrimeRepo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class data : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        BookID = c.Int(nullable: false, identity: true),
                        CrimeID = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 300),
                        BookAuthor = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.BookID)
                .ForeignKey("dbo.Crime", t => t.CrimeID, cascadeDelete: true)
                .Index(t => t.CrimeID);
            
            CreateTable(
                "dbo.Podcast",
                c => new
                    {
                        PodcastID = c.Int(nullable: false, identity: true),
                        CrimeID = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 300),
                        WebsiteUrl = c.String(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.PodcastID)
                .ForeignKey("dbo.Crime", t => t.CrimeID, cascadeDelete: true)
                .Index(t => t.CrimeID);
            
            CreateTable(
                "dbo.TVShow",
                c => new
                    {
                        TVShowID = c.Int(nullable: false, identity: true),
                        CrimeID = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 300),
                        Channel_OnlineStream = c.String(),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.TVShowID)
                .ForeignKey("dbo.Crime", t => t.CrimeID, cascadeDelete: true)
                .Index(t => t.CrimeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TVShow", "CrimeID", "dbo.Crime");
            DropForeignKey("dbo.Podcast", "CrimeID", "dbo.Crime");
            DropForeignKey("dbo.Book", "CrimeID", "dbo.Crime");
            DropIndex("dbo.TVShow", new[] { "CrimeID" });
            DropIndex("dbo.Podcast", new[] { "CrimeID" });
            DropIndex("dbo.Book", new[] { "CrimeID" });
            DropTable("dbo.TVShow");
            DropTable("dbo.Podcast");
            DropTable("dbo.Book");
        }
    }
}

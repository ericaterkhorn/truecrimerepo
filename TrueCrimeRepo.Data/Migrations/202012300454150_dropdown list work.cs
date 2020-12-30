namespace TrueCrimeRepo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropdownlistwork : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Podcast", "Podcast_PodcastID", "dbo.Podcast");
            DropIndex("dbo.Podcast", new[] { "Podcast_PodcastID" });
            DropColumn("dbo.Podcast", "Podcast_PodcastID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Podcast", "Podcast_PodcastID", c => c.Int());
            CreateIndex("dbo.Podcast", "Podcast_PodcastID");
            AddForeignKey("dbo.Podcast", "Podcast_PodcastID", "dbo.Podcast", "PodcastID");
        }
    }
}

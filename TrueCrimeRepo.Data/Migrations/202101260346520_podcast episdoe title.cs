namespace TrueCrimeRepo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class podcastepisdoetitle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Podcast", "PodcastEpisodeTitle", c => c.String(nullable: false));
            AlterColumn("dbo.Book", "Description", c => c.String(maxLength: 600));
            AlterColumn("dbo.Podcast", "Description", c => c.String(maxLength: 600));
            AlterColumn("dbo.TVShow", "Description", c => c.String(maxLength: 600));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TVShow", "Description", c => c.String(maxLength: 300));
            AlterColumn("dbo.Podcast", "Description", c => c.String(maxLength: 300));
            AlterColumn("dbo.Book", "Description", c => c.String(maxLength: 300));
            DropColumn("dbo.Podcast", "PodcastEpisodeTitle");
        }
    }
}

namespace TrueCrimeRepo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class podcastapplicationuser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Podcast", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Podcast", "UserId");
            AddForeignKey("dbo.Podcast", "UserId", "dbo.ApplicationUser", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Podcast", "UserId", "dbo.ApplicationUser");
            DropIndex("dbo.Podcast", new[] { "UserId" });
            DropColumn("dbo.Podcast", "UserId");
        }
    }
}

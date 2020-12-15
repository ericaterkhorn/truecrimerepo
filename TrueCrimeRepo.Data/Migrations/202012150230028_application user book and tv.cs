namespace TrueCrimeRepo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class applicationuserbookandtv : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Book", "UserId", c => c.String(maxLength: 128));
            AddColumn("dbo.TVShow", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Book", "UserId");
            CreateIndex("dbo.TVShow", "UserId");
            AddForeignKey("dbo.TVShow", "UserId", "dbo.ApplicationUser", "Id");
            AddForeignKey("dbo.Book", "UserId", "dbo.ApplicationUser", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Book", "UserId", "dbo.ApplicationUser");
            DropForeignKey("dbo.TVShow", "UserId", "dbo.ApplicationUser");
            DropIndex("dbo.TVShow", new[] { "UserId" });
            DropIndex("dbo.Book", new[] { "UserId" });
            DropColumn("dbo.TVShow", "UserId");
            DropColumn("dbo.Book", "UserId");
        }
    }
}

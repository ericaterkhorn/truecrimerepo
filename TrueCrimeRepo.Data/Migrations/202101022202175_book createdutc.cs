namespace TrueCrimeRepo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bookcreatedutc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Book", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Book", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Book", "ModifiedUtc");
            DropColumn("dbo.Book", "CreatedUtc");
        }
    }
}

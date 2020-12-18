namespace TrueCrimeRepo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removingyear : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Crime", "Year");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Crime", "Year", c => c.DateTime(nullable: false));
        }
    }
}

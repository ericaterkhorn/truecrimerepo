namespace TrueCrimeRepo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requiredforsolveddropdown : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Crime", "IsSolved");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Crime", "IsSolved", c => c.Boolean(nullable: false));
        }
    }
}

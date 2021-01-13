namespace TrueCrimeRepo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yesnodropdown : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Crime", "IsCrimeSolved", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Crime", "IsCrimeSolved");
        }
    }
}

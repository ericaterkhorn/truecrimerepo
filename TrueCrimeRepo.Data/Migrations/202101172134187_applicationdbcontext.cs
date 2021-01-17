namespace TrueCrimeRepo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class applicationdbcontext : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Perpetrator", "UserId", "dbo.ApplicationUser");
            DropForeignKey("dbo.Perpetrator", "CrimeID", "dbo.Crime");
            DropIndex("dbo.Perpetrator", new[] { "UserId" });
            DropIndex("dbo.Perpetrator", new[] { "CrimeID" });
            DropTable("dbo.Perpetrator");
        }
    }
}

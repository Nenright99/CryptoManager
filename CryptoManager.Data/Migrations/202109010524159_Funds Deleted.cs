namespace CryptoManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FundsDeleted : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ApplicationUser", "Funds");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ApplicationUser", "Funds", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}

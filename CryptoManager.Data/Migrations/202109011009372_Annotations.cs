namespace CryptoManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Annotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Crypto", "Ticker", c => c.String(nullable: false, maxLength: 5));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Crypto", "Ticker", c => c.String(nullable: false));
        }
    }
}

namespace CryptoManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TickerChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Crypto", "Ticker", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Crypto", "Ticker", c => c.Int(nullable: false));
        }
    }
}

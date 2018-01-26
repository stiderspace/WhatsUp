namespace WhatsUp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class allownull : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Contact", new[] { "ContactAccountId" });
            AlterColumn("dbo.Contact", "ContactAccountId", c => c.Int());
            CreateIndex("dbo.Contact", "ContactAccountId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Contact", new[] { "ContactAccountId" });
            AlterColumn("dbo.Contact", "ContactAccountId", c => c.Int(nullable: false));
            CreateIndex("dbo.Contact", "ContactAccountId");
        }
    }
}

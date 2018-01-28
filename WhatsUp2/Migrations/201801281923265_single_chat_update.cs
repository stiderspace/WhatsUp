namespace WhatsUp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class single_chat_update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contact", "chatId", c => c.Int());
            CreateIndex("dbo.Contact", "chatId");
            AddForeignKey("dbo.Contact", "chatId", "dbo.Chat", "ChatId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contact", "chatId", "dbo.Chat");
            DropIndex("dbo.Contact", new[] { "chatId" });
            DropColumn("dbo.Contact", "chatId");
        }
    }
}

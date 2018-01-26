namespace WhatsUp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chats : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GroupAccounts", "Group_Id", "dbo.Group");
            DropForeignKey("dbo.GroupAccounts", "Account_Id", "dbo.Account");
            DropForeignKey("dbo.Chat", "ReceiverId_Id", "dbo.Contact");
            DropForeignKey("dbo.Chat", "SenderId_Id", "dbo.Contact");
            DropIndex("dbo.Chat", new[] { "ReceiverId_Id" });
            DropIndex("dbo.Chat", new[] { "SenderId_Id" });
            DropIndex("dbo.GroupAccounts", new[] { "Group_Id" });
            DropIndex("dbo.GroupAccounts", new[] { "Account_Id" });
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        SenderId = c.Int(nullable: false),
                        ChatId = c.Int(nullable: false),
                        SendDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MessageId)
                .ForeignKey("dbo.Chat", t => t.ChatId, cascadeDelete: true)
                .ForeignKey("dbo.Account", t => t.SenderId, cascadeDelete: true)
                .Index(t => t.SenderId)
                .Index(t => t.ChatId);
            
            CreateTable(
                "dbo.ChatAccounts",
                c => new
                    {
                        Chat_ChatId = c.Int(nullable: false),
                        Account_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Chat_ChatId, t.Account_Id })
                .ForeignKey("dbo.Chat", t => t.Chat_ChatId, cascadeDelete: true)
                .ForeignKey("dbo.Account", t => t.Account_Id, cascadeDelete: true)
                .Index(t => t.Chat_ChatId)
                .Index(t => t.Account_Id);
            
            AddColumn("dbo.Chat", "ChatName", c => c.String());
            AddColumn("dbo.Chat", "ChatDesc", c => c.String());
            DropColumn("dbo.Chat", "Message");
            DropColumn("dbo.Chat", "Tijd");
            DropColumn("dbo.Chat", "ReceiverId_Id");
            DropColumn("dbo.Chat", "SenderId_Id");
            DropTable("dbo.Group");
            DropTable("dbo.GroupAccounts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.GroupAccounts",
                c => new
                    {
                        Group_Id = c.Int(nullable: false),
                        Account_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Group_Id, t.Account_Id });
            
            CreateTable(
                "dbo.Group",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Chat", "SenderId_Id", c => c.Int());
            AddColumn("dbo.Chat", "ReceiverId_Id", c => c.Int());
            AddColumn("dbo.Chat", "Tijd", c => c.DateTime(nullable: false));
            AddColumn("dbo.Chat", "Message", c => c.String());
            DropForeignKey("dbo.ChatAccounts", "Account_Id", "dbo.Account");
            DropForeignKey("dbo.ChatAccounts", "Chat_ChatId", "dbo.Chat");
            DropForeignKey("dbo.Messages", "SenderId", "dbo.Account");
            DropForeignKey("dbo.Messages", "ChatId", "dbo.Chat");
            DropIndex("dbo.ChatAccounts", new[] { "Account_Id" });
            DropIndex("dbo.ChatAccounts", new[] { "Chat_ChatId" });
            DropIndex("dbo.Messages", new[] { "ChatId" });
            DropIndex("dbo.Messages", new[] { "SenderId" });
            DropColumn("dbo.Chat", "ChatDesc");
            DropColumn("dbo.Chat", "ChatName");
            DropTable("dbo.ChatAccounts");
            DropTable("dbo.Messages");
            CreateIndex("dbo.GroupAccounts", "Account_Id");
            CreateIndex("dbo.GroupAccounts", "Group_Id");
            CreateIndex("dbo.Chat", "SenderId_Id");
            CreateIndex("dbo.Chat", "ReceiverId_Id");
            AddForeignKey("dbo.Chat", "SenderId_Id", "dbo.Contact", "Id");
            AddForeignKey("dbo.Chat", "ReceiverId_Id", "dbo.Contact", "Id");
            AddForeignKey("dbo.GroupAccounts", "Account_Id", "dbo.Account", "Id", cascadeDelete: true);
            AddForeignKey("dbo.GroupAccounts", "Group_Id", "dbo.Group", "Id", cascadeDelete: true);
        }
    }
}

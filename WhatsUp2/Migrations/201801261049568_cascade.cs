namespace WhatsUp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cascade : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PhoneNumber = c.String(),
                        EmailAddress = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nickname = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                        OwnerAccountId = c.Int(nullable: false),
                        ContactAccountId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Account", t => t.ContactAccountId)
                .ForeignKey("dbo.Account", t => t.OwnerAccountId, cascadeDelete: true)
                .Index(t => t.OwnerAccountId)
                .Index(t => t.ContactAccountId);
            
            CreateTable(
                "dbo.Group",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Chat",
                c => new
                    {
                        ChatId = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        Tijd = c.DateTime(nullable: false),
                        ReceiverId_Id = c.Int(),
                        SenderId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ChatId)
                .ForeignKey("dbo.Contact", t => t.ReceiverId_Id)
                .ForeignKey("dbo.Contact", t => t.SenderId_Id)
                .Index(t => t.ReceiverId_Id)
                .Index(t => t.SenderId_Id);
            
            CreateTable(
                "dbo.GroupAccounts",
                c => new
                    {
                        Group_Id = c.Int(nullable: false),
                        Account_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Group_Id, t.Account_Id })
                .ForeignKey("dbo.Group", t => t.Group_Id, cascadeDelete: true)
                .ForeignKey("dbo.Account", t => t.Account_Id, cascadeDelete: true)
                .Index(t => t.Group_Id)
                .Index(t => t.Account_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Chat", "SenderId_Id", "dbo.Contact");
            DropForeignKey("dbo.Chat", "ReceiverId_Id", "dbo.Contact");
            DropForeignKey("dbo.GroupAccounts", "Account_Id", "dbo.Account");
            DropForeignKey("dbo.GroupAccounts", "Group_Id", "dbo.Group");
            DropForeignKey("dbo.Contact", "OwnerAccountId", "dbo.Account");
            DropForeignKey("dbo.Contact", "ContactAccountId", "dbo.Account");
            DropIndex("dbo.GroupAccounts", new[] { "Account_Id" });
            DropIndex("dbo.GroupAccounts", new[] { "Group_Id" });
            DropIndex("dbo.Chat", new[] { "SenderId_Id" });
            DropIndex("dbo.Chat", new[] { "ReceiverId_Id" });
            DropIndex("dbo.Contact", new[] { "ContactAccountId" });
            DropIndex("dbo.Contact", new[] { "OwnerAccountId" });
            DropTable("dbo.GroupAccounts");
            DropTable("dbo.Chat");
            DropTable("dbo.Group");
            DropTable("dbo.Contact");
            DropTable("dbo.Account");
        }
    }
}

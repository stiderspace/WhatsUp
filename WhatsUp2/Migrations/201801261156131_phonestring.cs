namespace WhatsUp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class phonestring : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contact", "PhoneNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contact", "PhoneNumber", c => c.Int(nullable: false));
        }
    }
}

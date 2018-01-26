namespace WhatsUp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chatsmessages : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "Messages", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "Messages");
        }
    }
}

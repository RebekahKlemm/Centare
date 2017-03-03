namespace CheckInWeb.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveUserId2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Achievements", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Achievements", "UserId", c => c.Int(nullable: false));
        }
    }
}

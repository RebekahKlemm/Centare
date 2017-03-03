namespace CheckInWeb.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveUserId : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CheckIns", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CheckIns", "UserId", c => c.Int(nullable: false));
        }
    }
}

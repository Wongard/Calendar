namespace Calendar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reminders", "day", c => c.String());
            AddColumn("dbo.Reminders", "hour", c => c.Int(nullable: false));
            AddColumn("dbo.Reminders", "minute", c => c.Int(nullable: false));
            DropColumn("dbo.Reminders", "date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reminders", "date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Reminders", "minute");
            DropColumn("dbo.Reminders", "hour");
            DropColumn("dbo.Reminders", "day");
        }
    }
}

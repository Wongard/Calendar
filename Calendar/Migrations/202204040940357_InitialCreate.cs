namespace Calendar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reminders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        date = c.DateTime(nullable: false),
                        place = c.String(),
                        note = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Reminders");
        }
    }
}

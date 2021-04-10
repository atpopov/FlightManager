namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ValidationsMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Flights", "FromLocation", c => c.String(nullable: false));
            AlterColumn("dbo.Flights", "ToLocation", c => c.String(nullable: false));
            AlterColumn("dbo.Flights", "AirplaneType", c => c.String(nullable: false));
            AlterColumn("dbo.Flights", "AirplaneId", c => c.String(nullable: false));
            AlterColumn("dbo.Flights", "PilotName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Flights", "PilotName", c => c.String());
            AlterColumn("dbo.Flights", "AirplaneId", c => c.String());
            AlterColumn("dbo.Flights", "AirplaneType", c => c.String());
            AlterColumn("dbo.Flights", "ToLocation", c => c.String());
            AlterColumn("dbo.Flights", "FromLocation", c => c.String());
        }
    }
}

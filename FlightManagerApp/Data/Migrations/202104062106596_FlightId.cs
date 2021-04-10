namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FlightId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "FlightId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reservations", "FlightId");
        }
    }
}

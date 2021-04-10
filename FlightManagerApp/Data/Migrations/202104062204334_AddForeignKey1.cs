namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKey1 : DbMigration
    {
        public override void Up()
        {
            AddForeignKey("dbo.Reservations", "FlightId", "dbo.Flights", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "FlightId", "dbo.Flights");
        }
    }
}

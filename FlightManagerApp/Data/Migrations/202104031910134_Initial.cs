namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Flights",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FromLocation = c.String(),
                        ToLocation = c.String(),
                        DepartureTime = c.DateTime(nullable: false),
                        ArrivalTime = c.DateTime(nullable: false),
                        AirplaneType = c.String(),
                        AirplaneId = c.String(),
                        PilotName = c.String(),
                        UnusedPlacesEconomy = c.Int(nullable: false),
                        UnusedPlacesBusiness = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Flights");
        }
    }
}

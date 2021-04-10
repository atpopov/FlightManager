namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Username = c.String(),
                    Password = c.String(),
                    FirstName = c.String(),
                    LastName = c.String(),
                    PersonalId = c.String(),
                    AirplaneId = c.String(),
                    Address = c.String(),
                    MobileNumber = c.String(),
                    Role = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Reservations",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    FirstName = c.String(),
                    MiddleName = c.String(),
                    LastName = c.String(),
                    PersonalId = c.String(),
                    MobileNumber = c.String(),
                    Nationality = c.String(),
                    TicketType = c.String(),
                })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Reservations");
        }
    }
}

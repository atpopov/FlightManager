namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmailColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reservations", "Email");
        }
    }
}

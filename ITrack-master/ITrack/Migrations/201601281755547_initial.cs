namespace ITrack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompaniesId = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                    })
                .PrimaryKey(t => t.CompaniesId);
            
            CreateTable(
                "dbo.Inventories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        SKU = c.String(),
                        Company = c.String(),
                        Home = c.Boolean(nullable: false),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Client = c.String(),
                        Company = c.String(),
                        Details = c.String(),
                        TimeRequest = c.String(),
                        Priority = c.String(),
                        Employee = c.String(),
                        Completed = c.Boolean(nullable: false),
                        TimeCompleted = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Trackers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TicketID = c.String(),
                        Details = c.String(),
                        TimeOut = c.String(),
                        Location = c.String(),
                        Employee = c.String(),
                        ReturnDate = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Name = c.String(),
                        Company = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Trackers");
            DropTable("dbo.Tickets");
            DropTable("dbo.Inventories");
            DropTable("dbo.Companies");
        }
    }
}

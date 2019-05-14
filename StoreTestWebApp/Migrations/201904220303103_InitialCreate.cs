namespace StoreTestWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.Clients",
            //    c => new
            //    {
            //        ClientId = c.Int(nullable: false, identity: true),
            //        FirstName = c.String(nullable: false),
            //        LastName = c.String(nullable: false),
            //    })
            //    .PrimaryKey(t => t.ClientId);

            //CreateTable(
            //    "dbo.Orders",
            //    c => new
            //    {
            //        OrderID = c.Int(nullable: false, identity: true),
            //        Date = c.DateTime(nullable: false),
            //        Client_ClientId = c.Int(),
            //    })
            //    .PrimaryKey(t => t.OrderID)
            //    .ForeignKey("dbo.Clients", t => t.Client_ClientId)
            //    .Index(t => t.Client_ClientId);

            //CreateTable(
            //    "dbo.Products",
            //    c => new
            //    {
            //        ProductId = c.Int(nullable: false, identity: true),
            //        Name = c.String(nullable: false),
            //        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
            //        Order_OrderID = c.Int(),
            //    })
            //    .PrimaryKey(t => t.ProductId)
            //    .ForeignKey("dbo.Orders", t => t.Order_OrderID)
            //    .Index(t => t.Order_OrderID);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Products", "Order_OrderID", "dbo.Orders");
            DropColumn("dbo.Orders", "Product_ProductId");
            DropForeignKey("dbo.Orders", "Client_ClientId", "dbo.Clients");
            DropIndex("dbo.Products", new[] { "Order_OrderID" });
            DropIndex("dbo.Orders", new[] { "Client_ClientId" });
            DropTable("dbo.Products");
            DropTable("dbo.Orders");
            DropTable("dbo.Clients");
        }
    }
}

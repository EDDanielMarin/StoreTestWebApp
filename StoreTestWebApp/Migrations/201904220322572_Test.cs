namespace StoreTestWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Order_OrderID", "dbo.Orders");
            DropIndex("dbo.Products", new[] { "Order_OrderID" });
            CreateTable(
                "dbo.ProductOrders",
                c => new
                {
                    Product_ProductId = c.Int(nullable: false),
                    Order_OrderID = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.Product_ProductId, t.Order_OrderID })
                .ForeignKey("dbo.Products", t => t.Product_ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.Order_OrderID, cascadeDelete: true);

            DropColumn("dbo.Products", "Order_OrderID");
            DropColumn("dbo.Products", "Product_ProductId");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.Products", "Order_OrderID", c => c.Int());
            //DropForeignKey("dbo.ProductOrders", "Order_OrderID", "dbo.Orders");
            //DropForeignKey("dbo.ProductOrders", "Product_ProductId", "dbo.Products");
            //DropIndex("dbo.ProductOrders", new[] { "Order_OrderID" });
            //DropIndex("dbo.ProductOrders", new[] { "Product_ProductId" });
            DropTable("dbo.ProductOrders");
            //CreateIndex("dbo.Products", "Order_OrderID");
            //AddForeignKey("dbo.Products", "Order_OrderID", "dbo.Orders", "OrderID");
        }
    }
}

namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecMigr : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DicClients",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Secname = c.String(),
                        Gender = c.Int(nullable: false),
                        Phone = c.String(),
                        Email = c.String(),
                        Age = c.Int(nullable: false),
                        Photo = c.Binary(),
                    })
                .PrimaryKey(t => t.ClientId);
            
            CreateTable(
                "dbo.DicGoods",
                c => new
                    {
                        GoodId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MaxValue = c.Int(nullable: false),
                        MinValue = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.GoodId);
            
            CreateTable(
                "dbo.JorOrders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        Value = c.Int(nullable: false),
                        Description = c.String(),
                        ClientId_ClientId = c.Int(),
                        GoodId_GoodId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.DicClients", t => t.ClientId_ClientId)
                .ForeignKey("dbo.DicGoods", t => t.GoodId_GoodId)
                .Index(t => t.ClientId_ClientId)
                .Index(t => t.GoodId_GoodId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JorOrders", "GoodId_GoodId", "dbo.DicGoods");
            DropForeignKey("dbo.JorOrders", "ClientId_ClientId", "dbo.DicClients");
            DropIndex("dbo.JorOrders", new[] { "GoodId_GoodId" });
            DropIndex("dbo.JorOrders", new[] { "ClientId_ClientId" });
            DropTable("dbo.JorOrders");
            DropTable("dbo.DicGoods");
            DropTable("dbo.DicClients");
        }
    }
}

namespace APIFacturacion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bills", "IdClient", "dbo.Clients");
            DropForeignKey("dbo.Products", "IdCategory", "dbo.Categories");
            DropForeignKey("dbo.Details", "IdProduct", "dbo.Products");
            DropForeignKey("dbo.Bills", "IdDetail", "dbo.Details");
            DropForeignKey("dbo.Bills", "IdPayMode", "dbo.PayModes");
            DropIndex("dbo.Bills", new[] { "IdClient" });
            DropIndex("dbo.Bills", new[] { "IdPayMode" });
            DropIndex("dbo.Bills", new[] { "IdDetail" });
            DropIndex("dbo.Details", new[] { "IdProduct" });
            DropIndex("dbo.Products", new[] { "IdCategory" });
            CreateTable(
                "dbo.Facturas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nit = c.String(),
                        ValorTotal = c.Int(nullable: false),
                        PorcentajeIVA = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Bills");
            DropTable("dbo.Clients");
            DropTable("dbo.Details");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
            DropTable("dbo.PayModes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PayModes",
                c => new
                    {
                        IdPayMode = c.Int(nullable: false, identity: true),
                        Detail = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdPayMode);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        IdCategory = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdCategory);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        IdProduct = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        IdCategory = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdProduct);
            
            CreateTable(
                "dbo.Details",
                c => new
                    {
                        IdDetail = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IdProduct = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdDetail);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        IdClient = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Direction = c.String(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        Phone = c.String(nullable: false, maxLength: 10),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdClient);
            
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        IdBill = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        IdClient = c.Int(nullable: false),
                        IdPayMode = c.Int(nullable: false),
                        IdDetail = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdBill);
            
            DropTable("dbo.Facturas");
            CreateIndex("dbo.Products", "IdCategory");
            CreateIndex("dbo.Details", "IdProduct");
            CreateIndex("dbo.Bills", "IdDetail");
            CreateIndex("dbo.Bills", "IdPayMode");
            CreateIndex("dbo.Bills", "IdClient");
            AddForeignKey("dbo.Bills", "IdPayMode", "dbo.PayModes", "IdPayMode", cascadeDelete: true);
            AddForeignKey("dbo.Bills", "IdDetail", "dbo.Details", "IdDetail", cascadeDelete: true);
            AddForeignKey("dbo.Details", "IdProduct", "dbo.Products", "IdProduct", cascadeDelete: true);
            AddForeignKey("dbo.Products", "IdCategory", "dbo.Categories", "IdCategory", cascadeDelete: true);
            AddForeignKey("dbo.Bills", "IdClient", "dbo.Clients", "IdClient", cascadeDelete: true);
        }
    }
}

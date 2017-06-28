namespace ProjetoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Livroes", "Compra_CompraID", "dbo.Compras");
            DropForeignKey("dbo.Compras", "Comprador_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Livroes", "Compra_CompraID1", "dbo.Compras");
            DropForeignKey("dbo.Compras", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Compras", new[] { "Comprador_Id" });
            DropIndex("dbo.Compras", new[] { "User_Id" });
            DropIndex("dbo.Livroes", new[] { "Compra_CompraID" });
            DropIndex("dbo.Livroes", new[] { "Compra_CompraID1" });
            DropColumn("dbo.Livroes", "Compra_CompraID");
            DropColumn("dbo.Livroes", "Compra_CompraID1");
            DropTable("dbo.Compras");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Compras",
                c => new
                    {
                        CompraID = c.Int(nullable: false, identity: true),
                        Comprador_Id = c.String(maxLength: 128),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CompraID);
            
            AddColumn("dbo.Livroes", "Compra_CompraID1", c => c.Int());
            AddColumn("dbo.Livroes", "Compra_CompraID", c => c.Int());
            CreateIndex("dbo.Livroes", "Compra_CompraID1");
            CreateIndex("dbo.Livroes", "Compra_CompraID");
            CreateIndex("dbo.Compras", "User_Id");
            CreateIndex("dbo.Compras", "Comprador_Id");
            AddForeignKey("dbo.Compras", "User_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Livroes", "Compra_CompraID1", "dbo.Compras", "CompraID");
            AddForeignKey("dbo.Compras", "Comprador_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Livroes", "Compra_CompraID", "dbo.Compras", "CompraID");
        }
    }
}

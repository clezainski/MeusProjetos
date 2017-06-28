namespace ProjetoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Compras",
                c => new
                    {
                        CompraID = c.Int(nullable: false, identity: true),
                        Comprador_Id = c.String(maxLength: 128),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CompraID)
                .ForeignKey("dbo.AspNetUsers", t => t.Comprador_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.Comprador_Id)
                .Index(t => t.User_Id);
            
            AddColumn("dbo.Livroes", "Compra_CompraID", c => c.Int());
            AddColumn("dbo.Livroes", "Compra_CompraID1", c => c.Int());
            CreateIndex("dbo.Livroes", "Compra_CompraID");
            CreateIndex("dbo.Livroes", "Compra_CompraID1");
            AddForeignKey("dbo.Livroes", "Compra_CompraID", "dbo.Compras", "CompraID");
            AddForeignKey("dbo.Livroes", "Compra_CompraID1", "dbo.Compras", "CompraID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Compras", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Livroes", "Compra_CompraID1", "dbo.Compras");
            DropForeignKey("dbo.Compras", "Comprador_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Livroes", "Compra_CompraID", "dbo.Compras");
            DropIndex("dbo.Livroes", new[] { "Compra_CompraID1" });
            DropIndex("dbo.Livroes", new[] { "Compra_CompraID" });
            DropIndex("dbo.Compras", new[] { "User_Id" });
            DropIndex("dbo.Compras", new[] { "Comprador_Id" });
            DropColumn("dbo.Livroes", "Compra_CompraID1");
            DropColumn("dbo.Livroes", "Compra_CompraID");
            DropTable("dbo.Compras");
        }
    }
}

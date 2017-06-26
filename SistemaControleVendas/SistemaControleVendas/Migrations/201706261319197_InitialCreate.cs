namespace SistemaControleVendas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cursoes",
                c => new
                    {
                        CursoID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 10),
                        Descricao = c.String(nullable: false, maxLength: 100),
                        Ativo = c.Boolean(nullable: false),
                        Usuario_UsuarioID = c.Int(),
                    })
                .PrimaryKey(t => t.CursoID)
                .ForeignKey("dbo.Usuarios", t => t.Usuario_UsuarioID)
                .Index(t => t.Usuario_UsuarioID);
            
            CreateTable(
                "dbo.Perfils",
                c => new
                    {
                        PerfilID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 10),
                        Descricao = c.String(nullable: false, maxLength: 100),
                        Admin = c.Boolean(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PerfilID);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        UsuarioID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 10),
                        Sobrenome = c.String(nullable: false, maxLength: 10),
                        Cpf = c.String(nullable: false, maxLength: 11),
                        Email = c.String(nullable: false),
                        NomeUsuario = c.String(nullable: false, maxLength: 10),
                        Senha = c.String(nullable: false),
                        ConfirmaSenha = c.String(),
                        Ativo = c.Boolean(nullable: false),
                        _Perfil_PerfilID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UsuarioID)
                .ForeignKey("dbo.Perfils", t => t._Perfil_PerfilID, cascadeDelete: true)
                .Index(t => t._Perfil_PerfilID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuarios", "_Perfil_PerfilID", "dbo.Perfils");
            DropForeignKey("dbo.Cursoes", "Usuario_UsuarioID", "dbo.Usuarios");
            DropIndex("dbo.Usuarios", new[] { "_Perfil_PerfilID" });
            DropIndex("dbo.Cursoes", new[] { "Usuario_UsuarioID" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Perfils");
            DropTable("dbo.Cursoes");
        }
    }
}

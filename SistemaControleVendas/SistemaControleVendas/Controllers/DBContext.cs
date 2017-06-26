using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BaseModels;

namespace SistemaControleVendas.Controllers
{
    public class DBContext : DbContext
    {
        public DbSet <Usuario> Usuarios { get; set; }
        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<Curso> Cursos { get; set; }
    }
}
using Aula2405_EF_MF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aula2405_EF_MF.Controllers
{
    public class CategoriasController
    {
        protected BaseDadosContainer contexto = new BaseDadosContainer();
        public void Adicionar(Categoria categoria)
        {
            if(categoria != null)
            {
                contexto.Categorias.Add(categoria);
                contexto.SaveChanges();
            }
        }

        public List<Categoria> Listar()
        {
            return contexto.Categorias.Where(c => c.Ativo == true).ToList();
        }

        public List<Categoria> ListarInativos()
        {
            return contexto.Categorias.Where(c => c.Ativo == false).ToList();
        }

        public Categoria BuscarCategoriaPorID(int id)
        {
            return contexto.Categorias.Find(id);//metodo especifico para busca por id
        }

        //Exclusão fisica (apaga registro do banco)
        //public void Excluir(Categoria categoria)
        //{
        //    contexto.Entry(categoria).State =
        //        System.Data.Entity.EntityState.Deleted;
        //    contexto.SaveChanges();
        //}

            //Exclusao logica(ativo/inativo)
            public void Excluir(Categoria categoria)
        {
            categoria.Ativo = false;
            contexto.Entry(categoria).State =
                System.Data.Entity.EntityState.Modified;
            contexto.SaveChanges();
        }

        public void Editar (Categoria categoria)
        {
            contexto.Entry(categoria).State =
                System.Data.Entity.EntityState.Modified;
            contexto.SaveChanges();
        }
    }
}
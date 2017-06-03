using Aula2405_EF_MF.Controllers;
using Aula2405_EF_MF.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aula2405_EF_MF.Views.Categorias
{
    public partial class Lista : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CategoriasController ctrl = new CategoriasController();
            List<Categoria> lista = ctrl.Listar();
            List<Categoria> listaExcluidos = ctrl.ListarInativos();

            gvCategorias.DataSource = lista.OrderBy(c => c.Nome);
            gvCategorias.DataBind();

            gvCategoriasExcluidas.DataSource = listaExcluidos;
            gvCategoriasExcluidas.DataBind();
        }
    }
}
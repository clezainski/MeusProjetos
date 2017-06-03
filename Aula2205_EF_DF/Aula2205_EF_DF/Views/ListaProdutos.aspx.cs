using Aula2205_EF_DF.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aula2205_EF_DF.Views
{
    public partial class ListaProdutos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            strConnLojaEntities context = new strConnLojaEntities();

            gdwListaProdutos.DataSource = context.Produtoes.ToList();
            gdwListaProdutos.DataBind();
        }
    }
}
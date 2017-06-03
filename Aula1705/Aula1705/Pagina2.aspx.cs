using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aula1705
{
    public partial class Pagina2 : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //int valor1ViewState = Convert.ToInt32(ViewState["Campo1"]);
            //int valor1Session = Convert.ToInt32(Session["valor1Session"]);


            //int valor2ViewState = Convert.ToInt32(ViewState["Campo2"]);
            //int valor2Session = Convert.ToInt32(Session["valor2Session"]);

            //lblDividoValor1.Text = valor1Session.ToString();

            int valor1ViewState =
                Convert.ToInt32(ViewState["Campo1"]);

            int valor1Session =
                Convert.ToInt32(Session["valor1Session"]);

            int valor2ViewState =
                Convert.ToInt32(ViewState["Campo2"]);

            int valor2Session =
                Convert.ToInt32(Session["valor2Session"]);

            lblDividoValor1.Text = valor1Session.ToString();
            lblDividoValor2.Text = valor2Session.ToString();
            lblDividoResultado.Text = (valor1Session / valor2Session).ToString();

            lblVezesValor1.Text = valor1Session.ToString();
            lblVezesValor2.Text = valor2Session.ToString();
            lblVezesResultado.Text = (valor1Session * valor2Session).ToString();            

            lblSomaValor1.Text = valor1Session.ToString();
            lblSomaValor2.Text = valor2Session.ToString();
            lblSomaResultado.Text = (valor1Session + valor2Session).ToString();

            lblMenosValor1.Text = valor1Session.ToString();
            lblMenosValor2.Text = valor2Session.ToString();
            lblMenosResultado.Text = (valor1Session - valor2Session).ToString();
        }
    }
}
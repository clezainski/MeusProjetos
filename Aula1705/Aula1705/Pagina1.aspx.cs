using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aula1705
{
    public partial class Pagina1 : System.Web.UI.Page
    {
        public int valor1
        {
            get
            {
                return Convert.ToInt32(ViewState["Campo1"]);
            }
            set
            {
                ViewState["Campo1"] = value;
            }
        }

        public int valor2
        {
            get
            {
                return Convert.ToInt32(ViewState["Campo2"]);
            }
            set
            {
                ViewState["Campo2"] = value;
            }
        }        


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                valor1 = 0;
                valor2 = 0;
            }
        }

        protected void btnMais_Click(object sender, EventArgs e)        {

            valor1 = Convert.ToInt32(txtCampo1.Text);
            valor2 = Convert.ToInt32(txtCampo2.Text);
            lblResultado.Text = "A soma é: " + (valor2 + valor1).ToString();
        }

        protected void btnIgual_Click(object sender, EventArgs e)
        {
            valor1 = Convert.ToInt32(txtCampo1.Text);
            valor2 = Convert.ToInt32(txtCampo2.Text);
            Session.Add("valor1Session", valor1);
            Session.Add("valor2Session", valor2);
            Response.Redirect("~/Pagina2.aspx");
        }
    }
}
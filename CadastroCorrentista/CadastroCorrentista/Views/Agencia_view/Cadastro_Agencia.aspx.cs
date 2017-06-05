using CadastroCorrentista.Controllers;
using CadastroCorrentista.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CadastroCorrentista.Views.Agencia_view
{
    public partial class Cadastro_Agencia : System.Web.UI.Page
    {
        Agencia agencia;
        string script;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            limpar();
        }

        private void limpar()
        {
            txtGerente.Text = string.Empty;
            txtNome.Text = string.Empty;
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            agencia = new Agencia();

            agencia.Nome = txtNome.Text;
            agencia.Gerente = txtGerente.Text;

            if (AgenciaController.Adicionar(agencia))
            {
                script = "alert(\"Sucesso!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                limpar();
            }
            else
            {
                script = "alert(\"Falhou! Agência já existe.\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
            }
            
        }
    }
}
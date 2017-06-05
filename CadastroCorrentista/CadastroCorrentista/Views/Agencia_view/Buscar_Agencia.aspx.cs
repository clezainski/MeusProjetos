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
    public partial class Buscar_Agencia : System.Web.UI.Page
    {
        private static Agencia agencia;
        string script;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
           if ((agencia= AgenciaController.BuscaDeAgenciasAtivas(txtBuscar.Text)) != null)
            {
                txtGerente.Text = agencia.Gerente;
                txtNome.Text = agencia.Nome;
                txtBuscar.Text = string.Empty;
                btnBuscar.Enabled = true;
            }
            else
            {
                script = "alert(\"Agência não encontrada!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                limpar();
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            limpar();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            agencia.Gerente = txtGerente.Text;

            if (AgenciaController.Editar(agencia))
            {
                script = "alert(\"Sucesso na edição!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                limpar();
            }
            else
            {
                script = "alert(\"Falhou na edição!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
            }
        }

        private void limpar()
        {
            txtBuscar.Text = string.Empty;
            txtGerente.Text = string.Empty;
            txtNome.Text = string.Empty;
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            if (AgenciaController.Excluir(agencia))
            {
                script = "alert(\"Excluído com sucesso!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                limpar();
            }
            else
            {
                script = "alert(\"Falhou a exclusão! Verifique se não há clientes neste agência\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
            }
        }
    }
}
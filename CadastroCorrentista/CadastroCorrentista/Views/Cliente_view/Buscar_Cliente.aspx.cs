using CadastroCorrentista.Controllers;
using CadastroCorrentista.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CadastroCorrentista.Views.Cliente_view
{
    public partial class Buscar_Cliente : System.Web.UI.Page
    {
        private static Cliente cliente;
        string script;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ddlAgencia.DataSource = AgenciaController.ListarAgencias().OrderBy(c => c.Nome);
                ddlAgencia.DataTextField = "Nome";
                ddlAgencia.DataValueField = "Id";
                ddlAgencia.DataBind();

                ddlAgencia.SelectedIndex = -1;
                ddlSexo.SelectedIndex = -1;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if ((cliente = ClienteController.BuscaDeClienteAtivos(txtBuscar.Text)) != null)
            {
                txtConta.Text = cliente.Conta;
                txtCpf.Text = cliente.Cpf;
                txtNome.Text = cliente.Nome;
                ddlSexo.SelectedIndex = ddlSexo.Items.IndexOf(ddlSexo.Items.FindByText(cliente.Sexo));
                ddlAgencia.SelectedIndex = ddlAgencia.Items.IndexOf(ddlAgencia.Items.FindByValue(cliente.AgenciaId.ToString()));

                txtBuscar.Text = string.Empty;

            }
            else
            {
                script = "alert(\"Cliente não encontrado!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                limpar();
            }
        }

        private void limpar()
        {
            txtConta.Text = string.Empty;
            txtCpf.Text = string.Empty;
            txtNome.Text = string.Empty;
            ddlAgencia.SelectedIndex = -1;
            ddlSexo.SelectedIndex = -1;

            txtBuscar.Text = string.Empty;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            limpar();
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            if (ClienteController.Excluir(cliente))
            {
                script = "alert(\"Excluído com sucesso!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                limpar();
            }
            else
            {
                script = "alert(\"Falhou a exclusão!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            cliente.Conta = txtConta.Text;
            cliente.Nome = txtNome.Text;
            cliente.Sexo = ddlSexo.SelectedValue;
            cliente.AgenciaId = AgenciaController.BuscaDeAgencia(Convert.ToInt32(ddlAgencia.SelectedValue)).Id;

            if (ClienteController.Editar(cliente))
            {
                script = "alert(\"Alterado com sucesso!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                limpar();
            }
            else
            {
                script = "alert(\"Falhou a alteração! Já há cliente com a mesma conta e agência.\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
            }
        }
    }
}
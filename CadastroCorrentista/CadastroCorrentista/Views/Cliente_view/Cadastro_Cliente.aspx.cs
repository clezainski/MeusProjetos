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
    public partial class Cadastro_Cliente : System.Web.UI.Page
    {
        Cliente cliente;
        string script;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ddlAgencia.DataSource = AgenciaController.ListarAgencias().OrderBy(c=> c.Nome);
                ddlAgencia.DataTextField = "Nome";
                ddlAgencia.DataValueField = "Nome";
                ddlAgencia.DataBind();
            }            
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            limpar();
        }

        private void limpar()
        {
            txtConta.Text = string.Empty;
            txtCpf.Text = string.Empty;
            txtNome.Text = string.Empty;
            ddlAgencia.SelectedIndex = -1;
            ddlSexo.SelectedIndex = -1;
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            cliente = new Cliente();

            cliente.Conta = txtConta.Text;
            cliente.Cpf = txtCpf.Text;
            cliente.Nome = txtNome.Text;
            cliente.Sexo = ddlSexo.SelectedValue;
            cliente.AgenciaId = AgenciaController.BuscaDeAgenciaPorNome(ddlAgencia.SelectedValue).Id;

            if (ClienteController.Adicionar(cliente))
            {
                script = "alert(\"Sucesso!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                limpar();
            }
            else
            {
                script = "alert(\"Falhou! CPF já cadastrado ou conta já existe.\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
            }            
        }
    }
}
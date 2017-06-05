<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cadastro_Agencia.aspx.cs" Inherits="CadastroCorrentista.Views.Agencia_view.Cadastro_Agencia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>

            <legend>Cadastro de Agencia</legend>

            <div class="form-group">
                <label for="lblAgencia" class="col-lg-2 control-label">Agência:</label>
                <asp:TextBox ID="txtNome" class="form-control" placeholder="Agencia" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    ControlToValidate="txtNome"
                    ErrorMessage="O número da agência é requerido."
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
                <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Integer"
                    ControlToValidate="txtNome" ErrorMessage="Insira somente números." />
            </div>

            <div class="form-group">
                <label for="lblCpf" class="col-lg-2 control-label">Gerente:</label>
                <asp:TextBox ID="txtGerente" class="form-control" placeholder="Gerente" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                    ControlToValidate="txtGerente"
                    ErrorMessage="O nome do gerente é requerido."
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
                <div class="col-lg-10 col-lg-offset-2">
                    <asp:Button ID="btnCancelar" class="btn btn-default" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                    <asp:Button ID="btnSalvar" class="btn btn-primary" runat="server" Text="Salvar" OnClick="btnSalvar_Click" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

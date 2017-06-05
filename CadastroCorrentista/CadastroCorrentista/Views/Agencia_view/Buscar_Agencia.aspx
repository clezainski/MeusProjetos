<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Buscar_Agencia.aspx.cs" Inherits="CadastroCorrentista.Views.Agencia_view.Buscar_Agencia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>

            <legend>Buscar Agência</legend>

            <div class="form-group">
                <label for="lblBuscar" class="col-lg-2 control-label">Buscar:</label>
                <asp:TextBox ID="txtBuscar" class="form-control" placeholder="Número da agência" runat="server"></asp:TextBox>
                <br />
                <div class="col-lg-10 col-lg-offset-2">
                    <asp:Button ID="btnBuscar" class="btn btn-primary" runat="server" Text="Buscar" validationgroup="Buscar" OnClick="btnBuscar_Click" />
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    validationgroup="Buscar"
                    ControlToValidate="txtBuscar"
                    ErrorMessage="O número da agência é requerido."
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
                <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Integer"
                    ControlToValidate="txtBuscar" ErrorMessage="Insira somente números." />
            </div>

            <div class="form-group">
                <label for="lblNome" class="col-lg-2 control-label">Agência:</label>
                <asp:TextBox ID="txtNome" class="form-control" placeholder="Agência" runat="server" ReadOnly="true"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                    validationgroup="InfoAgencia"
                    ControlToValidate="txtNome"
                    ErrorMessage="O número da agência é requerido."
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
                <label for="lblGerente" class="col-lg-2 control-label">Gerente:</label>
                <asp:TextBox ID="txtGerente" class="form-control" placeholder="Gerente" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                    validationgroup="InfoAgencia"
                    ControlToValidate="txtGerente"
                    ErrorMessage="O nome do gerente é requerido."
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
                <div class="col-lg-10 col-lg-offset-2">
                    <asp:Button ID="btnCancelar" class="btn btn-default" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CausesValidation="true" />
                    <asp:Button ID="btnEditar" class="btn btn-primary" runat="server" Text="Editar" validationgroup="InfoAgencia" OnClick="btnEditar_Click" />
                    <asp:Button ID="btnExcluir" class="btn btn-primary" runat="server" Text="Excluir" validationgroup="InfoAgencia" OnClick="btnExcluir_Click" />

                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

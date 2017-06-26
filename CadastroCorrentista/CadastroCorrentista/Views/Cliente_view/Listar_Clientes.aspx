<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Listar_Clientes.aspx.cs" Inherits="CadastroCorrentista.Views.Cliente_view.Listar_Clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <legend>Listar Clientes</legend>

            <div class="form-group">
            <asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataSource2">
                <AlternatingItemTemplate>
                    <tr style="background-color: #FFFFFF;color: #284775;">
                        <td>
                            <asp:Label ID="NomeLabel" runat="server" Text='<%# Eval("Nome") %>' />
                        </td>
                        <td>
                            <asp:Label ID="CpfLabel" runat="server" Text='<%# Eval("Cpf") %>' />
                        </td>
                        <td>
                            <asp:Label ID="SexoLabel" runat="server" Text='<%# Eval("Sexo") %>' />
                        </td>
                        <td>
                            <asp:Label ID="AgenciaLabel" runat="server" Text='<%# Eval("Agencia") %>' />
                        </td>
                        <td>
                            <asp:Label ID="ContaLabel" runat="server" Text='<%# Eval("Conta") %>' />
                        </td>
                        <td>
                            <asp:Label ID="GerenteLabel" runat="server" Text='<%# Eval("Gerente") %>' />
                        </td>
                    </tr>
                </AlternatingItemTemplate>
                <EditItemTemplate>
                    <tr style="background-color: #999999;">
                        <td>
                            <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                        </td>
                        <td>
                            <asp:TextBox ID="NomeTextBox" runat="server" Text='<%# Bind("Nome") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="CpfTextBox" runat="server" Text='<%# Bind("Cpf") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="SexoTextBox" runat="server" Text='<%# Bind("Sexo") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="AgenciaTextBox" runat="server" Text='<%# Bind("Agencia") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="ContaTextBox" runat="server" Text='<%# Bind("Conta") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="GerenteTextBox" runat="server" Text='<%# Bind("Gerente") %>' />
                        </td>
                    </tr>
                </EditItemTemplate>
                <EmptyDataTemplate>
                    <table runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                        <tr>
                            <td>No data was returned.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <InsertItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                        </td>
                        <td>
                            <asp:TextBox ID="NomeTextBox" runat="server" Text='<%# Bind("Nome") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="CpfTextBox" runat="server" Text='<%# Bind("Cpf") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="SexoTextBox" runat="server" Text='<%# Bind("Sexo") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="AgenciaTextBox" runat="server" Text='<%# Bind("Agencia") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="ContaTextBox" runat="server" Text='<%# Bind("Conta") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="GerenteTextBox" runat="server" Text='<%# Bind("Gerente") %>' />
                        </td>
                    </tr>
                </InsertItemTemplate>
                <ItemTemplate>
                    <tr style="background-color: #E0FFFF;color: #333333;">
                        <td>
                            <asp:Label ID="NomeLabel" runat="server" Text='<%# Eval("Nome") %>' />
                        </td>
                        <td>
                            <asp:Label ID="CpfLabel" runat="server" Text='<%# Eval("Cpf") %>' />
                        </td>
                        <td>
                            <asp:Label ID="SexoLabel" runat="server" Text='<%# Eval("Sexo") %>' />
                        </td>
                        <td>
                            <asp:Label ID="AgenciaLabel" runat="server" Text='<%# Eval("Agencia") %>' />
                        </td>
                        <td>
                            <asp:Label ID="ContaLabel" runat="server" Text='<%# Eval("Conta") %>' />
                        </td>
                        <td>
                            <asp:Label ID="GerenteLabel" runat="server" Text='<%# Eval("Gerente") %>' />
                        </td>
                    </tr>
                </ItemTemplate>
                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <td runat="server">
                                <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                                    <tr runat="server" style="background-color: #E0FFFF;color: #333333;">
                                        <th runat="server">Nome</th>
                                        <th runat="server">Cpf</th>
                                        <th runat="server">Sexo</th>
                                        <th runat="server">Agencia</th>
                                        <th runat="server">Conta</th>
                                        <th runat="server">Gerente</th>
                                    </tr>
                                    <tr id="itemPlaceholder" runat="server">
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td runat="server" style="text-align: center;background-color: #5D7B9D;font-family: Verdana, Arial, Helvetica, sans-serif;color: #FFFFFF"></td>
                        </tr>
                    </table>
                </LayoutTemplate>
                <SelectedItemTemplate>
                    <tr style="background-color: #E2DED6;font-weight: bold;color: #333333;">
                        <td>
                            <asp:Label ID="NomeLabel" runat="server" Text='<%# Eval("Nome") %>' />
                        </td>
                        <td>
                            <asp:Label ID="CpfLabel" runat="server" Text='<%# Eval("Cpf") %>' />
                        </td>
                        <td>
                            <asp:Label ID="SexoLabel" runat="server" Text='<%# Eval("Sexo") %>' />
                        </td>
                        <td>
                            <asp:Label ID="AgenciaLabel" runat="server" Text='<%# Eval("Agencia") %>' />
                        </td>
                        <td>
                            <asp:Label ID="ContaLabel" runat="server" Text='<%# Eval("Conta") %>' />
                        </td>
                        <td>
                            <asp:Label ID="GerenteLabel" runat="server" Text='<%# Eval("Gerente") %>' />
                        </td>
                    </tr>
                </SelectedItemTemplate>
            </asp:ListView>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:CadastroCorrentistaDBConnectionString %>" SelectCommand="SELECT Clientes.Nome, Clientes.Cpf, Clientes.Sexo, Agencias.Nome AS Agencia, Clientes.Conta, Agencias.Gerente FROM Agencias INNER JOIN Clientes ON Agencias.Id = Clientes.AgenciaId WHERE (Clientes.Ativo = 1) ORDER BY Clientes.Nome"></asp:SqlDataSource>
        </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

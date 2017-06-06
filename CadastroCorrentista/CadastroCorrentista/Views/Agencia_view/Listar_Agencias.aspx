<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Listar_Agencias.aspx.cs" Inherits="CadastroCorrentista.Views.Agencia_view.Listar_Agencias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>

            <legend>Listar Agências</legend>

            <div class="form-group">
                <asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataSource1">
                    <AlternatingItemTemplate>
                        <tr style="background-color: #FFFFFF;color: #284775;">
                            <td>
                                <asp:Label ID="NomeLabel" runat="server" Text='<%# Eval("Nome") %>' />
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
                                            <th runat="server">Agência</th>
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
                                <asp:Label ID="GerenteLabel" runat="server" Text='<%# Eval("Gerente") %>' />
                            </td>
                        </tr>
                    </SelectedItemTemplate>
                </asp:ListView>   
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CadastroCorrentistaDBConnectionString %>" SelectCommand="SELECT Nome, Gerente FROM Agencias WHERE (Ativo = 1) ORDER BY Nome">
                </asp:SqlDataSource>
            </div>            
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

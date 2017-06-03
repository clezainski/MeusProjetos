<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pagina1.aspx.cs" Inherits="Aula1705.Pagina1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Label ID="lblC1mpo1" runat="server" Text="Campo 1"></asp:Label>
            <asp:TextBox ID="txtCampo1" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblCampo2" runat="server" Text="Campo 2"></asp:Label>
            <asp:TextBox ID="txtCampo2" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnMais" runat="server" Text="+" OnClick="btnMais_Click"/>
            <asp:Button ID="btnIgual" runat="server" Text="=" OnClick="btnIgual_Click"/>
            <br />
            <asp:Label ID="lblResultado" runat="server" Text=""></asp:Label>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

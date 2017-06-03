<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pagina2.aspx.cs" Inherits="Aula1705.Pagina2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Label ID="lblSomaValor1" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblSoma" runat="server" Text="+"></asp:Label>
            <asp:Label ID="lblSomaValor2" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblSomaIgual" runat="server" Text="="></asp:Label>
            <asp:Label ID="lblSomaResultado" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="lblMenosValor1" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblMenos" runat="server" Text="-"></asp:Label>
            <asp:Label ID="lblMenosValor2" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblMenosIgual" runat="server" Text="="></asp:Label>
            <asp:Label ID="lblMenosResultado" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="lblDividoValor1" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblDivido" runat="server" Text="/"></asp:Label>
            <asp:Label ID="lblDividoValor2" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblDividoIgual" runat="server" Text="="></asp:Label>
            <asp:Label ID="lblDividoResultado" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="lblVezesValor1" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblVezes" runat="server" Text="x"></asp:Label>
            <asp:Label ID="lblVezesValor2" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblVezesIgual" runat="server" Text="="></asp:Label>
            <asp:Label ID="lblVezesResultado" runat="server" Text=""></asp:Label>
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

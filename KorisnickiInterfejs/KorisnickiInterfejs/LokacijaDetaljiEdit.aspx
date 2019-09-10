<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LokacijaDetaljiEdit.aspx.cs" Inherits="KorisnickiInterfejs.LokacijaDetaljiEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 304px;
            text-align: right;
        }
        .style2
        {
            width: 318px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style2">
                ZVANJE - DETALJNI PRIKAZ ZA EDITOVANJE</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="lblSifra" runat="server" Text="Sifra"></asp:Label>
            </td>
            <td class="style2">
                <asp:TextBox ID="txbSifra" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="lblNaziv" runat="server" Text="Naziv"></asp:Label>
            </td>
            <td class="style2">
                <asp:TextBox ID="txbNaziv" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style2">
                <asp:Label ID="lblStatus" runat="server" Text="STATUS"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style2">
                <asp:Button ID="btnObrisi" runat="server" onclick="Button1_Click" 
                    Text="Obrisi" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style2">
                <asp:Button ID="btnOmoguciIzmenu" runat="server" 
                    onclick="btnOmoguciIzmenu_Click" Text="Omoguci izmenu" />
                <asp:Button ID="btnSnimiIzmenu" runat="server" onclick="btnSnimiIzmenu_Click" 
                    Text="Snimi izmenu" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

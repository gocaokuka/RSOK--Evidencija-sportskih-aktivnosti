<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LokacijaUnos.aspx.cs" Inherits="KorisnickiInterfejs.LokacijaUnos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            text-align: center;
            width: 279px;
        }
        .style2
        {
            width: 261px;
            text-align: right;
        }
        .style3
        {
            width: 279px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style1">
                <b>UNOS LOKACIJE</b></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                Sifra</td>
            <td class="style3">
                <asp:TextBox ID="txbSifra" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                Naziv</td>
            <td class="style3">
                <asp:TextBox ID="txbNaziv" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                <asp:Label ID="lblStatus" runat="server" Text="STATUS"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                <asp:Button ID="btnSnimi" runat="server" onclick="btnSnimi_Click" 
                    Text="SNIMI" />
                <asp:Button ID="btnOdustani" runat="server" onclick="btnOdustani_Click" 
                    Text="ODUSTANI" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

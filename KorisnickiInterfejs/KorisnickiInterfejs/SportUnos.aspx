<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SportUnos.aspx.cs" Inherits="KorisnickiInterfejs.SportUnos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            text-align: center;
            width: 336px;
        }
        .style2
        {
            width: 275px;
            text-align: right;
        }
        .style3
        {
            width: 336px;
        }
        .style4
        {
            width: 275px;
            text-align: right;
            height: 35px;
        }
        .style5
        {
            width: 336px;
            height: 35px;
        }
        .style6
        {
            height: 35px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%; height: 107px;">
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style1">
                <strong>UNOS SPORTOVA</strong></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="lblNazivSporta" runat="server" Text="Naziv Sporta"></asp:Label>
            </td>
            <td class="style3">
                <asp:TextBox ID="txbNazivSporta" runat="server" 
                    ontextchanged="TextBox1_TextChanged" style="margin-left: 0px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                <asp:Label ID="lblDatumTreninga" runat="server" Text="Datum treninga"></asp:Label>
            </td>
            <td class="style5">
                <asp:DropDownList ID="ddlDatumTreninga" runat="server" 
                    onselectedindexchanged="ddlDatumTreninga_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td class="style6">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style5">
                <asp:Label ID="lblStatus" runat="server" Text="STATUS"></asp:Label>
            </td>
            <td class="style6">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style5">
                <asp:Button ID="btnSnimi" runat="server" onclick="Button1_Click" Text="SNIMI" />
                <asp:Button ID="btnPonisti" runat="server" onclick="btnPonisti_Click" 
                    Text="PONISTI" />
            </td>
            <td class="style6">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

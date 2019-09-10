<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LokacijaTabelaEdit.aspx.cs" Inherits="KorisnickiInterfejs.LokacjaTabelaEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 253px;
        }
        .style2
        {
            width: 251px;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%; height: 91px;">
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style2">
                SPISAK LOKACIJA ZA AZURIRANJE</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style2">
                <asp:GridView ID="gvSpisakLokacijaEdit" runat="server" Height="167px" 
                    onselectedindexchanged="gvSpisakLokacijaEdit_SelectedIndexChanged" 
                    Width="255px">
                </asp:GridView>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

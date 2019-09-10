<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LokacijaStampa.aspx.cs" Inherits="KorisnickiInterfejs.LokacijaStampa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 310px;
        }
        .style2
        {
            width: 304px;
        }
        .style3
        {
            width: 304px;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%; height: 113px;">
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style3" style="font-weight: 700">
                <asp:Label ID="lblNaslov" runat="server" Text="SPISAK LOKACIJA"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style2">
                <asp:GridView ID="gvSpisakLokacija" runat="server" Height="234px" 
                    onselectedindexchanged="GridView1_SelectedIndexChanged" 
                    style="text-align: center" Width="324px">
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

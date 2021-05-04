<%@ Page Title="" Language="C#" MasterPageFile="~/m1.Master" AutoEventWireup="true" CodeBehind="Shops.aspx.cs" Inherits="Client.Shops" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DataList ID="DataListproducts" runat="server" BackColor="White" BorderStyle="Double" CellPadding="4"  RepeatDirection="Horizontal" RepeatColumns="3" BorderColor="#336666" BorderWidth="3px" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" GridLines="Horizontal">
        <FooterStyle BackColor="White" ForeColor="#333333" />
        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
        <SelectedItemStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
        <ItemStyle BackColor="White" ForeColor="#333333" />
        <ItemTemplate>
            <table align="left" style="width: 250px; background-color: #f5f5f5; border: 1px solid #CCC;">
                <tr>
                    <td style="height: 10px;"></td>
                </tr>
                <tr>
                    <td style="height: 10px;"></td>
                </tr>
                <tr>
                    <td><span style="font-size: 16px;">storeName :<%#Eval("storeName") %></span></td>
                </tr>
                <tr>
                    <td><span style="font-size: 16px;">ownerName :<%#Eval("ownerName") %></span></td>
                </tr>
               <tr>
                    <td><span style="font-size: 16px;">sellingpolicy :<%#Eval("sellingpolicy") %></span></td>
                </tr>
                <tr>
                    <td><span style="font-size: 16px;">message :<%#Eval("message") %></span></td>
                </tr>
                <tr>
                    <td style="height: 10px;"></td>
                </tr>
                <tr>
                    <td style="height: 10px;"></td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>

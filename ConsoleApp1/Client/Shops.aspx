<%@ Page Title="" Language="C#" MasterPageFile="~/m1.Master" AutoEventWireup="true" CodeBehind="Shops.aspx.cs" Inherits="Client.Shops" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-+0n0xVW2eSR5OomGNYDnhzAbDsOXxcvSN1TPprVMTNDbiYZCxYbOOl7+AMvyTG2x" crossorigin="anonymous">
<!-- JavaScript Bundle with Popper -->
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/js/bootstrap.bundle.min.js" integrity="sha384-gtEjrD/SeCtmISkJkNUaaKMoLD0//ElJ19smozuHV6z3Iehds+3Ulb9Bn9Plx0x4" crossorigin="anonymous"></script>
<link href="styles.css" rel="Stylesheet" type="text/css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <div >
           
            <h1 style="font-family:Andalus; text-shadow:2px 2px orange;">List Of All Shops</h1><br /><br />
        </div>
      <asp:DataList ID="DataListproducts" runat="server" BackColor="White" BorderStyle="Double" CellPadding="4"  RepeatDirection="Horizontal" RepeatColumns="3" BorderColor="#336666" BorderWidth="0px" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" GridLines="Horizontal" Width="1261px" >
        <FooterStyle BackColor="White" ForeColor="#333333" />
        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
        <SelectedItemStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
        <ItemStyle BackColor="White" ForeColor="#333333" />
        <ItemTemplate>
            <table  style="width: 400px; background-color: #f5f5f5; border: 1px solid #CCC;">
                <tr>
                    <td style="height: 10px;"></td>
                </tr>
                <tr>
                    <td style="height: 10px;"></td>
                </tr>
                <tr>
                    <td><span style="font-size: 20px; font-family:Georgia; text-shadow:1px orange">Store Name : <span  style="font-size:16px; font-family:Times New Roman"><%#Eval("storeName") %></span> </span></td>
                </tr>
                <tr>
                    <td><span style="font-size: 20px;  font-family:Georgia; text-shadow:1px orange">Owner Name :<span style="font-size: 16px; font-family:Times New Roman;"><%#Eval("ownerName") %></span></span></td>
                </tr>
               <tr>
                    <td><span style="font-size: 20px;  font-family:Georgia; text-shadow:1px orange">Selling Policy :<span style="font-size: 16px; font-family:Times New Roman;"><%#Eval("sellingpolicy") %></span></span></td>
                </tr>
                <tr>
                    <td><span style="font-size: 20px;  font-family:Georgia ; text-shadow:1px orange">Message :<span style="font-size: 16px; font-family:Times New Roman"><%#Eval("message") %></span></span></td>
                </tr>
                <tr>
                    <td style="height: 10px;"></td>
                </tr>
                <tr>
                    <td style="height: 10px;"></td>
                </tr>
            </table>

            </div>

        </ItemTemplate>
    </asp:DataList>

</asp:Content>

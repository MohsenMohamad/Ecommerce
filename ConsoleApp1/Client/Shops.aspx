<%@ Page Title="" Language="C#"  AutoEventWireup="true" CodeBehind="Shops.aspx.cs" Inherits="Client.Shops" %>

 <link href="styles.css" rel="Stylesheet" type="text/css"/>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body >
    <form id="form1" runat="server">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
        <div >
              <img src="img/shopping.jpg" id="fast-shop" style="height: 140px; width: 220px"/>
            <h1>List Of All Shops</h1><br /><br />
        </div>
    
    <asp:DataList ID="DataListproducts" runat="server" BackColor="White" BorderStyle="Double" CellPadding="4"  RepeatDirection="Horizontal" RepeatColumns="3" BorderColor="#336666" BorderWidth="3px" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" GridLines="Horizontal" Width="1261px" >
        <FooterStyle BackColor="White" ForeColor="#333333" />
        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
        <SelectedItemStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
        <ItemStyle BackColor="White" ForeColor="#333333" />
        <ItemTemplate>
            <table align="left" style="width: 400px; background-color: #f5f5f5; border: 1px solid #CCC;">
                <tr>
                    <td style="height: 10px;"></td>
                </tr>
                <tr>
                    <td style="height: 10px;"></td>
                </tr>
                <tr>
                    <td><span style="font-size: 20px; font-family:bodyfont; text-shadow:1px orange">Store Name : <span  style="font-size:16px; font-family:Times New Roman"><%#Eval("storeName") %></span> </span></td>
                </tr>
                <tr>
                    <td><span style="font-size: 20px;  font-family:bodyfont; text-shadow:1px orange">Owner Name :<span style="font-size: 16px; font-family:Times New Roman;"><%#Eval("ownerName") %></span></span></td>
                </tr>
               <tr>
                    <td><span style="font-size: 20px;  font-family:bodyfont; text-shadow:1px orange">Selling Policy :<span style="font-size: 16px; font-family:Times New Roman;"><%#Eval("sellingpolicy") %></span></span></td>
                </tr>
                <tr>
                    <td><span style="font-size: 20px;  font-family:bodyfon ; text-shadow:1px orange">Message :<span style="font-size: 16px; font-family:Times New Roman"><%#Eval("message") %></span></span></td>
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

    </form>
    <p>
&nbsp;
    </p>
    <br />
    <br />
     <footer style="position:center; text-align:center">
            <p>Created by 13-A Group. © 2021</p>
        </footer>
</body>
</html>
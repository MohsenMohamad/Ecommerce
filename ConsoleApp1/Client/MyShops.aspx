﻿<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="MyShops.aspx.cs" Inherits="Client.MyShops" %>

<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-+0n0xVW2eSR5OomGNYDnhzAbDsOXxcvSN1TPprVMTNDbiYZCxYbOOl7+AMvyTG2x" crossorigin="anonymous">
<!-- JavaScript Bundle with Popper -->
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/js/bootstrap.bundle.min.js" integrity="sha384-gtEjrD/SeCtmISkJkNUaaKMoLD0//ElJ19smozuHV6z3Iehds+3Ulb9Bn9Plx0x4" crossorigin="anonymous"></script>
<link href="styles.css" rel="Stylesheet" type="text/css"/>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body >
    <form id="form1" runat="server">
         <div>
            <br />
            <asp:Label ID="Labelname" runat="server" ForeColor="DarkOrange" Font-Bold="true" Font-Underline="true"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;         
         <asp:Button ID="ButtonLogOut" Visible="false" runat="server" class="glyphicon glyphicon-log-out" Text="LogOut" Width="120px" BorderStyle="Groove" BackColor="Red"  ForeColor="White" OnClick="ButtonLogOut_Click" />
            <br />
             <img src="img/shopping.jpg" id="fast-shop" style="height: 140px; width: 220px"/>&nbsp;
                     <asp:DropDownList id="cataegoryid"
                    runat="server" 
            class="dropdown-show" aria-labelledby="dropdownMenuLink" Width="150px" BackColor="#7F7F7F" ForeColor="#FFFFFF
" Font-Names="Andalus" CssClass="ddl">
                  <asp:ListItem Selected="True" Value="White" class="dropdown-item"> shop by category </asp:ListItem>
                  <asp:ListItem Value="Silver" class="dropdown-item"> Silver </asp:ListItem>
                  <asp:ListItem Value="DarkGray" class="dropdown-item"> Dark Gray </asp:ListItem>
                  <asp:ListItem Value="Khaki" class="dropdown-item"> Khaki </asp:ListItem>
                  <asp:ListItem Value="DarkKhaki" class="dropdown-item"> Dark Khaki </asp:ListItem>
               </asp:DropDownList>
            
       
            &nbsp;&nbsp; &nbsp;
            
            <asp:TextBox ID="barSearch" runat="server" Height="24px" Width="600px" placeholder="Search for anything "></asp:TextBox>
            <asp:Button runat="server" ID="btnSearchBar"  CssClass="btn btn-primary" Text="Search" Height="34px" Width="100px" OnClick="Button1_Click" /> 
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        <asp:ImageButton ID="ImageButtoncart" src="img/cart.jpg" runat="server" CssClass="auto-style11" Height="58px" OnClick="ImageButtoncart_Click" Width="59px" />
       
            &nbsp;
            
        <div >
           
            <h1>My Shops</h1><br /><br />
        </div>
             </div>


              <div style="display:table-cell; position:center">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="HomeButton" runat="server" CssClass="auto-style7" Text="Home" Width="120px" OnClick="HomeButton_Click" />
            &nbsp;&nbsp;<asp:Button ID="Allshops" CssClass="auto-style7" runat="server" Width="120px" Text="Shops" OnClick="Allshops_Click1" />
            &nbsp; <asp:Button ID="OpenShop" CssClass="auto-style7" Width="120px" runat="server" Text="Open Shop" OnClick="OpenShop_Click1" />
            &nbsp;&nbsp;<asp:Button ID="MyShops1" CssClass="auto-style7" Width="120px" runat="server" Text="MyShops" OnClick="MyShops_Click" />
            &nbsp;&nbsp;<asp:Button ID="Notifications" CssClass="auto-style7" Width="120px" runat="server" Text="Notifications" OnClick="Notifications_Click" />
            &nbsp; <asp:Button ID="InitSystem" CssClass="auto-style7" Width="120px" runat="server" Text="InitSystem" OnClick="InitSystem_Click"/>

        </div>
          <br /><br /><br />

        <asp:DataList ID="Data_shop" OnItemCommand="Data_shop_Command" runat="server" Width="100%" OnSelectedIndexChanged="Data_shop_SelectedIndexChanged">
                                            <ItemTemplate>
                                                <table align="center" style="width: 100%; border-bottom: 1px solid #CCC">
                                                    <tr>
                                                        <td style="width: 200px;"><span style="font-size: 20px; font-family:bodyfont; text-shadow:1px orange">Shop Name: <span style="font-size:16px; font-family:Times New Roman" ><%#Eval("storeName") %></span></span></td>
                                                        <td style="width: 10px;"></td>
                                                        <td style="width: 302px">
                                                         
                                                        </td>
                                                        <td style="text-align: right;">
                                                            <asp:Button ID="btnedit" CommandArgument='<%#Eval("storeName")%>' CommandName="editshop" runat="server" Text="Edit Shop" Width="101px" Height="40px" />
                                                        </td>
                                                        <td style="text-align: right;">
                                                            <asp:Button ID="StaffInfoBtn" CommandArgument='<%#Eval("storeName")%>' CommandName="StafInfo" runat="server" Text="Staff Info" Width="101px" Height="40px" />
                                                        </td>

                                                         <td style="text-align: right;">
                                                            <asp:Button ID="ButtonClose" CommandArgument='<%#Eval("storeName")%>' CommandName="Close" runat="server" Text="Close Store" Width="101px" Height="40px" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:DataList>

      
    </form>
    <p>
&nbsp;
    </p>
    <br />
    <br />
     <br />
    <br />
     <footer style="position:center; text-align:center">
            <p>Created by 13-A Group. © 2021</p>
        </footer>
</body>
</html>

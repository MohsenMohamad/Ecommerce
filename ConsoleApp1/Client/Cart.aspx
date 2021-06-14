<%@ Page Title="" Language="C#"  AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="Client.Cart" %>

<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-+0n0xVW2eSR5OomGNYDnhzAbDsOXxcvSN1TPprVMTNDbiYZCxYbOOl7+AMvyTG2x" crossorigin="anonymous">
<!-- JavaScript Bundle with Popper -->
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/js/bootstrap.bundle.min.js" integrity="sha384-gtEjrD/SeCtmISkJkNUaaKMoLD0//ElJ19smozuHV6z3Iehds+3Ulb9Bn9Plx0x4" crossorigin="anonymous"></script>
<link href="styles.css" rel="Stylesheet" type="text/css"/>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cart Page</title>
        <style type="text/css">
        .auto-style21 {
            width: 149px;
        }
        .auto-style22 {
            width: 427px;
        }
        .auto-style24 {
            margin-left: 585px;
        }
        </style>

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
       
            &nbsp;
            
        <div >
           
            <h1>Cart</h1><br /><br />
        </div>
            
              <div style="display:table-cell; position:center">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="HomeButton" runat="server" CssClass="auto-style7" Text="Home" Width="120px" OnClick="HomeButton_Click" />
            &nbsp;&nbsp;<asp:Button ID="Allshops" CssClass="auto-style7" runat="server" Width="120px" Text="Shops" OnClick="Allshops_Click1" />
            &nbsp; <asp:Button ID="OpenShop" CssClass="auto-style7" Width="120px" runat="server" Text="Open Shop" OnClick="OpenShop_Click1" />
            &nbsp;&nbsp;<asp:Button ID="MyShops" CssClass="auto-style7" Width="120px" runat="server" Text="MyShops" OnClick="MyShops_Click" />
            &nbsp;&nbsp;<asp:Button ID="Notifications" CssClass="auto-style7" Width="120px" runat="server" Text="Notifications" OnClick="Notifications_Click" />
            &nbsp; <asp:Button ID="InitSystem" CssClass="auto-style7" Width="120px" runat="server" Text="InitSystem" OnClick="InitSystem_Click"/>

        </div>
            </div>
          <br /><br /><br />

    &nbsp;<asp:DataList ID="Data_cart" OnItemCommand="DataListCart_ItemCommand1" runat="server" Width="100%" Height="335px" OnSelectedIndexChanged="Data_cart_SelectedIndexChanged1">
                                            <ItemTemplate>
                                                <table align="center" style="width: 80%; border-bottom: 1px solid #CCC">
                                                    <tr>
                                                        <td style="width: 80px;"><span style="font-size: 22px; font-weight: 700; text-shadow:1px 1px orange"><%#Eval("productName")%></span></td>
                                                        <td style="text-align: center; width: 60px;">
                                                        <td style="width: 10px;"></td>
                                                        <td style="width: 302px">
                                                            <table align="left" class="auto-style22">
                                                                <tr>
                                                                    <td style="text-align: left;" class="auto-style21"><span style="font-size: 14px; font-weight: 700;"><%#Eval("nameShop")%></span></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="text-align: left;" class="auto-style21"><span style="font-size: 14px;">Price : <%#Eval("price") %>$</span></td>
                                                                </tr>

                                                                <tr>
                                                                    <td class="auto-style21">
                                                                         <td class="auto-style13">
                                                                            <asp:Label ID="Labelprice1" runat="server" Width="90px" Text="Qty :"></asp:Label>
                                                                        <asp:ImageButton ID="ImageButton1" ImageUrl="img/-.PNG" runat="server" CssClass="auto-style16" Height="30px" Width="30px" CommandArgument='<%#Eval("productName")+","+Eval("barcode")+","+Eval("nameShop")+","+Eval("Amount")   %>' CommandName="down_command" />
                                                                            <asp:Label ID="Label1"  runat="server" CssClass="td" Height="30px" Text="" Width="54px"><%#Eval("Amount") %></asp:Label>
                                                                        <asp:ImageButton ID="ImageButton2" ImageUrl="img/plus.PNG" runat="server" CssClass="auto-style16" Height="30px" Width="30px"  CommandArgument='<%#Eval("productName")+","+Eval("barcode")+","+Eval("nameShop")+","+Eval("Amount")   %>' CommandName="up_command" />
                                                                            
                                                                        &nbsp;</td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td style="text-align: right;">
                                                            <asp:Button ID="ButtonDelete" runat="server" Text="Remove Item" CommandArgument='<%#Eval("productName")+","+ Eval("descerption")+","+Eval("barcode")+","+Eval("catagory")+","+Eval("price")+","+Eval("nameShop")+","+Eval("Amount")  %>' CommandName="Delete_command" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:DataList>


                                
                                    <table align="center" style=" border-bottom: 1px solid #CCC" id="purchase" runat="server" >
                                        <tr>
                                            <td  >

                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                                                <asp:Label ID="LabelCreditcard" runat="server" Text="Enter Your Credit Card Number: "></asp:Label>

                                                <br />

                                            </td>
                                            <td >

                                                <asp:TextBox ID="TextBoxCreditcard" runat="server" Height="16px" Width="263px"></asp:TextBox>

                                            </td>
                                            <td  >

                                                <asp:Label ID="Labelerrorcreditcard" runat="server" Text="credit card number is null"></asp:Label>

                                            </td>
                                        </tr>
                                         <tr>
                                            <td >

                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                                                <asp:Label ID="Labeladdress" runat="server" Text="Enter your address : "></asp:Label>

                                                <br />

                                            </td>
                                            <td >

                                                <asp:TextBox ID="TextBoxaddress" runat="server" Height="16px" Width="263px"></asp:TextBox>

                                            </td>
                                             <td >

                                                 <asp:Label ID="Labelerroraddress" runat="server" Text="address is null"></asp:Label>

                                             </td>
                                        </tr>
                                        <tr>
                                            <td >

                                                <br />

                                                <asp:Button ID="Button3" runat="server" Text="Buy Now" Width="92px" CssClass="auto-style24" OnClick="Button3_Click" />

                                                <br />

                                            </td>
                                        </tr>
                                                                                
                                    </table>
                     <br /><br /><br /><br />
                                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

            <img src="img/paycard.jfif" id="visa" style="height: 60px; width: 500px; position:center" runat="server"/>&nbsp;<br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <img src="img/delivery.jpg" id="delivery" style="height: 100px; width: 100px; position:center" runat="server"/>&nbsp;
      
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


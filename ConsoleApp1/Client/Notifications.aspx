<%@ Page Title="" Language="C#"  AutoEventWireup="true" CodeBehind="Notifications.aspx.cs" Inherits="Client.Notifications" %>

<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-+0n0xVW2eSR5OomGNYDnhzAbDsOXxcvSN1TPprVMTNDbiYZCxYbOOl7+AMvyTG2x" crossorigin="anonymous">
<!-- JavaScript Bundle with Popper -->
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/js/bootstrap.bundle.min.js" integrity="sha384-gtEjrD/SeCtmISkJkNUaaKMoLD0//ElJ19smozuHV6z3Iehds+3Ulb9Bn9Plx0x4" crossorigin="anonymous"></script>
<link href="styles.css" rel="Stylesheet" type="text/css"/>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>notifications page</title>
</head>
<body >
    <form id="form1" runat="server">

            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
        <div >
              <img src="img/shopping.jpg" id="fast-shop" style="height: 140px; width: 220px"/>
            <h1>Notifications</h1><br /><br />
        </div>
    <asp:DataList ID="Data_cart" runat="server" Width="100%" OnSelectedIndexChanged="Data_cart_SelectedIndexChanged">
                                            <ItemTemplate>
                                                <table align="center" style="width: 100%; border-bottom: 1px solid #CCC; ">
                                                    <tr>
                                                        <td style="text-align: center; width: 60px;">
                                                        <td style="width: 10px;"></td>
                                                        <td style="width: 302px">
                                                            <table align="left" >
                                                                <tr>
                                                                   
                                                                    <td style="text-align: left;"> <img src="img/notification.png" id="fast-shop" style="height: 80px; width:80px"/><br /><span style="font-size: 14px; font-weight: 700; text-shadow:1px 1px red">MSG Number : </span><span><%#Eval("id")%></span></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="text-align: left;"><span style="font-size: 14px; font-weight: 700; text-shadow:1px 1px red ">Message : </span><span><%#Eval("msg") %></span></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td style="text-align: right;">
                                                        </td>
                                                    </tr>
                                                </table>
                                              
                                            </ItemTemplate>
                                        </asp:DataList>
        <br /><br /><br />
           <asp:Button ID="OffersButton" runat="server" Text="Offers" CssClass="auto-style19" Width="98px" OnClick="OffersButton_Click" />                                                       
  

              
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

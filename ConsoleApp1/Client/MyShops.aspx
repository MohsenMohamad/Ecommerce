<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="MyShops.aspx.cs" Inherits="Client.MyShops" %>

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
         <br />
        <div >
              <img src="img/shopping.jpg" id="fast-shop" style="height: 140px; width: 220px"/>
            <h1>My Shops</h1><br /><br /><br />
        </div>
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
            <p>Created by Yara Ahmad. © 2021</p>
        </footer>
</body>
</html>

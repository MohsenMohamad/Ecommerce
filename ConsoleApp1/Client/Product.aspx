<%@ Page Title="" Language="C#"  AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="Client.Product" %>

<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-+0n0xVW2eSR5OomGNYDnhzAbDsOXxcvSN1TPprVMTNDbiYZCxYbOOl7+AMvyTG2x" crossorigin="anonymous">
<!-- JavaScript Bundle with Popper -->
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/js/bootstrap.bundle.min.js" integrity="sha384-gtEjrD/SeCtmISkJkNUaaKMoLD0//ElJ19smozuHV6z3Iehds+3Ulb9Bn9Plx0x4" crossorigin="anonymous"></script>
<link href="styles.css" rel="Stylesheet" type="text/css"/>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Product Page</title>
</head>
<body >
    <form id="form1" runat="server">

            <img src="img/tshirt1.jfif" widh="300px" height="200px"/>
            <table style="position:center; justify-content:center">
       

        <tr>
            <td >
                            <asp:Label ID="LabelproductName" runat="server" Text="Product Name : " text-shadow=" 2px 2px orange" Font-Bold="true"></asp:Label>
                        &nbsp;<br />
            </td>
            <td style="width: 152px" >
                            <asp:Label ID="LabelproductName0" runat="server"></asp:Label>
                        </td>
        </tr>
        <tr>
            <td>
                            <asp:Label ID="Labeldescription" runat="server" Text="Description : " text-shadow=" 2px 2px orange" Font-Bold="true"></asp:Label>
                            <br />
                        </td>
            <td style="width: 152px">
                            <asp:Label ID="Labeldescription0" runat="server"></asp:Label>
                        </td>
        </tr>
        <tr>
            <td >
                            <asp:Label ID="Labelbarcode" runat="server" Text="Barcode : " text-shadow=" 2px 2px orange" Font-Bold="true"></asp:Label>
                            <br />
                        </td>
            <td style="width: 152px" >
                            <asp:Label ID="Labelbarcode0" runat="server"></asp:Label>
                        </td>
        </tr>
        <tr>
            <td>
                            <asp:Label ID="Labelcategories" runat="server" Text="Category : " text-shadow=" 2px 2px orange" Font-Bold="true"></asp:Label>
                            <br />
                        </td>
            <td style="width: 152px" >
                            <asp:Label ID="Labelcategories0" runat="server"></asp:Label>
                        </td>
        </tr>
        <tr>
            <td >
                            <asp:Label ID="LabelnameShop" runat="server" Text="Shop Name: " text-shadow=" 2px 2px orange" Font-Bold="true"></asp:Label>
                            <br />
                        </td>
            <td style="width: 152px">
                            <asp:Label ID="LabelnameShop0" runat="server"></asp:Label>
                        </td>
        </tr>
        <tr>
            <td>
                            <asp:Label ID="Labelprice" runat="server" Text="Price: " text-shadow=" 2px 2px orange" Font-Bold="true"></asp:Label>
                            <br />
                        </td>
            <td style="width: 152px">
                            <asp:Label ID="Labelprice0" runat="server"></asp:Label>
                        </td>
        </tr>
        <tr>
            <td style="height: 64px" >
                            <asp:Label ID="Labelprice1" runat="server" Width="90px" Text="Qty :" text-shadow=" 2px 2px orange" Font-Bold="true"></asp:Label>
                        <asp:ImageButton ID="ImageButton1" ImageUrl="img/-.PNG" runat="server" CssClass="auto-style16" Height="30px" Width="30px" OnClick="ImageButton1_Click" />
                            <asp:Label ID="Label1"  runat="server" CssClass="td" Height="30px" Text="0" Width="54px"></asp:Label>
                        <asp:ImageButton ID="ImageButton2" ImageUrl="img/plus.PNG" runat="server" CssClass="auto-style16" Height="30px" Width="30px" OnClick="ImageButton2_Click" />
                            <table class="auto-style5">
                                <tr>
                                    <td class="auto-style24">
                                        &nbsp;</td>
                                    <td class="auto-style24" >
                                        &nbsp;</td>
                                    <td class="auto-style23">
                                        &nbsp;</td>
                                </tr>
                            </table>
            </td>
            <td style="height: 64px; width: 152px">
                <asp:Button ID="Button3" runat="server" Height="45px" OnClick="Button3_Click" Text="Make Bid" Width="147px" />
            </td>
        </tr>
        <tr>
            <td>
  <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" ><img src="img/add_to_cart.PNG" style="width: auto; height: auto;" /></asp:LinkButton>
            </td>
        </tr>
    </table>
            &nbsp;&nbsp;&nbsp;&nbsp;

        <br />&nbsp; <br />
    </form>
    <p>
&nbsp;
    </p>
    <br />
    <br />
     <footer style="position:center; text-align:center">
            <p>Created by 13-A Group. © 2021 13-A Group. © 2021</p>
        </footer>
</body>
</html>

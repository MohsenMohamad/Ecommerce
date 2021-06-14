<%@ Page Title="" Language="C#" MasterPageFile="~/m1.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="Client.Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-+0n0xVW2eSR5OomGNYDnhzAbDsOXxcvSN1TPprVMTNDbiYZCxYbOOl7+AMvyTG2x" crossorigin="anonymous">
<!-- JavaScript Bundle with Popper -->
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/js/bootstrap.bundle.min.js" integrity="sha384-gtEjrD/SeCtmISkJkNUaaKMoLD0//ElJ19smozuHV6z3Iehds+3Ulb9Bn9Plx0x4" crossorigin="anonymous"></script>
<link href="styles.css" rel="Stylesheet" type="text/css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-+0n0xVW2eSR5OomGNYDnhzAbDsOXxcvSN1TPprVMTNDbiYZCxYbOOl7+AMvyTG2x" crossorigin="anonymous">
<!-- JavaScript Bundle with Popper -->
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/js/bootstrap.bundle.min.js" integrity="sha384-gtEjrD/SeCtmISkJkNUaaKMoLD0//ElJ19smozuHV6z3Iehds+3Ulb9Bn9Plx0x4" crossorigin="anonymous"></script>
<link href="styles.css" rel="Stylesheet" type="text/css"/>
    <table class="auto-style5">
        <tr>
            <td class="auto-style14">
                            &nbsp;</td>
            <td class="auto-style15">&nbsp;</td>
            <td class="auto-style13">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style14">
                            <asp:Label ID="LabelproductName" runat="server" Text="productName : "></asp:Label>
                        </td>
            <td class="auto-style15">
                            <asp:Label ID="LabelproductName0" runat="server"></asp:Label>
                        </td>
            <td class="auto-style13">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style14">
                            <asp:Label ID="Labeldescription" runat="server" Text="description : "></asp:Label>
                        </td>
            <td class="auto-style15">
                            <asp:Label ID="Labeldescription0" runat="server"></asp:Label>
                        </td>
            <td class="auto-style13">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style14">
                            <asp:Label ID="Labelbarcode" runat="server" Text="barcode : "></asp:Label>
                        </td>
            <td class="auto-style15">
                            <asp:Label ID="Labelbarcode0" runat="server"></asp:Label>
                        </td>
            <td class="auto-style13">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style14">
                            <asp:Label ID="Labelcategories" runat="server" Text="categories : "></asp:Label>
                        </td>
            <td class="auto-style15">
                            <asp:Label ID="Labelcategories0" runat="server"></asp:Label>
                        </td>
            <td class="auto-style13">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style14">
                            <asp:Label ID="LabelnameShop" runat="server" Text="nameShop : "></asp:Label>
                        </td>
            <td class="auto-style15">
                            <asp:Label ID="LabelnameShop0" runat="server"></asp:Label>
                        </td>
            <td class="auto-style13">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style14">
                            <asp:Label ID="Labelprice" runat="server" Text="price : "></asp:Label>
                        </td>
            <td class="auto-style15">
                            <asp:Label ID="Labelprice0" runat="server"></asp:Label>
                        </td>
            <td class="auto-style13">&nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style14">
                            &nbsp;</td>
            <td class="auto-style15">&nbsp;</td>
            <td class="auto-style13">
                            <asp:Label ID="Labelprice1" runat="server" Width="90px" Text="Qty :"></asp:Label>
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
            <td>
                <asp:Button ID="Button3" runat="server" Height="45px" OnClick="Button3_Click" Text="Make Bid" Width="147px" />
            </td>
        </tr>
        <tr>
            <td class="auto-style14">&nbsp;</td>
            <td class="auto-style15">&nbsp;</td>
            <td class="auto-style13">&nbsp;</td>
            <td>
  <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" ><img src="img/add_to_cart.PNG" style="width: auto; height: auto;" /></asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Content>

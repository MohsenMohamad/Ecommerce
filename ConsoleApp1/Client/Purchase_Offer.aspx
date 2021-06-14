<%@ Page Title="" Language="C#" MasterPageFile="~/m1.Master" AutoEventWireup="true" CodeBehind="Purchase_Offer.aspx.cs" Inherits="Client.Purchase_Offer" %>
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
    <table style="margin-left:400px" >
        <tr>
            <td style="width: 164px">
                            &nbsp;</td>
            <td class="auto-style20" style="width: 222px">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 164px" >
                            <asp:Label ID="LabelproductName" runat="server" Text="Product Name : "></asp:Label>
                        </td>
            <td style="width: 222px">
                            <asp:Label ID="LabelproductName0" runat="server"></asp:Label>
                        </td>
        </tr>
        <tr>
            <td style="width: 164px">
                            <asp:Label ID="Labeldescription" runat="server" Text="Description : "></asp:Label>
                        </td>
            <td style="width: 222px">
                            <asp:Label ID="Labeldescription0" runat="server"></asp:Label>
                        </td>
        </tr>
        <tr>
            <td style="width: 164px">
                            <asp:Label ID="Labelbarcode" runat="server" Text="Barcode : "></asp:Label>
                        </td>
            <td style="width: 222px" >
                            <asp:Label ID="Labelbarcode0" runat="server"></asp:Label>
                        </td>
        </tr>
        <tr>
            <td style="width: 164px" >
                            <asp:Label ID="Labelcategories" runat="server" Text="Categories : "></asp:Label>
                        </td>
            <td style="width: 222px" >
                            <asp:Label ID="Labelcategories0" runat="server"></asp:Label>
                        </td>
        </tr>
        <tr>
            <td style="width: 164px" >
                            <asp:Label ID="LabelnameShop" runat="server" Text="Shop Name : "></asp:Label>
                        </td>
            <td style="width: 222px">
                            <asp:Label ID="LabelnameShop0" runat="server"></asp:Label>
                        </td>
        </tr>
        <tr>
            <td style="width: 164px" >
                            <asp:Label ID="Labelprice" runat="server" Text="Price : "></asp:Label>
                        </td>
            <td style="width: 222px">
                            <asp:Label ID="Labelprice0" runat="server"></asp:Label>
                        </td>
        </tr>
        <tr>
            <td style="height: 62px; width: 164px" >
                            <asp:Label ID="LabelSuggested" runat="server" Text="Suggested Price : "></asp:Label>
                        </td>
            <td style="height: 62px; width: 222px" >
                <asp:TextBox ID="TextBoxSuggested" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 164px" >
                            <asp:Label ID="Labelprice1" runat="server" Text="Qty :" Width="90px"></asp:Label>
                        </td>
            <td style="width: 222px" >
                <asp:ImageButton ID="ImageButton1" runat="server" CssClass="auto-style16" Height="30px" ImageUrl="img/-.PNG" OnClick="ImageButton1_Click" Width="30px" />
                <asp:Label ID="Label1" runat="server" CssClass="td" Height="30px" Text="0" Width="54px"></asp:Label>
                <asp:ImageButton ID="ImageButton2" runat="server" CssClass="auto-style16" Height="30px" ImageUrl="img/plus.PNG" OnClick="ImageButton2_Click" Width="30px" />
            </td>
            <td >
                &nbsp;</td>
            <td>
            </td>
        </tr>
        <tr>

       
        <td>
            
                <br />
                <asp:Button ID="Button3" runat="server" Height="42px" OnClick="Button3_Click" Text="Make Suggestion" Width="173px" />
            </td> </tr>
    </table>
</asp:Content>

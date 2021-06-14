<%@ Page Title="" Language="C#" MasterPageFile="~/m1.Master" AutoEventWireup="true" CodeBehind="CounterOffer.aspx.cs" Inherits="Client.CounterOffer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-+0n0xVW2eSR5OomGNYDnhzAbDsOXxcvSN1TPprVMTNDbiYZCxYbOOl7+AMvyTG2x" crossorigin="anonymous">
<!-- JavaScript Bundle with Popper -->
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/js/bootstrap.bundle.min.js" integrity="sha384-gtEjrD/SeCtmISkJkNUaaKMoLD0//ElJ19smozuHV6z3Iehds+3Ulb9Bn9Plx0x4" crossorigin="anonymous"></script>
<link href="styles.css" rel="Stylesheet" type="text/css"/>
    
    <table class="auto-style5">
        <tr>
            <td class="auto-style19">
                            &nbsp;</td>
            <td class="auto-style20">&nbsp;</td>
            <td class="auto-style13">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style19">
                            <asp:Label ID="Labelbarcode" runat="server" Text="barcode : "></asp:Label>
                        </td>
            <td class="auto-style20">
                            <asp:Label ID="Labelbarcode0" runat="server"></asp:Label>
                        </td>
            <td class="auto-style13">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style19">
                            <asp:Label ID="LabelnameShop" runat="server" Text="nameShop : "></asp:Label>
                        </td>
            <td class="auto-style20">
                            <asp:Label ID="LabelnameShop0" runat="server"></asp:Label>
                        </td>
            <td class="auto-style13">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style19">
                            <asp:Label ID="Labelprice" runat="server" Text="price : "></asp:Label>
                        </td>
            <td class="auto-style20">
                            <asp:Label ID="Labelprice0" runat="server"></asp:Label>
                        </td>
            <td class="auto-style13">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style19">
                            &nbsp;</td>
            <td class="auto-style20">
                            &nbsp;</td>
            <td class="auto-style13">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style19">
                            &nbsp;</td>
            <td class="auto-style20">
                            &nbsp;</td>
            <td class="auto-style13">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style19">
                            &nbsp;</td>
            <td class="auto-style20">
                            &nbsp;</td>
            <td class="auto-style13">&nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style19">
                            <asp:Label ID="LabelSuggested" runat="server" Text="Suggested price : "></asp:Label>
                        </td>
            <td class="auto-style20">
                <asp:TextBox ID="TextBoxSuggested" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style13">
                        
                            
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
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style19">
                            <asp:Label ID="Labelprice1" runat="server" Text="Qty :" Width="90px"></asp:Label>
                        </td>
            <td class="auto-style20">
                <asp:ImageButton ID="ImageButton1" runat="server" CssClass="auto-style16" Height="30px" ImageUrl="img/-.PNG" OnClick="ImageButton1_Click" Width="30px" />
                <asp:Label ID="Label1" runat="server" CssClass="td" Height="30px" Text="0" Width="54px"></asp:Label>
                <asp:ImageButton ID="ImageButton2" runat="server" CssClass="auto-style16" Height="30px" ImageUrl="img/plus.PNG" OnClick="ImageButton2_Click" Width="30px" />
            </td>
            <td class="auto-style13">
                <asp:Button ID="Button3" runat="server" Height="42px" OnClick="Button3_Click" Text="Counter Offer" Width="176px" />
            </td>
            <td>
            </td>
        </tr>
    </table>

</asp:Content>

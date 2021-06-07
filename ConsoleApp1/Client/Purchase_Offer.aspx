<%@ Page Title="" Language="C#" MasterPageFile="~/m1.Master" AutoEventWireup="true" CodeBehind="Purchase_Offer.aspx.cs" Inherits="Client.Purchase_Offer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style19 {
            margin-left: 0;
            width: 166px;
        }
        .auto-style20 {
            width: 217px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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
                            <asp:Label ID="LabelproductName" runat="server" Text="productName : "></asp:Label>
                        </td>
            <td class="auto-style20">
                            <asp:Label ID="LabelproductName0" runat="server"></asp:Label>
                        </td>
            <td class="auto-style13">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style19">
                            <asp:Label ID="Labeldescription" runat="server" Text="description : "></asp:Label>
                        </td>
            <td class="auto-style20">
                            <asp:Label ID="Labeldescription0" runat="server"></asp:Label>
                        </td>
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
                            <asp:Label ID="Labelcategories" runat="server" Text="categories : "></asp:Label>
                        </td>
            <td class="auto-style20">
                            <asp:Label ID="Labelcategories0" runat="server"></asp:Label>
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
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style19">
                            &nbsp;</td>
            <td class="auto-style20">&nbsp;</td>
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
                            <asp:Label ID="LabelSuggested" runat="server" Text="Suggested price : "></asp:Label>
                        </td>
            <td class="auto-style20">
                <asp:TextBox ID="TextBoxSuggested" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style13">
                <asp:Button ID="Button3" runat="server" Height="42px" OnClick="Button3_Click" Text="Make Suggestion" Width="176px" />
            </td>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>

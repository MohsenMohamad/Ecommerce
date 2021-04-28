<%@ Page Title="" Language="C#" MasterPageFile="~/m1.Master" AutoEventWireup="true" CodeBehind="EditShop.aspx.cs" Inherits="Client.EditShop" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style13 {
            width: 165px;
        }
        .auto-style14 {
            width: 272px;
        }
        .auto-style15 {
            width: 698px;
        }
        .auto-style16 {
            width: 430px;
        }
        .auto-style17 {
            width: 246px;
        }
        .auto-style18 {
            width: 243px;
        }
        .auto-style19 {
            width: 245px;
        }
        .auto-style20 {
            width: 246px;
            height: 27px;
        }
        .auto-style21 {
            height: 27px;
        }
        .auto-style22 {
            width: 430px;
            height: 27px;
        }
        .addstylee {
            background-color: limegreen;
        }
        .removestylee{
             background-color:red ;
        }
        .btnsuccess {
            background: #1F60F0; 
            color: #eee;

        }
        .btnsuccesshover {
            background: #111; 
            color: #eee; 

        }
        .pgalogin {
background: none repeat scroll 0 0 #2EA2CC;
border-color: #0074A2;
box-shadow: 0 1px 0 rgba(120, 200, 230, 0.5) inset, 0 1px 0 rgba(0, 0, 0, 0.15);
color: #FFFFFF;
text-decoration: none;
text-align: center;
vertical-align: middle;
border-radius: 3px;
padding: 4px;
height: 27px;
font-size: 14px;
margin-bottom: 16px;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <table class="auto-style5">
        <tr>
            <td class="auto-style15">
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack ="true " OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                      <asp:ListItem Enabled="true" Text="Select" Value="-1"></asp:ListItem>
                                                <asp:ListItem Text="Add New Item" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Add New Manager" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="Add New Owner" Value="3"></asp:ListItem>
                                                <asp:ListItem Text="Fire Manager" Value="4"></asp:ListItem>
                                                <asp:ListItem Text="Fire Owner" Value="4"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style15">
                <table id="table1"  runat="server"  class="auto-style5">
                    <tr>
                        <td class="auto-style13">
                <asp:Label ID="Label3" runat="server" Text="Add item"></asp:Label>
                        </td>
                        <td class="auto-style14">
                            &nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style13">
                            <asp:Label ID="Labelbarcode" runat="server" Text="barcode : "></asp:Label>
                        </td>
                        <td class="auto-style14">
                            <asp:TextBox ID="TextBoxbarcode" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Labelerrorbarcode" runat="server" Text="the barcode is Existing 
                                change the barcode"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style13">
                            <asp:Label ID="LabelproductName" runat="server" Text="productName : "></asp:Label>
                        </td>
                        <td class="auto-style14">
                            <asp:TextBox ID="TextBoxproductName" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style13">
                            <asp:Label ID="Labeldescription" runat="server" Text="description : "></asp:Label>
                        </td>
                        <td class="auto-style14">
                            <asp:TextBox ID="TextBoxdescription" runat="server"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style13">
                            <asp:Label ID="Labelprice" runat="server" Text="price : "></asp:Label>
                        </td>
                        <td class="auto-style14">
                            <asp:TextBox ID="TextBoxprice" runat="server"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style13">
                            <asp:Label ID="Labelcategories" runat="server" Text="categories : "></asp:Label>
                        </td>
                        <td class="auto-style14">
                            <asp:TextBox ID="TextBoxcategories" runat="server"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style13">Amount : </td>
                        <td class="auto-style14">
                            <asp:TextBox ID="TextBoxAmount" runat="server"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style13">&nbsp;</td>
                        <td class="auto-style14">
                            <asp:Button ID="ButtonAdd" CssClass="addstylee" runat="server" Text="Add" OnClick="ButtonAdd_Click" Height="39px" Width="90px" />
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table class="auto-style5" id="table2"  runat="server">
        <tr>
            <td class="auto-style17">
                Add New Manager</td>
            <td>&nbsp;</td>
            <td class="auto-style16">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style17">
                <asp:Label ID="Labelmanagername" runat="server" Text="Choose UserName : "></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DropDownList2" runat="server">
                </asp:DropDownList>
            </td>
            <td class="auto-style16">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style17">&nbsp;</td>
            <td>&nbsp;</td>
            <td class="auto-style16">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style17">&nbsp;</td>
            <td>
                <asp:Button ID="Buttonaddmanager" CssClass="addstylee" runat="server" Text="Add" OnClick="Buttonaddmanager_Click" Height="37px" Width="68px" />
            </td>
            <td class="auto-style16">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style20"></td>
            <td class="auto-style21"></td>
            <td class="auto-style22"></td>
        </tr>
        <tr>
            <td class="auto-style17">&nbsp;</td>
            <td>&nbsp;</td>
            <td class="auto-style16">&nbsp;</td>
        </tr>
    </table>
    <td>
                        </td>
    <table class="auto-style5" id="table3"  runat="server">
        <tr>
            <td class="auto-style18">
                <asp:Label ID="Label2" runat="server" Text="Add New Owner"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td class="auto-style16">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style18">Choose UserName : </td>
            <td>
                <asp:DropDownList ID="DropDownList3" runat="server">
                </asp:DropDownList>
            </td>
            <td class="auto-style16">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style18">&nbsp;</td>
            <td>&nbsp;</td>
            <td class="auto-style16">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style18">&nbsp;</td>
            <td>
                <asp:Button ID="Button1" CssClass="addstylee" runat="server" Text="Add" OnClick="Button1_Click" Height="38px" Width="72px" />
            </td>
            <td class="auto-style16">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style18">&nbsp;</td>
            <td>&nbsp;</td>
            <td class="auto-style16">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style18">&nbsp;</td>
            <td>&nbsp;</td>
            <td class="auto-style16">&nbsp;</td>
        </tr>
    </table>

    <table class="auto-style5" id="table4"  runat="server">
        <tr>
            <td class="auto-style18">Fire Manager</td>
            <td>&nbsp;</td>
            <td class="auto-style16">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style18">Choose UserName : </td>
            <td>
                <asp:DropDownList ID="DropDownList4" runat="server">
                </asp:DropDownList>
            </td>
            <td class="auto-style16">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style18">&nbsp;</td>
            <td>&nbsp;</td>
            <td class="auto-style16">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style18">&nbsp;</td>
            <td>
                <asp:Button ID="Button2" CssClass="removestylee" runat="server" Text="Remove" OnClick="Button2_Click" />
            </td>
            <td class="auto-style16">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style18">&nbsp;</td>
            <td>&nbsp;</td>
            <td class="auto-style16">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style18">&nbsp;</td>
            <td>&nbsp;</td>
            <td class="auto-style16">&nbsp;</td>
        </tr>
    </table>

    <table class="auto-style5" id="table5"  runat="server">
        <tr>
            <td class="auto-style19">Fire Owner</td>
            <td>&nbsp;</td>
            <td class="auto-style16">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style19">Choose UserName : </td>
            <td>
                <asp:DropDownList ID="DropDownList5" runat="server">
                </asp:DropDownList>
            </td>
            <td class="auto-style16">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style19">&nbsp;</td>
            <td>&nbsp;</td>
            <td class="auto-style16">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style19">&nbsp;</td>
            <td>
                <asp:Button ID="Button3" CssClass="removestylee" runat="server" Text="Remove" OnClick="Button3_Click" />
            </td>
            <td class="auto-style16">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style19">&nbsp;</td>
            <td>&nbsp;</td>
            <td class="auto-style16">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style19">&nbsp;</td>
            <td>&nbsp;</td>
            <td class="auto-style16">&nbsp;</td>
        </tr>
    </table>

    <table class="auto-style5" id="table6"  runat="server">
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td class="auto-style16">&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td class="auto-style16">&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td class="auto-style16">&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td class="auto-style16">&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td class="auto-style16">&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td class="auto-style16">&nbsp;</td>
        </tr>
    </table>
</asp:Content>

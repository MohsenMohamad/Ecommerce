<%@ Page Title="" Language="C#" MasterPageFile="~/m1.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="Client.Cart" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-+0n0xVW2eSR5OomGNYDnhzAbDsOXxcvSN1TPprVMTNDbiYZCxYbOOl7+AMvyTG2x" crossorigin="anonymous">
<!-- JavaScript Bundle with Popper -->
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/js/bootstrap.bundle.min.js" integrity="sha384-gtEjrD/SeCtmISkJkNUaaKMoLD0//ElJ19smozuHV6z3Iehds+3Ulb9Bn9Plx0x4" crossorigin="anonymous"></script>
<link href="styles.css" rel="Stylesheet" type="text/css"/>
            <div >
           
            <h1>Cart</h1><br /><br />
        </div>
            

 <asp:DataList ID="Data_cart" OnItemCommand="DataListCart_ItemCommand1" runat="server" Width="100%" Height="335px" OnSelectedIndexChanged="Data_cart_SelectedIndexChanged1">
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
                                    <table>
                                        <tr>
                                            <td class="auto-style30">

                                                <asp:Label ID="LabelCreditcard" runat="server" Text="enter your credit card number : "></asp:Label>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxCreditcard" runat="server" Height="16px" Width="263px"></asp:TextBox>

                                            </td>
                                            <td class="auto-style25" >

                                                <asp:Label ID="Labelerrorcreditcard" runat="server" Text="credit card number is null"></asp:Label>

                                            </td>
                                            <td>

                                                <asp:Label ID="Label3" runat="server"></asp:Label>

                                            </td>
                                        </tr>
                                         <tr>
                                            <td class="auto-style31">

                                                <asp:Label ID="Labeladdress" runat="server" Text="enter your address : "></asp:Label>

                                            </td>
                                            <td class="auto-style28">

                                                <asp:TextBox ID="TextBoxaddress" runat="server" Height="16px" Width="263px"></asp:TextBox>

                                            </td>
                                             <td class="auto-style29" >

                                                 <asp:Label ID="Labelerroraddress" runat="server" Text="address is null"></asp:Label>

                                             </td>
                                             <td class="auto-style28">

                                            </td>
                                        </tr>
                                         <tr>
                                            <td class="auto-style31">

                                                <asp:Label ID="Labeladdress0" runat="server" Text="enter your expMonth : "></asp:Label>

                                            </td>
                                            <td class="auto-style28">

                                                <asp:TextBox ID="Text0" runat="server" Height="16px" Width="263px"></asp:TextBox>

                                            </td>
                                             <td class="auto-style29" >

                                                 &nbsp;</td>
                                             <td class="auto-style28">

                                                 &nbsp;</td>
                                        </tr>
                                         <tr>
                                            <td class="auto-style31">

                                                <asp:Label ID="Labeladdress1" runat="server" Text="enter your expYear : "></asp:Label>

                                            </td>
                                            <td class="auto-style28">

                                                <asp:TextBox ID="Text1" runat="server" Height="16px" Width="263px"></asp:TextBox>

                                            </td>
                                             <td class="auto-style29" >

                                                 &nbsp;</td>
                                             <td class="auto-style28">

                                                 &nbsp;</td>
                                        </tr>
                                         <tr>
                                            <td class="auto-style31">

                                                <asp:Label ID="Labeladdress2" runat="server" Text="enter your cardHolder : "></asp:Label>

                                            </td>
                                            <td class="auto-style28">

                                                <asp:TextBox ID="Text2" runat="server" Height="16px" Width="263px"></asp:TextBox>

                                            </td>
                                             <td class="auto-style29" >

                                                 &nbsp;</td>
                                             <td class="auto-style28">

                                                 &nbsp;</td>
                                        </tr>
                                         <tr>
                                            <td class="auto-style31">

                                                <asp:Label ID="Labeladdress3" runat="server" Text="enter your cardCcv : "></asp:Label>

                                            </td>
                                            <td class="auto-style28">

                                                <asp:TextBox ID="Text3" runat="server" Height="16px" Width="263px"></asp:TextBox>

                                            </td>
                                             <td class="auto-style29" >

                                                 &nbsp;</td>
                                             <td class="auto-style28">

                                                 &nbsp;</td>
                                        </tr>
                                         <tr>
                                            <td class="auto-style31">

                                                <asp:Label ID="Labeladdress4" runat="server" Text="enter your holderId : "></asp:Label>

                                            </td>
                                            <td class="auto-style28">

                                                <asp:TextBox ID="Text4" runat="server" Height="16px" Width="263px"></asp:TextBox>

                                            </td>
                                             <td class="auto-style29" >

                                                 &nbsp;</td>
                                             <td class="auto-style28">

                                                 &nbsp;</td>
                                        </tr>
                                         <tr>
                                            <td class="auto-style31">

                                                <asp:Label ID="Labeladdress5" runat="server" Text="enter your nameF : "></asp:Label>

                                            </td>
                                            <td class="auto-style28">

                                                <asp:TextBox ID="Text5" runat="server" Height="16px" Width="263px"></asp:TextBox>

                                            </td>
                                             <td class="auto-style29" >

                                                 &nbsp;</td>
                                             <td class="auto-style28">

                                                 &nbsp;</td>
                                        </tr>
                                         <tr>
                                            <td class="auto-style31">

                                                <asp:Label ID="Labeladdress6" runat="server" Text="enter youraddress : "></asp:Label>

                                            </td>
                                            <td class="auto-style28">

                                                <asp:TextBox ID="Text6" runat="server" Height="16px" Width="263px"></asp:TextBox>

                                            </td>
                                             <td class="auto-style29" >

                                                 &nbsp;</td>
                                             <td class="auto-style28">

                                                 &nbsp;</td>
                                        </tr>
                                         <tr>
                                            <td class="auto-style31">

                                                <asp:Label ID="Labeladdress7" runat="server" Text="enter your city : "></asp:Label>

                                            </td>
                                            <td class="auto-style28">

                                                <asp:TextBox ID="Text7" runat="server" Height="16px" Width="263px"></asp:TextBox>

                                            </td>
                                             <td class="auto-style29" >

                                                 &nbsp;</td>
                                             <td class="auto-style28">

                                                 &nbsp;</td>
                                        </tr>
                                         <tr>
                                            <td class="auto-style31">

                                                <asp:Label ID="Labeladdress8" runat="server" Text="enter your country : "></asp:Label>

                                            </td>
                                            <td class="auto-style28">

                                                <asp:TextBox ID="Text8" runat="server" Height="16px" Width="263px"></asp:TextBox>

                                            </td>
                                             <td class="auto-style29" >

                                                 &nbsp;</td>
                                             <td class="auto-style28">

                                                 &nbsp;</td>
                                        </tr>
                                         <tr>
                                            <td class="auto-style31">

                                                <asp:Label ID="Labeladdress9" runat="server" Text="enter your zip : "></asp:Label>

                                            </td>
                                            <td class="auto-style28">

                                                <asp:TextBox ID="Text9" runat="server" Height="16px" Width="263px"></asp:TextBox>

                                            </td>
                                             <td class="auto-style29" >

                                                 &nbsp;</td>
                                             <td class="auto-style28">

                                                 &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style30">

                                            </td>
                                            <td>

                                            </td>
                                            <td class="auto-style25">

                                                <asp:Button ID="Button3" runat="server" Text="Buy Now" Width="99px" CssClass="auto-style24" OnClick="Button3_Click" Height="36px" />

                                            </td>
                                            <td >

                                                &nbsp;</td>
                                        </tr>
                                    </table>
    </asp:Content>

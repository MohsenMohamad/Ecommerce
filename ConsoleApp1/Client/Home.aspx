<%@ Page Title="" Language="C#" MasterPageFile="~/m1.Master" AutoEventWireup="True" CodeBehind="Home.aspx.cs" Inherits="Client.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <asp:DataList ID="DataListproducts" OnItemCommand="DataListproducts_ItemCommand1" runat="server" BackColor="White" BorderStyle="Double" CellPadding="4"  RepeatDirection="Horizontal" RepeatColumns="3" BorderColor="#336666" BorderWidth="3px" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" GridLines="Horizontal">
        <FooterStyle BackColor="White" ForeColor="#333333" />
        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
        <SelectedItemStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
        <ItemStyle BackColor="White" ForeColor="#333333" />
        <ItemTemplate>
                       
                                <table align="left" style="width: 250px; background-color: #f5f5f5; border: 1px solid #CCC;">

                                    <tr>
                                        <td style="height: 10px;"></td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: center;">
                                                    <span style="font-weight: 700; font-size: 14px;"><%#Eval("productName") %> </span></td>
                                    </tr>
                                    <tr>
                                        <td style="height: 10px;"></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span style="font-weight: 700; font-size: 20px;"><%#Eval("descerption") %> </span></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span style="font-size: 16px;">barcode :<%#Eval("barcode") %></span></td>
                                    </tr>
                                     <tr>
                                        <td>
                                            <span style="font-size: 16px;">catagory :<%#Eval("catagory") %></span></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span style="font-weight: 700; font-size: 20px;"><%#Eval("price") %>₪</span></td>
                                    </tr>
                                     <tr>
                                        <td>
                                             <span style="font-size: 16px;">nameShop :<%#Eval("nameShop") %></span></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            
                                            &nbsp;</td>
                                    </tr>
                                    
                                    <tr>
                                        <td style="height: 10px;">
                                            <asp:DropDownList ID="DropDownList2"  AppendDataBoundItems="true" runat="server" OnSelectedIndexChanged="DDList_SelectedIndexChanged">
                                         <asp:ListItem Enabled="true" Text="Select Amount" Value="-1"></asp:ListItem>
                                         <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                         <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                         <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                         <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                         <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                         <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                         <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                         <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                         <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                         <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td style="height: 10px;">
                                            <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%#Eval("productName")+","+ Eval("descerption")+","+Eval("barcode")+","+Eval("catagory")+","+Eval("price")+","+Eval("nameShop") %>' CommandName="add_to_cart"><img src="img/add_to_cart.PNG" style="width: 250px; height: auto;" /></asp:LinkButton>
                                        </td>
                                        <tr>
                                            <td style="height: 10px;"></td>
                                        </tr>
                                    </tr>
                                </table>
                        
                        </ItemTemplate>
    </asp:DataList>
</asp:Content>



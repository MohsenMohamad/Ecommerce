﻿<%@ Page Title="" Language="C#" MasterPageFile="~/m1.Master" AutoEventWireup="True" CodeBehind="Home.aspx.cs" Inherits="Client.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style13 {
        height: 5px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DataList ID="DataListproducts" OnItemCommand="DataListproducts_ItemCommand1" runat="server" BackColor="White" BorderStyle="Double" CellPadding="4"  RepeatDirection="Horizontal" RepeatColumns="3" BorderColor="#336666" BorderWidth="3px" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" GridLines="Horizontal" OnSelectedIndexChanged="DataListproducts_SelectedIndexChanged">
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
                                        <td class="auto-style13">
                                            <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%#Eval("productName")+","+ Eval("descerption")+","+Eval("barcode")+","+Eval("catagory")+","+Eval("price")+","+Eval("nameShop") %>' CommandName="add_to_cart"><img src="img/select-button-png-th.png" style="width: auto; height: auto;" /></asp:LinkButton>
                                        </td>
                                        <tr>
                                            <td style="height: 10px;"></td>
                                        </tr>
                                    </tr>

                                    <tr>
                                    </tr>
                                </table>
                        
                        </ItemTemplate>
    </asp:DataList>
</asp:Content>



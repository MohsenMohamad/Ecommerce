<%@ Page Title="" Language="C#" MasterPageFile="~/m1.Master" AutoEventWireup="true" CodeBehind="MyShops.aspx.cs" Inherits="Client.MyShops" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style13 {
            width: 144%;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:DataList ID="Data_shop" OnItemCommand="Data_shop_Command" runat="server" Width="100%" OnSelectedIndexChanged="Data_shop_SelectedIndexChanged">
                                            <ItemTemplate>
                                                <table align="center" style="width: 100%; border-bottom: 1px solid #CCC">
                                                    <tr>
                                                        <td style="width: 200px;"><span style="font-size: 22px;">Shop name : <%#Eval("storeName") %></span></td>
                                                        <td style="width: 10px;"></td>
                                                        <td style="width: 302px">
                                                         
                                                        </td>
                                                        <td style="text-align: right;">
                                                            <asp:Button ID="btnedit" CommandArgument='<%#Eval("storeName")%>' CommandName="editshop" runat="server" Text="editshop" Width="101px" Height="40px" />
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

</asp:Content>

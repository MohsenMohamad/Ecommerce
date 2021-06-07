<%@ Page Title="" Language="C#" MasterPageFile="~/m1.Master" AutoEventWireup="true" CodeBehind="NotificationsOffer.aspx.cs" Inherits="Client.NotificationsOffer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DataList ID="Data_cart"  OnItemCommand="Data_shop_Command" runat="server" Width="100%" OnSelectedIndexChanged="Data_cart_SelectedIndexChanged">
                                            <ItemTemplate>
                                                <table align="center" style="width: 100%; border-bottom: 1px solid #CCC">
                                                    <tr>
                                                        <td style="text-align: center; width: 60px;">
                                                        <td style="width: 10px;"></td>
                                                        <td style="width: 302px">
                                                            <table align="left" style="width: 300px">
                                                                <tr>
                                                                    <td style="text-align: left;"><span style="font-size: 14px; font-weight: 700;">ID :<%#Eval("id")%></span></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="text-align: left;"><span style="font-size: 14px;">Offer : <%#Eval("Offer") %></span></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td style="text-align: right;">
                                                            <asp:Button ID="AcceptButton" CommandArgument='<%#Eval("Offer")%>' CommandName="Accept" runat="server" Text="Accept" />
                                                            <asp:Button ID="RejectButton" CommandArgument='<%#Eval("Offer")%>' CommandName="Reject" runat="server" Text="Reject" />
                                                            <asp:Button ID="CounterButton" CommandArgument='<%#Eval("Offer")%>' CommandName="Counter_Offe" runat="server" Text="Counter Offer" />

                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:DataList>
</asp:Content>

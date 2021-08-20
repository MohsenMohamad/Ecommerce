<%@ Page Title="" Language="C#" MasterPageFile="~/m1.Master" AutoEventWireup="true" CodeBehind="AllProducts.aspx.cs" Inherits="Client.AllProducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style22 {
            width: 843px;
        }
        .auto-style24 {
            margin-left: 363;
        }
        .auto-style26 {
            width: 953px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <table class="w-100">
         <tr>
             <td>&nbsp;</td>
             <td>&nbsp;</td>
             <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
             <td class="auto-style26">
                 <asp:TextBox ID="TextBox4" runat="server" placeholder="Min Price" Height="24px"></asp:TextBox>
                 <asp:TextBox ID="TextBox3" runat="server" placeholder="Max Price" CssClass="auto-style24" Height="24px"></asp:TextBox>
             </td>
             <td class="auto-style22">
                 <asp:Button ID="Button3" runat="server" CssClass="offset-sm-0" Text="filter" Width="98px" OnClick="Button3_Click1" />
             </td>
             <td>&nbsp;</td>
             <td>&nbsp;</td>
             <td>&nbsp;</td>
         </tr>
     </table>
     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:DropDownList id="cataegoryid"
                    runat="server" 
            class="dropdown-show" aria-labelledby="dropdownMenuLink" Width="150px" BackColor="#7F7F7F" ForeColor="#FFFFFF
" Font-Names="Andalus" CssClass="ddl" OnSelectedIndexChanged="cataegoryid_SelectedIndexChanged">
                  <asp:ListItem Text ="Search by" Selected="True" Value="Search by" class="dropdown-item">Search by</asp:ListItem>
                   <asp:ListItem Text ="Search by Product" Value="Search by Product" class="dropdown-item">Search by Product</asp:ListItem>
                  <asp:ListItem Text ="Search by category" Value="Search by category" class="dropdown-item">Search by category</asp:ListItem>
                  <asp:ListItem Text ="KeyWord" Value="Search by KeyWord" class="dropdown-item">Search by KeyWord</asp:ListItem>
               </asp:DropDownList> 
                         <asp:TextBox ID="TextBox2" runat="server"  Height="23px" Width="600px" placeholder="Search for anything "></asp:TextBox>
                         <asp:Button ID="Button2" runat="server" Text="Search"   CssClass="btn btn-primary" Height="34px" Width="100px" OnClick="Button1_Click" />
                     <br />
                     </td>
        <div>
            <asp:DataList ID="DataListproducts" OnItemCommand="DataListproducts_ItemCommand1" runat="server" BackColor="White" BorderStyle="Double" CellPadding="4"  RepeatDirection="Horizontal" RepeatColumns="3" BorderColor="#336666" BorderWidth="3px" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" GridLines="Horizontal" OnSelectedIndexChanged="DataListproducts_SelectedIndexChanged" Width="1077px" >
        <FooterStyle BackColor="White" ForeColor="#333333" />
        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
        <SelectedItemStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
        <ItemStyle BackColor="White" ForeColor="#333333" />
        <ItemTemplate>
                       
                                <table align="center" style="width: 250px; background-color: #f5f5f5; border: 1px solid #CCC;">

                                    <tr>
                                        <td style="text-align: center;">
                                                    <span style="font-weight: 700; font-size: 14px; text-align: center; "><%#Eval("productName") %> </span>

                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td>
                                            <span style="font-weight: 700; font-size: 20px; text-align: center; "><%#Eval("descerption") %> </span></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span style="font-size: 16px; text-align: center; ">barcode :<%#Eval("barcode") %></span></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span style="font-size: 16px; text-align: center; "><%#Eval("discount") %></span></td>
                                    </tr>
                                     <tr>
                                        <td>
                                            <span style="font-size: 16px; text-align: center; ">catagory :<%#Eval("catagory") %></span></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span style="font-weight: 700; font-size: 20px; text-align: center; "><%#Eval("price") %>₪</span></td>
                                    </tr>
                                     <tr>
                                        <td>
                                             <span style="font-size: 16px; text-align: center; ">Shop Name:<%#Eval("nameShop") %></span></td>
                                    </tr>
                                  
                                    <tr>
                                        <td style="position:center; justify-content:center;"><span>
                                                                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%#Eval("productName")+","+ Eval("descerption")+","+Eval("barcode")+","+Eval("catagory")+","+Eval("price")+","+Eval("nameShop") %>' CommandName="add_to_cart"><img src="img/select-button-png-th.png" style="width: auto; height: auto;" /></asp:LinkButton>

                                             </span>
                                        </td>
                                      
                                    </tr>

                                    <tr>
                                    </tr>
                                </table>
                        
                        </ItemTemplate>
    </asp:DataList>



        </div>

</asp:Content>

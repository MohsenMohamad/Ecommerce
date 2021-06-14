<%@ Page Title="" Language="C#" MasterPageFile="~/m1.Master" AutoEventWireup="true" CodeBehind="EditShop.aspx.cs" Inherits="Client.EditShop" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-+0n0xVW2eSR5OomGNYDnhzAbDsOXxcvSN1TPprVMTNDbiYZCxYbOOl7+AMvyTG2x" crossorigin="anonymous">
<!-- JavaScript Bundle with Popper -->
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/js/bootstrap.bundle.min.js" integrity="sha384-gtEjrD/SeCtmISkJkNUaaKMoLD0//ElJ19smozuHV6z3Iehds+3Ulb9Bn9Plx0x4" crossorigin="anonymous"></script>
<link href="styles.css" rel="Stylesheet" type="text/css"/>
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
        .auto-style23 {
            width: 160px;
        }
        .auto-style27 {
            height: 62px;
        }
        #DropDownList1{
            position:center;
        }
        #table1{
            position:center;
            justify-content:center;
        }
      @font-face
{
    font-family:text;
    src: url('Olive.otf');
}
         .auto-style28 {
             width: 354%;
         }
         .auto-style29 {
             width: 806px;
         }
         .auto-style30 {
             width: 443px;
         }
         .auto-style31 {
             width: 1141px;
             height: 168px;
         }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-+0n0xVW2eSR5OomGNYDnhzAbDsOXxcvSN1TPprVMTNDbiYZCxYbOOl7+AMvyTG2x" crossorigin="anonymous">
<!-- JavaScript Bundle with Popper -->
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/js/bootstrap.bundle.min.js" integrity="sha384-gtEjrD/SeCtmISkJkNUaaKMoLD0//ElJ19smozuHV6z3Iehds+3Ulb9Bn9Plx0x4" crossorigin="anonymous"></script>
<link href="styles.css" rel="Stylesheet" type="text/css"/>
         <div >
            <br />
          &nbsp;<table class="auto-style31">
                 <tr>
                     <td class="auto-style29">&nbsp;</td>
                     <td class="auto-style30">
          <img src="img/edit12.jpg" id="fast-shop" class="auto-style23"/></td>
                 </tr>
                 <tr>
                     <td class="auto-style29">&nbsp;</td>
                 </tr>
             </table>
        </div>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <table class="auto-style5">
        <tr>
             <td  style="width: 1086px">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack ="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="400px" BackColor="Wheat" >
                      <asp:ListItem Enabled="true" Text="Select" Value="-1"></asp:ListItem>
                                                <asp:ListItem Text="Add New Item" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Add New Manager" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="Add New Owner" Value="3"></asp:ListItem>
                                                <asp:ListItem Text="Fire Manager" Value="4"></asp:ListItem>
                                                <asp:ListItem Text="Fire Owner" Value="5"></asp:ListItem>
                                                <asp:ListItem Text="Policies" Value="6"></asp:ListItem>
                                                <asp:ListItem Text="Shop Discount" Value="7"></asp:ListItem>
                                                <asp:ListItem Text="Item Discount" Value="8"></asp:ListItem>
                                                <asp:ListItem Text="Conditional Discount" Value="9"></asp:ListItem>
                </asp:DropDownList>
            </td>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style15">
                <table id="table1"  runat="server"  class="auto-style28">
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
            <td>
                            <img id="firegif" runat="server" src="img/tenor.gif" alt="gif image" class="auto-style19" />
               </td>
            <td class="auto-style16">
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
            </td>
        </tr>
    </table>

    <table id="table6" class="auto-style5" runat="server">
        <tr>
            <td class="auto-style23">
                <asp:Label ID="Label4" runat="server" Text="Choose Policies :"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DropDownList6" runat="server" AutoPostBack ="true" OnSelectedIndexChanged="DropDownList6_SelectedIndexChanged">
                     <asp:ListItem Enabled="true" Text="Select" Value="-1"></asp:ListItem>
                                                <asp:ListItem Text="Product" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Category" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="User" Value="3"></asp:ListItem>
                                                <asp:ListItem Text="Cart" Value="4"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style23">
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style23">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style23">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>

                   <table id="table7" class="auto-style5" runat="server">
                    <tr>
                        <td class="auto-style26">
                            <asp:Label ID="Label5" runat="server" Text="Barcode:"></asp:Label>
                        </td>
                        <td class="auto-style27">
                            <asp:TextBox ID="TextBox3" runat="server" Height="16px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style25">
                            <asp:Label ID="Label6" runat="server" Text="Amount:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox4" runat="server" Height="16px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style25">
                            &nbsp;</td>
                        <td>
                <asp:Button ID="AddProduct" CssClass="addstylee" runat="server" Text="Add" Height="37px" Width="68px" OnClick="AddProduct_Click" />
                        </td>
                    </tr>
                </table>

     <table id="table8" class="auto-style5" runat="server">
                    <tr>
                        <td class="auto-style25">
                            <asp:Label ID="Label7" runat="server" Text="Name Category:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox1" runat="server" Height="16px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style25">
                            <asp:Label ID="Label8" runat="server" Text=" hour :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox2" runat="server" Height="16px"></asp:TextBox>   
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style25">
                            <asp:Label ID="Label12" runat="server" Text="minute :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox8" runat="server" Height="16px"></asp:TextBox>   
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style25">
                            &nbsp;</td>
                        <td>
                <asp:Button ID="AddCategory" CssClass="addstylee" runat="server" Text="Add"  Height="37px" Width="68px" OnClick="AddCategory_Click" />
                        </td>
                    </tr>
                </table>

       <table id="table9" class="auto-style5" runat="server">
                    <tr>
                        <td class="auto-style25">
                            <asp:Label ID="Label9" runat="server" Text="Barcode :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox5" runat="server" Height="16px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style25">
                            &nbsp;</td>
                        <td>
                <asp:Button ID="AddUser" CssClass="addstylee" runat="server" Text="Add"  Height="37px" Width="68px" OnClick="AddUser_Click" />
                        </td>
                    </tr>
                </table>

       <table id="table10" class="auto-style5" runat="server">
                    <tr>
                        <td class="auto-style25">
                            <asp:Label ID="Label11" runat="server" Text="Amount :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox7" runat="server" Height="16px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style25">
                            &nbsp;</td>
                        <td>
                <asp:Button ID="AddCart" CssClass="addstylee" runat="server" Text="Add"  Height="37px" Width="68px" OnClick="AddCart_Click" />
                        </td>
                    </tr>
                </table>

      <table id="table11" class="auto-style5" runat="server">
                    <tr>
                        <td class="auto-style28">
                            <asp:Label ID="Label10" runat="server" Text="Percentage :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox6" runat="server" Height="16px"></asp:TextBox>
                        </td>
                    </tr>
               <tr>
                        <td class="auto-style28">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
           <tr>
                        <td class="auto-style28">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
           <tr>
                        <td class="auto-style28">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style28">
                            &nbsp;</td>
                        <td>
                <asp:Button ID="Button4" CssClass="addstylee" runat="server" Text="Add"  Height="37px" Width="68px" OnClick="Button4_Click"  />
                        </td>
                    </tr>
                </table>

    <table id="table12" class="auto-style5" runat="server">
                    <tr>
                        <td class="auto-style28">
                            <asp:Label ID="Label13" runat="server" Text="Item :"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownList7" runat="server" OnSelectedIndexChanged="DropDownList7_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
               <tr>
                        <td class="auto-style28">
                            <asp:Label ID="Label14" runat="server" Text="Percentage :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox10" runat="server" Height="16px"></asp:TextBox>
                        </td>
                    </tr>
           <tr>
                        <td class="auto-style28">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
           <tr>
                        <td class="auto-style28">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style28">
                            &nbsp;</td>
                        <td>
                <asp:Button ID="Button5" CssClass="addstylee" runat="server" Text="Add"  Height="37px" Width="68px" OnClick="Button5_Click"  />
                        </td>
                    </tr>
                </table>
    

    <table id="table13" class="auto-style5" runat="server">
                    <tr>
                        <td class="auto-style28">
                            <asp:Label ID="Label18" runat="server" Text="Percentage :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox14" runat="server" Height="16px"></asp:TextBox>
                        </td>
                    </tr>
               <tr>
                        <td class="auto-style28">
                            <asp:Label ID="Label19" runat="server" Text="Conditional Discount :"></asp:Label>
                        </td>
                        <td>
                       <textarea runat="server" id="txt1" class="txt" name="S2" style="width: 273px; height: 110px;" cols="10" rows="1"></textarea></td>

                    </tr>
           <tr>
                        <td class="auto-style28">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
           <tr>
                        <td class="auto-style28">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style28">
                            &nbsp;</td>
                        <td>
                <asp:Button ID="Button6" CssClass="addstylee" runat="server" Text="Add"  Height="37px" Width="68px" OnClick="Button6_Click"  />
                        </td>
                    </tr>
                </table>
    
    
    </asp:Content>



<%@ Page Title="" Language="C#"  AutoEventWireup="true" CodeBehind="Open_shop.aspx.cs" Inherits="Client.Open_shop" %>

<link href="styles.css" rel="Stylesheet" type="text/css"/>
 <!DOCTYPE html>
<html>
<head runat="server">
    <title>open shop page</title>
</head>
<body>
    <form id="form1" runat="server">


    <br /><br /><br />
    <div style="display:table-cell">
<div >
           <img src="img/openshop.jfif" id="fast-shop" style="height:399px; width: 372px"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <div style="display:inline-block; justify-content:center; font-family:bodyfont">

            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

            <asp:Label ID="shopNameLabel" runat="server" Text="shop Name " Font-Bold="true" font-size="40px" font-family="bodyfont"></asp:Label>
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:TextBox ID="TextBoxShopname" runat="server" placeholder="Enter shop name" BorderStyle="dashed" BorderColor="Orange" Width="256px"></asp:TextBox><br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
         <asp:Label ID="policyLabel" runat="server" Text="policy " Font-Bold="true" font-size="40px" font-family="bodyfont"></asp:Label>  
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;  
          <asp:TextBox ID="TextBoxpolicy" runat="server" placeholder="Enter your policy" BorderStyle="dashed" BorderColor="Orange" Width="254px"></asp:TextBox><br />
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br /> 
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 
        <asp:Button ID="ButtonSend"  runat="server" Text="Open!" Height="33px" OnClick="ButtonSend_Click" Width="400px" style="margin-left: 0px ;color:white; background-color:orange; border:1px dashed blue;" Font-Size=22px />

            </div>
</div>
    </div>
    
        
    </div>
    
    </form>
    
</body>
</html>

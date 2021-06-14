<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sign-in.aspx.cs" Inherits="Client.sign_in" %>
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-+0n0xVW2eSR5OomGNYDnhzAbDsOXxcvSN1TPprVMTNDbiYZCxYbOOl7+AMvyTG2x" crossorigin="anonymous">
<!-- JavaScript Bundle with Popper -->
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/js/bootstrap.bundle.min.js" integrity="sha384-gtEjrD/SeCtmISkJkNUaaKMoLD0//ElJ19smozuHV6z3Iehds+3Ulb9Bn9Plx0x4" crossorigin="anonymous"></script>
<link href="styles.css" rel="Stylesheet" type="text/css"/>
 
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sign in page</title>
    <style type="text/css">

         .red1 {
            color:red;
         }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <img src="img/shopping.jpg" id="fast-shop" style="height: 140px; width: 220px"/>
        </div>
        <div style="display:block; position:center; justify-content:center; text-align:center">
            <label style="font-size:40px; text-align:center">Hello</label><br />
            <span>
            <label style="font-size:20px; text-align:center">Sign in to shopping or</label>
            <a href="Register.aspx">create an account</a>
            </span><br />
                     <asp:Label ID="LabelUsername" runat="server" CssClass="red1" Text="what's Your UserName ?"></asp:Label>
                                            <br />

             <asp:TextBox ID="txtusername" CssClass="txt" placeholder="Email or Username" runat="server" Style="text-align: center" Width="153px" ></asp:TextBox> <br />
                 <asp:Label ID="LabelPasword" runat="server" CssClass="red1" Text="what's Your Password ?"></asp:Label>
                                            <br />
             <asp:TextBox ID="txtpassword" TextMode="Password" CssClass="txt" placeholder="Enter Password" Style="text-align: center" runat="server" Width="150px"></asp:TextBox><br /><br />
             <asp:Button ID="btnlogin" runat="server" Text="Sign in" CssClass="loginstayl" Height="41px" Width="143px" OnClick="btnlogin_Click" Font-Size="Medium" Font-Bold="true"/><br />
            <br />
            <span>______________or_____________</span><br /><br />

            
                
            <asp:Button ID="Button1" runat="server" Text="Continue with Facebook"  Height="41px" Width="220px"  Font-Size="Medium" Font-Bold="true" BackColor="DarkBlue" ForeColor="White" /><br /><br />
            <asp:Button ID="Button2" runat="server" Text="Continue with Google"  Height="41px" Width="220px"  Font-Size="Medium" Font-Bold="true" BackColor="white" ForeColor="black" /><br /><br /><br /><br />
        </div>
      
    </form>
      <footer style="position:center; text-align:center">
            <p>Created by 13-A Group. © 2021</p>
        </footer>
</body>
</html>

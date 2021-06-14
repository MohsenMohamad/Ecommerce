<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Client.Register" %>

<!DOCTYPE html>
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-+0n0xVW2eSR5OomGNYDnhzAbDsOXxcvSN1TPprVMTNDbiYZCxYbOOl7+AMvyTG2x" crossorigin="anonymous">
<!-- JavaScript Bundle with Popper -->
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/js/bootstrap.bundle.min.js" integrity="sha384-gtEjrD/SeCtmISkJkNUaaKMoLD0//ElJ19smozuHV6z3Iehds+3Ulb9Bn9Plx0x4" crossorigin="anonymous"></script>
<link href="styles.css" rel="Stylesheet" type="text/css"/>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
         <img src="img/shopping.jpg" id="fast-shop" style="height: 140px; width: 220px" />
            <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<label style="font-size: 15px; text-align: center">Already a member?
            <a href="sign-in.aspx">Sign in</a>
                <br />
            </label>
            </span>
        </div>
        <div style="display: block; position: center; justify-content: center; text-align: center">
            <label style="font-size: 40px; text-align: center" font-bold="true">Create an account</label><br />
            <br />


            <asp:TextBox runat="server" CssClass="txt" ID="txt_Username" placeholder="Enter Username" Style="text-align: center" Width="150px"></asp:TextBox>

            <br />
            <br />

            <asp:TextBox runat="server" CssClass="txt" ID="txt_password" TextMode="Password" placeholder="Enter Password" Style="text-align: center" Width="150px"></asp:TextBox>

            <br />
            <br />
            <span style="width: 100px; height: 40px; text-align: center; position: center; font-size: xx-small; color: blue">By Creating an account, you agree to our User Agreement 
            <br />
            and acknowledge reading our User Privacy Notice.</span><br />
            <br />
            <asp:Button ID="btn_Register" runat="server" Text="Create account" class="btn btn-secondary" Height="41px" Width="143px" OnClick="btn_Register_Click" Font-Size="Medium" Font-Bold="true" /><br />
            <br />
            <span>______________or_____________</span><br />
            <br />



            <asp:Button ID="Button1" runat="server" Text="Continue with Facebook" Height="41px" Width="220px" Font-Size="Medium" Font-Bold="true" BackColor="DarkBlue" ForeColor="White" /><br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="Continue with Google" Height="41px" Width="220px" Font-Size="Medium" Font-Bold="true" BackColor="white" ForeColor="black" /><br />
            <br />
            <br />
            <br />
        </div>
        <footer style="position: center; text-align: center">
            <p>Created by Yara Ahmad. © 2021</p>
        </footer>
        <br />
        <br />
    </form>
</body>
</html>

<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Client.Register1" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Sign up page</title>
</head>
<body >


    <form id="form2" runat="server">
        <div>
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

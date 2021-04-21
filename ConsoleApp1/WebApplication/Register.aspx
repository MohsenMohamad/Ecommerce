<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebApplication.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
     <style>
        body {
            font-family: Arial, Helvetica, sans-serif;
        }
        form {
            border: 3px solid #f1f1f1;
        }
        input[type=text], input[type=password] {
            padding: 12px 20px;
            margin: 8px 0;
            display: inline-block;
            border: 1px solid #ccc;
            box-sizing: border-box;
        }
        button:hover {
            opacity: 0.8;
        }
        .cnbtn {
            background-color: #ec3f3f;
            color: white;
            padding: 14px 20px;
            margin: 8px 0;
            border: none;
            cursor: pointer;
            width: 49%;
        }
        .homestyle{
            color:wheat;
            background-color: #000000;
        }
         .red1 {
            color:red;
         }
        .lgnbtn {
            border-style: none;
             border-color: inherit;
             border-width: medium;
             background-color: #4CAF50;
             color: white;
             padding: 14px 20px;
             margin: 8px 0;
             cursor: pointer;
            }
        .imgcontainer {
            text-align: center;
            margin: 24px 0 12px 0;
        }
        img.avatar {
            width: 40%;
            border-radius: 50%;
        }
        .container {
            padding: 16px;
        }
        span.psw {
            float: right;
            padding-top: 16px;
        }
        /* Change styles for span and cancel button on extra small screens */
        @media screen and (max-width: 300px) {
            span.psw {
                display: block;
                float: none;
            }
            .cnbtn {
                width: 100%;
            }
        }
        .frmalg {
            margin: auto;
            width: 40%;
        }
      #Login_table {
          width: 258px;
          height: 43px;
      }
         .auto-style1 {
             width: 100%;
         }
         .auto-style2 {
             height: 271px;
             width: 475px;
         }
    </style>
<body>
    <form id="form1" runat="server">
            <div>
                <table class="auto-style1">
                    <tr>
                        <td>
                            <asp:Button ID="HomeButton" runat="server" CssClass="homestyle" Text="Home" Width="130px" OnClick="HomeButton_Click" />
                        </td>
                    </tr>
                </table>
            <table style="text-align:center; " runat="server" id="Register_table" class="auto-style2">
             <tr>
             <td>
            <label for="uname"><b>Username</b></label>
             </td>
             <td class="auto-style1">
            <asp:TextBox runat="server" ID="txt_Username" placeholder="Enter Username" Width="175px"></asp:TextBox>
             </td>
             <td class="auto-style1">
                     <asp:Label ID="LabelUsername" runat="server" CssClass="red1" Text="what's Your UserName ?"></asp:Label>
             </td>
             </tr>
             <tr>
             <td>
            <label for="psw"><b>Password</b></label>
             </td>
             <td class="auto-style1">
            <asp:TextBox runat="server" ID="txt_password" TextMode="Password" placeholder="Enter Password" Width="179px"></asp:TextBox>
             </td>
             <td class="auto-style1">
                 <asp:Label ID="LabelPasword" runat="server" CssClass="red1" Text="what's Your Password ?"></asp:Label>
             </td>
             </tr>
             <tr>
             <td>
             </td>
             <td class="auto-style1">
            <asp:Button runat="server" ID="btn_Register" CssClass="lgnbtn" Text="Register" OnClick="btn_Register_Click" />
             </td>
             <td class="auto-style1">
                 &nbsp;</td>
             </tr>
             <tr>
                 <td class="auto-style1">
                 </td>
                 <td class="auto-style1">
                     &nbsp;</td>
                 <td class="auto-style1">
                     &nbsp;</td>
             </tr>
         </table>
        </div>
    </form>
</body>
</html>

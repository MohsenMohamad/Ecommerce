using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label3.Visible = false;
            
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Register.aspx");
        }


        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            if (UserNameTextBox.Text.Trim().Length == 0 | PasswordTextBox.Text.Trim().Length == 0)
            {
                Label3.Visible = true;
            }
            else
            {
                Session["username"] = UserNameTextBox.Text;
                Login_table.Visible = false;
                Button1.Visible = false;
                welcome.Text = "Welcome " + Session["username"];
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Client.Code;

namespace Client
{
    public partial class sign_in : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnlogin_Click(object sender, EventArgs e)
        {
            if ((txtusername.Text.Trim().Length == 0) || (txtpassword.Text.Trim().Length == 0))
            {
                string script = "alert(\"Try to enter a liggal values\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                Response.Redirect("~/sign-in.aspx");
            }
            else
            {
                //  Console.WriteLine("unKnown error !");
                string msg = new UserHandler().Login(txtusername.Text, txtpassword.Text);
                if (msg.Equals("\"True\""))
                {
                    Session["isLogin"] = "true";
                    Session["username"] = txtusername.Text;
                    Session["admin"] = null;

                    Session["basket"] = null;
                    if (txtusername.Text.ToString().Equals("admin"))
                    {
                        Session["admin"] = "admin";
                        

                    }
                    Response.Redirect("~/Home.aspx");
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + msg + "')", true);
                }
            }
        }
    }
}
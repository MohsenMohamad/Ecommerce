using Client.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Client
{
    public partial class sign_in : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LabelUsername.Visible = false;
            LabelPasword.Visible = false;

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            if ((txtusername.Text.Trim().Length == 0) || (txtpassword.Text.Trim().Length == 0))
            {
                if (txtusername.Text.Trim().Length == 0)
                {
                    if (txtpassword.Text.Trim().Length == 0) LabelPasword.Visible = true;
                    LabelUsername.Visible = true;
                }

                if (txtpassword.Text.Trim().Length == 0)
                {
                    if (txtusername.Text.Trim().Length == 0) LabelUsername.Visible = true;
                    LabelPasword.Visible = true;
                }
            }
            else
            {
                //  Console.WriteLine("unKnown error !");
                string msg = new UserHandler().Login(txtusername.Text, txtpassword.Text);
                if (msg.Equals("\"True\""))
                {
                    Session["isLogin"] = "true";
                    Session["username"] = txtusername.Text;
                    Session["userid"] = msg;
                    Session["admin"] = null;

                    Session["basket"] = null;
                    if (txtusername.Text.ToString().Equals("admin"))
                    {
                        Session["admin"] = "admin";
                    }
                    Response.Redirect("~/home.aspx");
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage",
                        "alert('" + msg + "')", true);
                    /*string message = ex.Message;
                    string script = "alert(\""+ message + "\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                          "ServerControlScript", script, true);*/
                }
            }
        }
    }
}
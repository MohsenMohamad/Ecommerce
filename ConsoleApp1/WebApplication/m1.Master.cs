using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.Code;

namespace WebApplication
{
    public partial class m1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LabelPasword.Visible = false;
            LabelUsername.Visible = false;
            if (Session["isLogin"] != null)
            {
                ButtonLogOut.Visible = true;
            }
        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            if ((txtusername.Text.Trim().Length != 0) && (txtpassword.Text.Trim().Length != 0))
            {
                string msg = new UserHandler().Login(txtusername.Text, txtpassword.Text);
                if (msg != null)
                {
                    Login_table.Visible = false;
                    Session["username"] = txtusername.Text;
                    Session["userid"] = msg;
                    Session["isLogin"] = "true";
                    ButtonLogOut.Visible = true;
                    //todo make sure of that
                    Login_table.Visible = true;

                    Session["basket"] = null;
                    Response.Redirect(Request.RawUrl);
                }
                else
                {
                    Console.WriteLine("unKnown error !");
                }
            }

            //todo make sure of that

            /*if ((txtusername.Text.Trim().Length != 0) && (txtpassword.Text.Trim().Length != 0))
            {
                ButtonLogOut.Visible = true;
                Login_table.Visible = false;
                Session["isLogin"] = "true";
            }
            else
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
            }*/
        }

        protected void ButtonLogOut_Click(object sender, EventArgs e)
        {

        }
    }
}
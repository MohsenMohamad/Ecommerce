using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LabelUsername.Visible = false;
            LabelPasword.Visible = false;
        }

        protected void HomeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home.aspx");
        }

        protected void btn_Register_Click(object sender, EventArgs e)
        {
            if ((txt_Username.Text.Trim().Length != 0) && (txt_password.Text.Trim().Length != 0))
            {
                Response.Redirect("~/Home.aspx");
            }
            else
            {

                if (txt_Username.Text.Trim().Length == 0)
                {
                    if (txt_password.Text.Trim().Length == 0) LabelPasword.Visible = true;
                    LabelUsername.Visible = true;
                }
                if (txt_password.Text.Trim().Length == 0)
                {
                    if (txt_Username.Text.Trim().Length == 0) LabelUsername.Visible = true;
                    LabelPasword.Visible = true;
                }
            }
           
        }
    }
}
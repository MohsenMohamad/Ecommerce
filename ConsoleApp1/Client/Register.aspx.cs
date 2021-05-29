using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Client.Code;

namespace Client
{
    public partial class Register1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LabelUsername.Visible = false;
            LabelPasword.Visible = false;
        }

        protected void btn_Register_Click(object sender, EventArgs e)
        {
            if ((txt_Username.Text.Trim().Length != 0) && (txt_password.Text.Trim().Length != 0))
            {
                
                string msg =  new UserHandler().Register(txt_Username.Text, txt_password.Text);
                if (msg.Equals("\"True\""))
                {
                    Response.Redirect("~/Home.aspx");
                    LabelUsername.Visible = true;
                }else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + msg + "')", true);
                }
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
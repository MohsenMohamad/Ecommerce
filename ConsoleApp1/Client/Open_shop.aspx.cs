using Client.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Client
{
    public partial class Open_shop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Labelerror.Visible = false;
        }

        protected void ButtonSend_Click(object sender, EventArgs e)
        {

            ShopHandler s = new ShopHandler();
            string username = Session["username"].ToString();
            bool open = s.OpenShop(TextBoxShopname.Text, username, TextBoxpolicy.Text);
            if (!open) {
                Labelerror.Visible = true;
            }
            Response.Redirect("~/Home.aspx");
        }
    }
}
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
          
        }

        protected void ButtonSend_Click(object sender, EventArgs e)
        {

            ShopHandler s = new ShopHandler();
            string username = Session["username"].ToString();
            string open = s.OpenShop(username, TextBoxShopname.Text , TextBoxpolicy.Text);
            if (!(open.Equals("\"True\""))) {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + open + "')", true);

            }
            Response.Redirect("~/Websitehome.aspx");
        }
        protected void ButtonLogOut_Click(object sender, EventArgs e)
        {
            new UserHandler().Logout(Session["username"].ToString());
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/Home.aspx");
        }

        protected void HomeButton_Click(object sender, EventArgs e)
        {
            ButtonLogOut.Visible = true;
            Response.Redirect("~/Websitehome.aspx");

        }

        protected void Allshops_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/Shops.aspx");
        }

        protected void OpenShop_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Open_shop.aspx");
        }

        protected void Allshops_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/Shops.aspx");
        }

        protected void OpenShop_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/Open_shop.aspx");
        }

        protected void ImageButtoncart_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Cart.aspx");
        }

        protected void MyShops_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MyShops.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (barSearch.Text.Trim().Length == 0) { }
            else
            {
                Response.Redirect("~/Websitehome.aspx?keyword=" + barSearch.Text.ToString());
            }
        }

        protected void Notifications_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Notifications.aspx");
        }

        protected void InitSystem_Click(object sender, EventArgs e)
        {
            ShopHandler s = new ShopHandler();
            s.InitSystem();
            Response.Redirect("~/Websitehome.aspx");

        }
    }
}
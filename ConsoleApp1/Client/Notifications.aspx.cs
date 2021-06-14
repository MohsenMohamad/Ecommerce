using Client.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Client
{
    public partial class Notifications : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserHandler a = new UserHandler();

            Data_cart.DataSource = a.GetAllNotifications(Session["username"].ToString());
            Data_cart.DataBind();


            if (Session["isLogin"] != null)
            {
                if (Session["admin"] != null)
                {
                    InitSystem.Visible = true;
                    ButtonLogOut.Visible = true;
                }
                else { InitSystem.Visible = false; }
            }
            else if (Session["username"] == null)
            {
                UserHandler h = new UserHandler();
                Session["username"] = h.GuestLogin().ToString();
                Labelname.Text = "Hello " + Session["username"].ToString() + " !";
                Labelname.Visible = true;
                ButtonLogOut.Visible = true;

            }
            else
            {
                Labelname.Text = "Hello " + Session["username"].ToString() + "!";
                Labelname.Visible = true;
                ButtonLogOut.Visible = true;
            }

        }

        protected void Data_cart_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void OffersButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/NotificationsOffer.aspx");
        }


        protected void ButtonLogOut_Click(object sender, EventArgs e)
        {
            new UserHandler().Logout(Session["username"].ToString());
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/home.aspx");
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

      
        
        protected void InitSystem_Click(object sender, EventArgs e)
        {
            ShopHandler s = new ShopHandler();
            s.InitSystem();
            Response.Redirect("~/Websitehome.aspx");

        }
    }
}
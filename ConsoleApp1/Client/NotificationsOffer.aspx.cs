using Client.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Client
{
    public partial class NotificationsOffer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                UserHandler a = new UserHandler();

                Data_offer.DataSource = a.GetAllUserNotificationsoffer(Session["username"].ToString());
                Data_offer.DataBind();
            }
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
        protected void offer_Command(object source, DataListCommandEventArgs e)
        {
            Session["msgoffer"] = e.CommandArgument;
            if (e.CommandName == "Accept")
            {
                char[] splitting = new char[2];
                splitting[0] = '.';
                splitting[1] = ':';
                string[] msg= Session["msgoffer"].ToString().Split(splitting);

                ShopHandler sh = new ShopHandler();
                sh.acceptoffer(msg[1],msg[5],msg[7],msg[9], int.Parse(msg[3]), Session["username"].ToString());
                Response.Redirect("~/Websitehome.aspx");



            }

            if (e.CommandName == "Reject")
            {

                char[] splitting = new char[2];
                splitting[0] = '.';
                splitting[1] = ':';
                string[] msg = Session["msgoffer"].ToString().Split(splitting);

                ShopHandler sh = new ShopHandler();
                sh.rejectoffer(msg[1], msg[5], msg[7], msg[9], int.Parse(msg[3]), Session["username"].ToString());
                Response.Redirect("~/Websitehome.aspx");



            }
            if (e.CommandName == "Counter_Offer")
            {
                char[] splitting = new char[2];
                splitting[0] = '.';
                splitting[1] = ':';
                string[] msg = Session["msgoffer"].ToString().Split(splitting);
               

                Session["barcode"] = msg[1];
                Session["price"] = msg[5];
                Session["username_offer"] = msg[7];
                Session["nameShop"] = msg[9];
                Session["amount"] = msg[3];
                Response.Redirect("~/CounterOffer.aspx");
            }
        }
        protected void offer_SelectedIndexChanged(object sender, EventArgs e)
        {

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
    
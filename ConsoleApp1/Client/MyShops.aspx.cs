using Client.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Client
{
    public partial class MyShops : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            ShopHandler a = new ShopHandler();

            Data_shop.DataSource = a.GetUserStores(Session["username"].ToString());
            Data_shop.DataBind();
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
        protected void Data_shop_Command(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "editshop")
            {
                Session["editshop"] = e.CommandArgument;
                UserHandler uh = new UserHandler();
                if (uh.IsOwner(Session["editshop"].ToString(), Session["username"].ToString()))
                {
                    Response.Redirect("~/EditShop.aspx");
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('youre not an owner !!!!!!!!!!!!!')", true);
                }
            }
            if (e.CommandName == "StafInfo")
            {
                Session["editshop"] = e.CommandArgument;
                Response.Redirect("~/Staff.aspx");
            }
            if (e.CommandName == "Close")
            {
                Session["editshop"] = e.CommandArgument;
                ShopHandler sh = new ShopHandler();
                UserHandler uh = new UserHandler();
                if (uh.IsOwner(Session["editshop"].ToString(), Session["username"].ToString()))
                {
                   sh.CloseStore(Session["editshop"].ToString(), Session["username"].ToString());
                   Response.Redirect("~/MyShops.aspx");
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('youre not an owner !!!!!!!!!!!!!')", true);
                }
            }
        }

        protected void Data_shop_SelectedIndexChanged(object sender, EventArgs e)
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
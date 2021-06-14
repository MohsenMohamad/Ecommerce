using Client.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Client
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Data_cart.Visible = true;
            purchase.Visible = true;
            if (!Page.IsPostBack)
            {
                Labelerrorcreditcard.Visible = false;
                Labelerroraddress.Visible = false;
                ShopHandler a = new ShopHandler();

                Data_cart.DataSource = a.GetUserBaskets(Session["username"].ToString());
                Data_cart.DataBind();

            }
            else {
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

        protected void DataList1_ItemCommand1(object source, DataListCommandEventArgs e)
        {
          
        }

        protected void DataListCart_ItemCommand1(object source, DataListCommandEventArgs e)
        {

            if (e.CommandName == "Delete_command")
            {
                string[] cargs = e.CommandArgument.ToString().Split(',');
                Session["productName"] = cargs[0];
                Session["descerption"] = cargs[1];
                Session["barcode"] = cargs[2];
                Session["catagory"] = cargs[3];
                Session["price"] = cargs[4];
                Session["nameShop"] = cargs[5];
                Session["Amount"] = cargs[6];

                ShopHandler s = new ShopHandler();
                bool b = s.remove_item_from_cart(Session["username"].ToString(), Session["nameShop"].ToString(), Session["barcode"].ToString(), int.Parse(Session["Amount"].ToString()));
                if (b)
                {
                    ShopHandler c = new ShopHandler();

                    Data_cart.DataSource = c.GetUserBaskets(Session["username"].ToString());
                    Data_cart.DataBind();
                }
                else
                {
                }
            }

            if (e.CommandName == "up_command")
            {
                string[] cargs = e.CommandArgument.ToString().Split(',');
                Session["productName"] = cargs[0];
                Session["barcode"] = cargs[1];
                Session["nameShop"] = cargs[2];
                Session["Amount"] = cargs[3];

                ShopHandler s = new ShopHandler();
                s.UpdateCart(Session["username"].ToString(), Session["nameShop"].ToString(), Session["barcode"].ToString(), int.Parse(Session["Amount"].ToString()) + 1);
                Response.Redirect("~/Cart.aspx");

            }
            if (e.CommandName == "down_command")
            {
                string[] cargs = e.CommandArgument.ToString().Split(',');
                Session["productName"] = cargs[0];
                Session["barcode"] = cargs[1];
                Session["nameShop"] = cargs[2];
                Session["Amount"] = cargs[3];
                ShopHandler s = new ShopHandler();
                s.UpdateCart(Session["username"].ToString(), Session["nameShop"].ToString(), Session["barcode"].ToString(), int.Parse(Session["Amount"].ToString()) - 1);
                Response.Redirect("~/Cart.aspx");


            }
        }
        protected void Data_cart_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void Data_cart_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            purchase.Visible = true;
            Data_cart.Visible = true;
            visa.Visible = true;
            delivery.Visible = true;
            ShopHandler s = new ShopHandler();
            if (TextBoxCreditcard.Text.Length == 0)
            {
                Labelerrorcreditcard.Visible = true;
            }
            else if (TextBoxaddress.Text.Length == 0)
            {
                Labelerroraddress.Visible = true;
            }
            else
            {
                bool buy = s.Purchase(Session["username"].ToString(), TextBoxCreditcard.Text.ToString());
                if (buy)
                {
                    Response.Redirect("~/PurchaseDone.aspx");
                }
            }

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
                Response.Redirect("~/AllProducts.aspx?keyword=" + barSearch.Text.ToString());
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
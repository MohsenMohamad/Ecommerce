﻿using Client.Code;
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
            if (!Page.IsPostBack)
            {
                Labelerrorcreditcard.Visible = false;
                Labelerroraddress.Visible = false;
                ShopHandler a = new ShopHandler();
                UserHandler u = new UserHandler();

                Data_cart.DataSource = a.GetUserBaskets(Session["username"].ToString());
                Data_cart.DataBind();

                Label2.Text = u.GetTotalCart(Session["username"].ToString()).ToString();

            }
            else {

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
                var msg = s.remove_item_from_cart(Session["username"].ToString(), Session["nameShop"].ToString(), Session["barcode"].ToString(), int.Parse(Session["Amount"].ToString()));
                if (msg.Equals("\"True\""))
                {
                    /*ShopHandler c = new ShopHandler();
                    Data_cart.DataSource = c.GetUserBaskets(Session["username"].ToString());
                    Data_cart.DataBind();*/
                    Response.Redirect("~/Cart.aspx");
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + msg + "')", true);
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
                var msg = s.UpdateCart(Session["username"].ToString(), Session["nameShop"].ToString(), Session["barcode"].ToString(), int.Parse(Session["Amount"].ToString()) + 1);

                if (msg.Equals("\"True\""))
                {
                    Response.Redirect("~/Cart.aspx");
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + msg + "')", true);
                }

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
            visa.Visible = true;
            delivery.Visible = true;
            UserHandler s = new UserHandler();
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
                var msg = s.Purchase(Session["username"].ToString(), TextBoxCreditcard.Text.ToString(), int.Parse(Text0.Text), int.Parse(Text1.Text), Text2.Text, int.Parse(Text3.Text), int.Parse(Text4.Text), Text5.Text, Text6.Text, Text7.Text, Text8.Text, int.Parse(Text9.Text));
                if (msg.Equals("\"True\""))
                {
                    Response.Redirect("~/PurchaseDone.aspx");
                }
                else
                {

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + msg + "')", true);

                }
            }

        }
    }
}
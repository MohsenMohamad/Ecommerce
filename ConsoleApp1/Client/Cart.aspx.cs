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
            if (!Page.IsPostBack)
            {
                ShopHandler a = new ShopHandler();

                Data_cart.DataSource = a.GetUserBaskets(Session["username"].ToString());
                Data_cart.DataBind();

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

            if (e.CommandName == "checkbox_command")
            {
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
    }
}
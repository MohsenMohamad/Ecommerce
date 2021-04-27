using Client.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Client
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ShopHandler a = new ShopHandler();
            DataListproducts.DataSource = a.getAllProducts();
            DataListproducts.DataBind();
            Label1.Visible = false;


        }

        protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label1.Visible = true;
            //cast the sender back to a dropdownlist
            DropDownList ddl = sender as DropDownList;

            //get the namingcontainer from the dropdownlist and cast it as a datalistitem
            DataListItem item = ddl.NamingContainer as DataListItem;

            //now use findcontrol to find the label in the datalistitem

            Session["amount"] = ddl.SelectedValue;

        }

        protected void DataListproducts_ItemCommand1(object source, DataListCommandEventArgs e)
        {

            if (e.CommandName == "add_to_cart")
            {
                string[] cargs = e.CommandArgument.ToString().Split(',');
                ShopHandler sh = new ShopHandler();
                string barcode = cargs[2];
                string nameShop = cargs[5];
                //string data = DropDownList2.SelectedValue;
                sh.AddProductToBasket(Session["username"].ToString(), nameShop, barcode ,3);

            }
        }
        protected void ImageButtonadd_to_cart_Click(object sender, ImageClickEventArgs e)
        {
            
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label1.Visible = true;
            //cast the sender back to a dropdownlist
            DropDownList ddl = sender as DropDownList;

            //get the namingcontainer from the dropdownlist and cast it as a datalistitem
            DataListItem item = ddl.NamingContainer as DataListItem;

            //now use findcontrol to find the label in the datalistitem

            Session["amount"] = ddl.SelectedValue;
        }

        protected void DataListproducts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
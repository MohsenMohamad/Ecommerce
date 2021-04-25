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

        }

        protected void DataList1_SelectedIndexChanged(object sender, DataListCommandEventArgs e)
        {
           

        }

        protected void DataListproducts_ItemCommand1(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "add_to_cart")
            {
                string[] cargs = e.CommandArgument.ToString().Split(',');
                ShopHandler sh = new ShopHandler();
                string barcode = cargs[2];
                string nameShop = cargs[5];
                sh.AddProductToBasket(Session["username"].ToString(), nameShop, barcode);

            }
        }
            protected void ImageButtonadd_to_cart_Click(object sender, ImageClickEventArgs e)
        {
            
        }

    }
}
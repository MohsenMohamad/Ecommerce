using Client.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Client
{
    public partial class Staff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ShopHandler a = new ShopHandler();

            Data_cart.DataSource = a.GetStaff(Session["editshop"].ToString());
            Data_cart.DataBind();

        }

        protected void Data_cart_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
using Client.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Client
{
    public partial class Shops : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ShopHandler a = new ShopHandler();
            DataListproducts.DataSource = a.getAllStores();
            DataListproducts.DataBind();


        }
    }
}
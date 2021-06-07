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
            UserHandler a = new UserHandler();

            Data_cart.DataSource = a.GetAllUserNotificationsoffer(Session["username"].ToString());
            Data_cart.DataBind();

        }
        protected void Data_shop_Command(object source, DataListCommandEventArgs e)
        {
            Session["msgoffer"] = e.CommandArgument;
            if (e.CommandName == "Accept")
            {
                char[] splitting = new char[2];
                splitting[0] = '.';
                splitting[1] = ':';
                string[] msg= Session["msgoffer"].ToString().Split(splitting);

                ShopHandler sh = new ShopHandler();
                sh.acceptoffer(msg[1],msg[3],msg[5],msg[7]);


            }

            if (e.CommandName == "Reject")
            {

            }
            if (e.CommandName == "Counter_Offe")
            {

            }
        }

        protected void Data_cart_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
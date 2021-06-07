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
                sh.acceptoffer(msg[1],msg[3],msg[5],msg[7]);
                Response.Redirect("~/Home.aspx");



            }

            if (e.CommandName == "Reject")
            {

            }
            if (e.CommandName == "Counter_Offe")
            {

            }
        }
        protected void offer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
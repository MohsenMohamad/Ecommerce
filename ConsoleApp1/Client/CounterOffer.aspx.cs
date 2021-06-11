using Client.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Client
{
    public partial class CounterOffer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Labelbarcode0.Text = Session["barcode"].ToString();
            Labelprice0.Text = Session["price"].ToString();
            LabelnameShop0.Text = Session["nameShop"].ToString();
            Label1.Text = Session["amount"].ToString();
/*            TextBoxSuggested.Text = Session["price"].ToString();
*/
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            ShopHandler sh = new ShopHandler();
            sh.CounterOffer(Labelbarcode0.Text, TextBoxSuggested.Text, Session["username_offer"].ToString(), LabelnameShop0.Text,int.Parse(Label1.Text.ToString()), Session["username"].ToString(), Session["price"].ToString());
            Response.Redirect("~/Home.aspx");

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (Label1.Text.ToString().Equals("0")) { }
            else
            {
                Label1.Text = (int.Parse(Label1.Text.ToString()) - 1).ToString();
            }
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            Label1.Text = (int.Parse(Label1.Text.ToString()) + 1).ToString();
        }
    }
}
using Client.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Client
{
    public partial class Purchase_Offer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LabelproductName0.Text = Session["productName"].ToString();
            Labeldescription0.Text = Session["descerption"].ToString();
            Labelbarcode0.Text = Session["barcode"].ToString();
            Labelcategories0.Text = Session["catagory"].ToString();
            Labelprice0.Text = Session["price"].ToString();
            LabelnameShop0.Text = Session["nameShop"].ToString(); 
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            ShopHandler sh = new ShopHandler();

            sh.Recieve_purchase_offer(Session["username"].ToString(), Session["nameShop"].ToString() , TextBoxSuggested.Text, Session["barcode"].ToString(), int.Parse(Label1.Text));
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
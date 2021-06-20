using Client.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Client
{
    public partial class Product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LabelproductName0.Text = Session["productName"].ToString();
            Labeldescription0.Text = Session["descerption"].ToString();
            Labelbarcode0.Text = Session["barcode"].ToString();
            Labelcategories0.Text = Session["catagory"].ToString();
            Labelprice0.Text = Session["price"].ToString();
            LabelnameShop0.Text = Session["nameShop"].ToString();

            if (Session["isLogin"] == null) {
                Button3.Visible = false;
            }
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

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            ShopHandler sh = new ShopHandler();
           var msg = sh.AddProductToBasket(Session["username"].ToString(), Session["nameShop"].ToString(), Session["barcode"].ToString(), int.Parse(Label1.Text.ToString()),double.Parse(Labelprice0.Text.ToString()));
            if (msg.Equals("\"True\""))
            {
                Response.Redirect("~/Home.aspx");
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + msg + "')", true);
            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Purchase_Offer.aspx");  
        }
    }
}
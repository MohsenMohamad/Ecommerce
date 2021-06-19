using Client.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Client
{
    public partial class MyShops : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            ShopHandler a = new ShopHandler();

            Data_shop.DataSource = a.GetUserStores(Session["username"].ToString());
            Data_shop.DataBind();
            }
        }
        protected void Data_shop_Command(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "editshop")
            {
                Session["editshop"] = e.CommandArgument;
                UserHandler uh = new UserHandler();
/*                if (uh.IsOwner(Session["editshop"].ToString(), Session["username"].ToString()))
                {*/
                    Response.Redirect("~/EditShop.aspx");
               /* }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('youre not an owner !!!!!!!!!!!!!')", true);
                }*/
            }
            if (e.CommandName == "StafInfo")
            {
                Session["editshop"] = e.CommandArgument;
                Response.Redirect("~/Staff.aspx");
            }
            if (e.CommandName == "Close")
            {
                Session["editshop"] = e.CommandArgument;
                ShopHandler sh = new ShopHandler();
                UserHandler uh = new UserHandler();
                if (uh.IsOwner(Session["editshop"].ToString(), Session["username"].ToString()))
                {
                   sh.CloseStore(Session["editshop"].ToString(), Session["username"].ToString());
                   Response.Redirect("~/MyShops.aspx");
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('youre not an owner !!!!!!!!!!!!!')", true);
                }
            }
            if (e.CommandName == "History")
            {
                Session["editshop"] = e.CommandArgument;
                UserHandler uh = new UserHandler();
                if (uh.IsOwner(Session["editshop"].ToString(), Session["username"].ToString()))
                {
                    Response.Redirect("~/History.aspx");
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('youre not an owner !!!!!!!!!!!!!')", true);
                }
            }
        }

        protected void Data_shop_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
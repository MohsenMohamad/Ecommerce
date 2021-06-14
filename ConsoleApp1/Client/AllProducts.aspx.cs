﻿using Client.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Client
{
    public partial class AllProducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int counter = 0;
            while (counter < 30)
            {
                try
                {
                    if (Request.QueryString["keyword"] != null)
                    {
                        ShopHandler a = new ShopHandler();
                        DataListproducts.DataSource = a.search(Request.QueryString["keyword"].ToString());
                        DataListproducts.DataBind();
                    }
                    else
                    {
                        ShopHandler a = new ShopHandler();
                        DataListproducts.DataSource = a.getAllProducts();
                        DataListproducts.DataBind();
                    }

                    return;
                }
                catch
                {
                    Thread.Sleep(1000);
                    counter++;
                }
            }
            if (counter >= 10)
            {
                //error message
                throw new Exception("server not responding");
            }
        }

        protected void DataListproducts_ItemCommand1(object source, DataListCommandEventArgs e)
        {

            if (e.CommandName == "add_to_cart")
            {
                string[] cargs = e.CommandArgument.ToString().Split(',');
                Session["productName"] = cargs[0];
                Session["descerption"] = cargs[1];
                Session["barcode"] = cargs[2];
                Session["catagory"] = cargs[3];
                Session["price"] = cargs[4];
                Session["nameShop"] = cargs[5];
                Response.Redirect("~/Product.aspx");


            }
        }

        protected void DataListproducts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
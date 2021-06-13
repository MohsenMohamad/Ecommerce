﻿using Client.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Client
{
    public partial class History : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UserHandler a = new UserHandler();

                Data_History.DataSource = a.GetUserPurchaseHistory(Session["username"].ToString());
                Data_History.DataBind();
            }
        }

        protected void Data_History_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Client.Code;
using WebSocketSharp;

namespace Client
{
    public partial class m1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int counter = 0;
            while (counter < 20)
            {
                try
                { 

                
            Labelname.Visible = true;
            OpenShop.Visible = false;
            MyShops.Visible = false;
            Notifications.Visible = false;
            InitSystem.Visible = false;
            EditUser.Visible = false;
            History.Visible = false;

            if (Session["isLogin"] != null)
            {
                OpenShop.Visible = true;
                ButtonLogOut.Visible = true;
                MyShops.Visible = true;
                Notifications.Visible = true;
                EditUser.Visible = true;
                History.Visible = true;
                divheader.Visible = false;
                Labelname.Text = "Hello " + Session["username"].ToString();

                if (Session["admin"] != null)
                {
                    InitSystem.Visible = true;
                }
                else
                {
                    InitSystem.Visible = false;
                }
            }
            else if (Session["username"] == null)
            {
                UserHandler h = new UserHandler();
                Session["username"] = h.GuestLogin().ToString();
                Labelname.Text = "Hello " + Session["username"].ToString();
            }
                    return;
                }
                catch
                {
                    Thread.Sleep(1000);
                    counter++;
                }
            }
            if (counter > 20)
            {
                //error message
                Response.Redirect("~/Fail_Database.aspx");
            }
        }



        //todo make sure of that

        /*if ((txtusername.Text.Trim().Length != 0) && (txtpassword.Text.Trim().Length != 0))
        {
            ButtonLogOut.Visible = true;
            Login_table.Visible = false;
            Session["isLogin"] = "true";
        }
        else
        {

            if (txtusername.Text.Trim().Length == 0)
            {
                if (txtpassword.Text.Trim().Length == 0) LabelPasword.Visible = true;
                LabelUsername.Visible = true;
            }
            if (txtpassword.Text.Trim().Length == 0)
            {
                if (txtusername.Text.Trim().Length == 0) LabelUsername.Visible = true;
                LabelPasword.Visible = true;
            }
        }*/

        protected void ButtonLogOut_Click(object sender, EventArgs e)
        {
            new UserHandler().Logout(Session["username"].ToString());
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/Home.aspx");
        }

        protected void HomeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home.aspx");
        }

        protected void Allshops_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Shops.aspx");
        }

        protected void OpenShop_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Open_shop.aspx");
        }

        protected void Allshops_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/Shops.aspx");
        }

        protected void OpenShop_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/Open_shop.aspx");
        }

        protected void ImageButtoncart_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Cart.aspx");
        }

        protected void MyShops_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MyShops.aspx");
        }


        protected void Notifications_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Notifications.aspx");
        }

        protected void InitSystem_Click(object sender, EventArgs e)
        {
            /* ShopHandler s = new ShopHandler();
             s.InitSystem();
             Response.Redirect("~/Home.aspx");
          */
            var selectedPath = "";

            var t = new Thread(() =>
            {
                var saveFileDialog1 = new OpenFileDialog
                {
                    Filter = "JSON Files (*.json)|*.json", FilterIndex = 2, RestoreDirectory = true , CheckPathExists = true,
                    CheckFileExists = true
                };


                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    selectedPath = saveFileDialog1.FileName;
                }
            });

            // Run your code from a thread that joins the STA Thread
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();

            if(selectedPath.IsNullOrEmpty()) return;
            
            var us = new UserHandler();

            var msg = us.InitByStateFile(selectedPath);

            if (msg.Equals("\"True\""))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage",
                    "alert('" + "State File Loaded Successfully!" + "')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage",
                    "alert('" + msg + "')", true);
            }
            
        }

        protected void History_Click(object sender, EventArgs e)
        {
            Session["editshop"] = null;
            Response.Redirect("~/History.aspx");
        }

        protected void EditUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/EditUser.aspx");
        }


        protected void allproduct_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/AllProducts.aspx");
        }
    }
}
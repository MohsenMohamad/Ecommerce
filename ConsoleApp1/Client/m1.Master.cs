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
            LabelPasword.Visible = false;
            LabelUsername.Visible = false;
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
                Login_table.Visible = false;
                ButtonLogOut.Visible = true;
                MyShops.Visible = true;
                Notifications.Visible = true;
                EditUser.Visible = true;
                History.Visible = true;

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
                Labelname.Visible = true;
            }
            else
            {
                Labelname.Text = "Hello " + Session["username"].ToString();
                Labelname.Visible = true;
            }
        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            if ((txtusername.Text.Trim().Length == 0) || (txtpassword.Text.Trim().Length == 0))
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
            }
            else
            {
                //  Console.WriteLine("unKnown error !");
                string msg = new UserHandler().Login(txtusername.Text, txtpassword.Text);
                if (msg.Equals("\"True\""))
                {
                    ButtonLogOut.Visible = true;
                    Login_table.Visible = false;
                    Session["isLogin"] = "true";
                    Session["username"] = txtusername.Text;
                    Labelname.Visible = true;
                    Labelname.Text = "Hello " + txtusername.Text;
                    Session["userid"] = msg;
                    OpenShop.Visible = true;
                    Notifications.Visible = true;
                    MyShops.Visible = true;
                    EditUser.Visible = true;
                    History.Visible = true;
                    Session["admin"] = null;

                    Session["basket"] = null;
                    if (txtusername.Text.ToString().Equals("admin"))
                    {
                        Session["admin"] = "admin";
                        InitSystem.Visible = true;
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage",
                        "alert('" + msg + "')", true);
                    /*string message = ex.Message;
                    string script = "alert(\""+ message + "\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                          "ServerControlScript", script, true);*/
                }
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox2.Text.Trim().Length == 0)
            {
            }
            else
            {
                Response.Redirect("~/Home.aspx?keyword=" + TextBox2.Text.ToString());
            }
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
            Response.Redirect("~/History.aspx");
        }

        protected void EditUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/EditUser.aspx");
        }
    }
}
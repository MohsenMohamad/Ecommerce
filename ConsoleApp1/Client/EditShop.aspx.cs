﻿using Client.Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Client
{
    public partial class EditShop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // Label1.Text = "Select what you want to edit" + Session["editshop"].ToString();
                table1.Visible = false;
                table2.Visible = false;
                table3.Visible = false;
                table4.Visible = false;
                table5.Visible = false;
                table6.Visible = false;
                table7.Visible = false;
                table8.Visible = false;
                table9.Visible = false;
                table10.Visible = false;
                table11.Visible = false;
                table12.Visible = false;
                table13.Visible = false;
                table14.Visible = false;
                table15.Visible = false;
                Labelerrorbarcode.Visible = false;
                firegif.Visible = true;

            }
            else { }

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList2.Items.Clear();
            DropDownList3.Items.Clear();
            DropDownList4.Items.Clear();
            DropDownList5.Items.Clear();
            DropDownList7.Items.Clear();
            DropDownList8.Items.Clear();


            if (DropDownList1.SelectedItem.Text == "Select")
            {
                table1.Visible = false;
                table2.Visible = false;
                table3.Visible = false;
                table4.Visible = false;
                table5.Visible = false;
                table6.Visible = false;
                table7.Visible = false;
                table8.Visible = false;
                table9.Visible = false;
                table10.Visible = false;
                table11.Visible = false;
                table12.Visible = false;
                table13.Visible = false;
                table14.Visible = false;
                table15.Visible = false;


            }

            if (DropDownList1.SelectedItem.Text == "Add New Item")
            {

                table1.Visible = true;
                table2.Visible = false;
                table3.Visible = false;
                table4.Visible = false;
                table5.Visible = false;
                table6.Visible = false;
                table7.Visible = false;
                table8.Visible = false;
                table9.Visible = false;
                table10.Visible = false;
                table11.Visible = false;
                table12.Visible = false;
                table13.Visible = false;
                table14.Visible = false;
                table15.Visible = false;




            }
            if (DropDownList1.SelectedItem.Text == "Add New Manager")
            {
                table1.Visible = false;
                table2.Visible = true;
                table3.Visible = false;
                table4.Visible = false;
                table5.Visible = false;
                table6.Visible = false;
                table7.Visible = false;
                table8.Visible = false;
                table9.Visible = false;
                table10.Visible = false;
                table11.Visible = false;
                table12.Visible = false;
                table13.Visible = false;
                table14.Visible = false;
                table15.Visible = false;


                ShopHandler b = new ShopHandler();
                DataSet d = b.GetAllUserNamesInSystem();
                DataSet m = b.GetStoreManagers(Session["editshop"].ToString());
                int c = 1;


                List<string> d1 = new List<string>();

                d1.Add(Session["username"].ToString());
                for (int j = 0; j < m.Tables[0].Rows.Count; j++)
                {
                    d1.Add(m.Tables[0].Rows[j]["username"].ToString());
                }

                DropDownList2.Items.Insert(0, new ListItem("please select a Manager"));

                for (int i = 0; i < d.Tables[0].Rows.Count; i++)
                {
                    if (!(d1.Contains(d.Tables[0].Rows[i]["username"].ToString())))
                    {
                        DropDownList2.Items.Insert(c, new ListItem(d.Tables[0].Rows[i]["username"].ToString()));
                        c++;
                    }
                }



            }
            if (DropDownList1.SelectedItem.Text == "Add New Owner")
            {

                table1.Visible = false;
                table2.Visible = false;
                table3.Visible = true;
                table4.Visible = false;
                table5.Visible = false;
                table6.Visible = false;
                table7.Visible = false;
                table8.Visible = false;
                table9.Visible = false;
                table10.Visible = false;
                table11.Visible = false;
                table12.Visible = false;
                table13.Visible = false;
                table14.Visible = false;
                table15.Visible = false;



                ShopHandler b = new ShopHandler();
                DataSet d = b.GetAllUserNamesInSystem();


                DataSet m = b.GetStoreOwners(Session["editshop"].ToString());
                int c = 1;


                List<string> d1 = new List<string>();

                d1.Add(Session["username"].ToString());
                for (int j = 0; j < m.Tables[0].Rows.Count; j++)
                {
                    d1.Add(m.Tables[0].Rows[j]["username"].ToString());
                }

                DropDownList3.Items.Insert(0, new ListItem("please select a Owner"));

                for (int i = 0; i < d.Tables[0].Rows.Count; i++)
                {
                    if (!(d1.Contains(d.Tables[0].Rows[i]["username"].ToString())))
                    {
                        DropDownList3.Items.Insert(c, new ListItem(d.Tables[0].Rows[i]["username"].ToString()));
                        c++;
                    }
                }


            }
            if (DropDownList1.SelectedItem.Text == "Fire Manager")
            {

                table1.Visible = false;
                table2.Visible = false;
                table3.Visible = false;
                table4.Visible = true;
                table5.Visible = false;
                table6.Visible = false;
                table7.Visible = false;
                table8.Visible = false;
                table9.Visible = false;
                table10.Visible = false;
                table11.Visible = false;
                table12.Visible = false;
                table13.Visible = false;
                table14.Visible = false;
                table15.Visible = false;


                ShopHandler b = new ShopHandler();
                DataSet d = b.GetStoreManagers(Session["editshop"].ToString());
                DropDownList4.Items.Add(new ListItem("please select a Manager", "0"));
                for (int i = 0; i < d.Tables[0].Rows.Count; i++)
                {

                    DropDownList4.Items.Insert(i, new ListItem(d.Tables[0].Rows[i]["username"].ToString()));
                }
                firegif.Visible = true;

            }
            if (DropDownList1.SelectedItem.Text == "Fire Owner")
            {

                table1.Visible = false;
                table2.Visible = false;
                table3.Visible = false;
                table4.Visible = false;
                table5.Visible = true;
                table6.Visible = false;
                table7.Visible = false;
                table8.Visible = false;
                table9.Visible = false;
                table10.Visible = false;
                table11.Visible = false;
                table12.Visible = false;
                table13.Visible = false;
                table14.Visible = false;
                table15.Visible = false;



                ShopHandler b = new ShopHandler();
                DataSet d = b.GetStoreOwners(Session["editshop"].ToString());
                DropDownList5.Items.Add(new ListItem("please select a Owner", "0"));
                for (int i = 0; i < d.Tables[0].Rows.Count; i++)
                {
                    if (!d.Tables[0].Rows[i]["username"].ToString().Equals(Session["username"]))
                    {
                        DropDownList5.Items.Insert(i, new ListItem(d.Tables[0].Rows[i]["username"].ToString()));
                    }
                }
                firegif.Visible = true;


            }
            if (DropDownList1.SelectedItem.Text == "Policies")
            {

                table1.Visible = false;
                table2.Visible = false;
                table3.Visible = false;
                table4.Visible = false;
                table5.Visible = false;
                table6.Visible = true;
                table7.Visible = false;
                table8.Visible = false;
                table9.Visible = false;
                table10.Visible = false;
                table11.Visible = false;
                table12.Visible = false;
                table13.Visible = false;
                table14.Visible = false;
                table15.Visible = false;

            }
            if (DropDownList1.SelectedItem.Text == "Shop Discount")
            {

                table1.Visible = false;
                table2.Visible = false;
                table3.Visible = false;
                table4.Visible = false;
                table5.Visible = false;
                table6.Visible = false;
                table7.Visible = false;
                table8.Visible = false;
                table9.Visible = false;
                table10.Visible = false;
                table11.Visible = true;
                table12.Visible = false;
                table13.Visible = false;
                table14.Visible = false;
                table15.Visible = false;

            }
            if (DropDownList1.SelectedItem.Text == "Item Discount")
            {

                table1.Visible = false;
                table2.Visible = false;
                table3.Visible = false;
                table4.Visible = false;
                table5.Visible = false;
                table6.Visible = false;
                table7.Visible = false;
                table8.Visible = false;
                table9.Visible = false;
                table10.Visible = false;
                table11.Visible = false;
                table12.Visible = true;
                table13.Visible = false;
                table14.Visible = false;
                table15.Visible = false;


                ShopHandler b = new ShopHandler();
                DataSet d = b.GetStoreProducts(Session["editshop"].ToString());
                DropDownList7.Items.Add(new ListItem("please select a Item", "0"));
                for (int i = 0; i < d.Tables[0].Rows.Count; i++)
                {
                    DropDownList7.Items.Insert(i, new ListItem(d.Tables[0].Rows[i]["productName"].ToString() + " ," + d.Tables[0].Rows[i]["barcode"].ToString()));
                }

            }
            if (DropDownList1.SelectedItem.Text == "Conditional Discount")
            {

                table1.Visible = false;
                table2.Visible = false;
                table3.Visible = false;
                table4.Visible = false;
                table5.Visible = false;
                table6.Visible = false;
                table7.Visible = false;
                table8.Visible = false;
                table9.Visible = false;
                table10.Visible = false;
                table11.Visible = false;
                table12.Visible = false;
                table13.Visible = true;
                table14.Visible = false;
                table15.Visible = false;

            }
            if (DropDownList1.SelectedItem.Text == "Edit Manager")
            {

                table1.Visible = false;
                table2.Visible = false;
                table3.Visible = false;
                table4.Visible = false;
                table5.Visible = false;
                table6.Visible = false;
                table7.Visible = false;
                table8.Visible = false;
                table9.Visible = false;
                table10.Visible = false;
                table11.Visible = false;
                table12.Visible = false;
                table13.Visible = false;
                table14.Visible = true;
                table15.Visible = false;


                ShopHandler b = new ShopHandler();
                DataSet d = b.GetStoreManagers(Session["editshop"].ToString());
                DropDownList8.Items.Add(new ListItem("please select a Manager", "0"));
                for (int i = 0; i < d.Tables[0].Rows.Count; i++)
                {

                    DropDownList8.Items.Insert(i, new ListItem(d.Tables[0].Rows[i]["username"].ToString()));
                }

            }

        }

        protected void DropDownList6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList6.SelectedItem.Text == "Product")
            {
                table7.Visible = true;
                table8.Visible = false;
                table9.Visible = false;
                table10.Visible = false;
            }
            if (DropDownList6.SelectedItem.Text == "Category")
            {
                table7.Visible = false;
                table8.Visible = true;
                table9.Visible = false;
                table10.Visible = false;
            }
            if (DropDownList6.SelectedItem.Text == "User")
            {
                table7.Visible = false;
                table8.Visible = false;
                table9.Visible = true;
                table10.Visible = false;
            }
            if (DropDownList6.SelectedItem.Text == "Cart")
            {
                table7.Visible = false;
                table8.Visible = false;
                table9.Visible = false;
                table10.Visible = true;
            }
            if (DropDownList6.SelectedItem.Text == "CompositePolicy")
            {
                table7.Visible = false;
                table8.Visible = false;
                table9.Visible = false;
                table10.Visible = false;
                table15.Visible = true;

            }
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            ShopHandler a = new ShopHandler();
            UserHandler u = new UserHandler();
            /* if (!a.AddNewProductToSystem(TextBoxbarcode.Text.ToString(), TextBoxproductName.Text.ToString(), TextBoxdescription.Text.ToString()
                 , double.Parse(TextBoxprice.Text.ToString()), TextBoxcategories.Text.ToString()))
             {
                 Labelerrorbarcode.Visible = true;
             }
             else
             {*/
            //  a.AddItemToStore(Session["editshop"].ToString(), TextBoxbarcode.Text.ToString(), int.Parse(TextBoxAmount.Text.ToString()));
            if (Permissions.GetPermissions(a.GetPermissions(Session["username"].ToString(), Session["editshop"].ToString())).Contains("AddNewItem") || (u.IsOwner(Session["editshop"].ToString(), Session["username"].ToString())))
            {
                string msg = a.AddItemToStore(Session["username"].ToString(), TextBoxbarcode.Text.ToString(), TextBoxproductName.Text.ToString(), int.Parse(TextBoxAmount.Text.ToString()),
                      int.Parse(TextBoxprice.Text.ToString()), Session["editshop"].ToString(), TextBoxdescription.Text.ToString(), TextBoxcategories.Text.ToString());
                if (msg.Equals("\"True\""))
                {
                    table1.Visible = false;
                    DropDownList1.SelectedIndex = DropDownList1.Items.IndexOf(DropDownList1.Items.FindByText("Select"));
                }
                else if (msg.Equals("\"False\""))
                {
                    string msg2 = a.UpdateProductAmountInStore(Session["username"].ToString(), Session["editshop"].ToString(), TextBoxbarcode.Text.ToString(), int.Parse(TextBoxAmount.Text.ToString()));
                    if (msg2.Equals("\"True\""))
                    {
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + msg2 + "')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + msg + "')", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('you not have Premission')", true);
            }
        }

        protected void Buttonaddmanager_Click(object sender, EventArgs e)
        {
            UserHandler u = new UserHandler();
            string msg = u.MakeNewManger(Session["editshop"].ToString(), Session["username"].ToString(), DropDownList2.SelectedItem.Text.ToString(), 1);
            if (msg.Equals("\"True\""))
            {
                table2.Visible = false;
                DropDownList2.Items.Clear();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + msg + "')", true);
            }
            DropDownList1.SelectedIndex = DropDownList1.Items.IndexOf(DropDownList1.Items.FindByText("Select"));


        }

        protected void Button_Click1(object sender, EventArgs e)
        {
            UserHandler u = new UserHandler();
            string msg = u.MakeNewOwner(Session["editshop"].ToString(), Session["username"].ToString(), DropDownList3.SelectedItem.Text.ToString(), 1);
            if (msg.Equals("\"True\""))
            {
                table3.Visible = false;
                DropDownList3.Items.Clear();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + msg + "')", true);
            }
            DropDownList1.SelectedIndex = DropDownList1.Items.IndexOf(DropDownList1.Items.FindByText("Select"));


        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            UserHandler u = new UserHandler();
            string msg = u.removeManager(Session["username"].ToString(), Session["editshop"].ToString(), DropDownList4.SelectedItem.Text.ToString());
            if (msg.Equals("\"True\""))
            {
                table4.Visible = false;
                DropDownList4.Items.Clear();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + msg + "')", true);
            }
            DropDownList1.SelectedIndex = DropDownList1.Items.IndexOf(DropDownList1.Items.FindByText("Select"));

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            UserHandler u = new UserHandler();
            string msg = u.removeOwner(Session["username"].ToString(), Session["editshop"].ToString(), DropDownList5.SelectedItem.Text.ToString());
            if (msg.Equals("\"True\""))
            {
                table5.Visible = false;
                DropDownList5.Items.Clear();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + msg + "')", true);
            }
            DropDownList1.SelectedIndex = DropDownList1.Items.IndexOf(DropDownList1.Items.FindByText("Select"));
            firegif.Visible = true;

        }

        protected void AddProduct_Click(object sender, EventArgs e)
        {
            ShopHandler sh = new ShopHandler();
            UserHandler u = new UserHandler();
            if (Permissions.GetPermissions(sh.GetPermissions(Session["username"].ToString(), Session["editshop"].ToString())).Contains("AddNewPolicy") || (u.IsOwner(Session["editshop"].ToString(), Session["username"].ToString())))
            {
                sh.AddProductPolicies(Session["editshop"].ToString(), TextBox3.Text.ToString(), int.Parse(TextBox4.Text.ToString()));
                DropDownList1.SelectedIndex = DropDownList1.Items.IndexOf(DropDownList1.Items.FindByText("Select"));
                DropDownList6.SelectedIndex = DropDownList1.Items.IndexOf(DropDownList1.Items.FindByText("Select"));
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('you not have Premission')", true);
            }
            table6.Visible = false;
            table7.Visible = false;

        }

        protected void AddCategory_Click(object sender, EventArgs e)
        {
            ShopHandler sh = new ShopHandler();
            UserHandler u = new UserHandler();
            if (Permissions.GetPermissions(sh.GetPermissions(Session["username"].ToString(), Session["editshop"].ToString())).Contains("AddNewPolicy") || (u.IsOwner(Session["editshop"].ToString(), Session["username"].ToString())))
            {
                sh.AddCategortPolicies(Session["editshop"].ToString(), TextBox1.Text.ToString(), int.Parse(TextBox2.Text.ToString()), int.Parse(TextBox8.Text.ToString()));
                DropDownList1.SelectedIndex = DropDownList1.Items.IndexOf(DropDownList1.Items.FindByText("Select"));
                DropDownList6.SelectedIndex = DropDownList1.Items.IndexOf(DropDownList1.Items.FindByText("Select"));
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('you not have Premission')", true);
            }

            table6.Visible = false;
            table8.Visible = false;

        }

        protected void AddUser_Click(object sender, EventArgs e)
        {
            ShopHandler sh = new ShopHandler();
            UserHandler u = new UserHandler();

            if (Permissions.GetPermissions(sh.GetPermissions(Session["username"].ToString(), Session["editshop"].ToString())).Contains("AddNewPolicy") || (u.IsOwner(Session["editshop"].ToString(), Session["username"].ToString())))
            {
                sh.AddUserPolicies(Session["editshop"].ToString(), TextBox5.Text.ToString());
                DropDownList1.SelectedIndex = DropDownList1.Items.IndexOf(DropDownList1.Items.FindByText("Select"));
                DropDownList6.SelectedIndex = DropDownList1.Items.IndexOf(DropDownList1.Items.FindByText("Select"));
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('you not have Premission')", true);

            }

            table6.Visible = false;
            table9.Visible = false;


        }

        protected void AddCart_Click(object sender, EventArgs e)
        {
            ShopHandler sh = new ShopHandler();
            UserHandler u = new UserHandler();

            if (Permissions.GetPermissions(sh.GetPermissions(Session["username"].ToString(), Session["editshop"].ToString())).Contains("AddNewPolicy") || (u.IsOwner(Session["editshop"].ToString(), Session["username"].ToString())))
            {
                sh.AddCartrPolicies(Session["editshop"].ToString(), int.Parse(TextBox7.Text.ToString()));
                DropDownList1.SelectedIndex = DropDownList1.Items.IndexOf(DropDownList1.Items.FindByText("Select"));
                DropDownList6.SelectedIndex = DropDownList1.Items.IndexOf(DropDownList1.Items.FindByText("Select"));
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('you not have Premission')", true);
            }
            table6.Visible = false;
            table10.Visible = false;

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            ShopHandler sh = new ShopHandler();

            UserHandler u = new UserHandler();

            if (Permissions.GetPermissions(sh.GetPermissions(Session["username"].ToString(), Session["editshop"].ToString())).Contains("AddNewDiscount") || (u.IsOwner(Session["editshop"].ToString(), Session["username"].ToString())))
            {
                sh.addStoreDiscount(Session["editshop"].ToString(), int.Parse(TextBox6.Text.ToString()));
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('you not have Premission')", true);
            }
            DropDownList1.SelectedIndex = DropDownList1.Items.IndexOf(DropDownList1.Items.FindByText("Select"));
            table11.Visible = false;

        }

        protected void Button5_Click(object sender, EventArgs e)
        {

            ShopHandler sh = new ShopHandler();
            UserHandler u = new UserHandler();


            if (Permissions.GetPermissions(sh.GetPermissions(Session["username"].ToString(), Session["editshop"].ToString())).Contains("AddNewDiscount") || (u.IsOwner(Session["editshop"].ToString(), Session["username"].ToString())))
            {
                string barcodeitem = DropDownList7.Text.ToString();
                var arritem = barcodeitem.Split(',');
                sh.addPublicDiscountToItem(Session["editshop"].ToString(), arritem[1].ToString(), int.Parse(TextBox10.Text.ToString()));
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('you not have Premission')", true);
            }
            DropDownList1.SelectedIndex = DropDownList1.Items.IndexOf(DropDownList1.Items.FindByText("Select"));
            table12.Visible = false;

        }

        protected void DropDownList7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            ShopHandler sh = new ShopHandler();
            UserHandler u = new UserHandler();

            if (Permissions.GetPermissions(sh.GetPermissions(Session["username"].ToString(), Session["editshop"].ToString())).Contains("AddNewDiscount") || (u.IsOwner(Session["editshop"].ToString(), Session["username"].ToString())))
            {
                sh.addConditionalDiscount(Session["editshop"].ToString(), int.Parse(TextBox14.Text.ToString()), txt1.InnerText);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('you not have Premission')", true);
            }
            DropDownList1.SelectedIndex = DropDownList1.Items.IndexOf(DropDownList1.Items.FindByText("Select"));
            table13.Visible = false;
        }

        protected void DropDownList8_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            ShopHandler sh = new ShopHandler();
            UserHandler u = new UserHandler();


            if ((u.IsOwner(Session["editshop"].ToString(), Session["username"].ToString())))
            {
                if (DropDownList9.SelectedValue.Equals("1"))
                {
                    var msg = sh.UpdatePermissions(DropDownList8.SelectedItem.Text.ToString(), Session["editshop"].ToString(), ((int)Permissions.StorePermissions.AddNewItem));
                    if (msg.Equals("\"True\""))
                    {
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + msg + "')", true);
                    }
                }
                if (DropDownList9.SelectedValue.Equals("2"))
                {
                    var msg = sh.UpdatePermissions(DropDownList8.SelectedItem.Text.ToString(), Session["editshop"].ToString(), ((int)Permissions.StorePermissions.AddNewPolicy));
                    if (msg.Equals("\"True\""))
                    {
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + msg + "')", true);
                    }
                }
                if (DropDownList9.SelectedValue.Equals("3"))
                {
                    var msg = sh.UpdatePermissions(DropDownList8.SelectedItem.Text.ToString(), Session["editshop"].ToString(), ((int)Permissions.StorePermissions.AddNewDiscount));
                    if (msg.Equals("\"True\""))
                    {
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + msg + "')", true);
                    }
                }
            }

            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('youre not an owner !!!!!!!!!!!!!')", true);
            }
            DropDownList1.SelectedIndex = DropDownList1.Items.IndexOf(DropDownList1.Items.FindByText("Select"));
            table14.Visible = false;
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            ShopHandler sh = new ShopHandler();
            sh.CompositePolicy(Session["editshop"].ToString(), txt2.InnerText);
        }
    }
}
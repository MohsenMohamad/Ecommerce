using Client.Code;
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
                Label1.Text = "Select what you want to edit"+ Session["editshop"].ToString();
                table1.Visible = false;
                table2.Visible = false;
                table3.Visible = false;
                table4.Visible = false;
                table5.Visible = false;
                table6.Visible = false;
                Labelerrorbarcode.Visible = false;

            }
            else { }

            }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList2.Items.Clear();
            DropDownList3.Items.Clear();
            DropDownList4.Items.Clear();
            if (DropDownList1.SelectedItem.Text == "Select")
            {
                table1.Visible = false;
                table2.Visible = false;
                table3.Visible = false;
                table4.Visible = false;
                table5.Visible = false;
                table6.Visible = false;

            }

            if (DropDownList1.SelectedItem.Text == "Add New Item") {
                
                table1.Visible = true;
                table2.Visible = false;
                table3.Visible = false;
                table4.Visible = false;
                table5.Visible = false;
                table6.Visible = false;

            }
            if (DropDownList1.SelectedItem.Text == "Add New Manager")
            {
                table1.Visible = false;
                table2.Visible = true;
                table3.Visible = false;
                table4.Visible = false;
                table5.Visible = false;
                table6.Visible = false;

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

                ShopHandler b = new ShopHandler();
                DataSet d = b.GetStoreManagers(Session["editshop"].ToString());
                DropDownList4.Items.Add(new ListItem("please select a Manager", "0"));
                for (int i = 0; i < d.Tables[0].Rows.Count; i++)
                {

                    DropDownList4.Items.Insert(i, new ListItem(d.Tables[0].Rows[i]["username"].ToString()));
                }

            }
            if (DropDownList1.SelectedItem.Text == "Fire Owner")
            {

                table1.Visible = false;
                table2.Visible = false;
                table3.Visible = false;
                table4.Visible = false;
                table5.Visible = true;
                table6.Visible = false;

                ShopHandler b = new ShopHandler();
                DataSet d = b.GetStoreOwners(Session["editshop"].ToString());
                DropDownList5.Items.Add(new ListItem("please select a Owner", "0"));
                for (int i = 0; i < d.Tables[0].Rows.Count; i++)
                {

                    DropDownList5.Items.Insert(i, new ListItem(d.Tables[0].Rows[i]["username"].ToString()));
                }


            }
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            ShopHandler a = new ShopHandler();
            if (!a.AddNewProductToSystem(TextBoxbarcode.Text.ToString(), TextBoxproductName.Text.ToString(), TextBoxdescription.Text.ToString()
                , double.Parse(TextBoxprice.Text.ToString()), TextBoxcategories.Text.ToString()))
            {

                Labelerrorbarcode.Visible = true;

            }
            else
            {
                a.AddItemToStore(Session["editshop"].ToString(), TextBoxbarcode.Text.ToString(), int.Parse(TextBoxAmount.Text.ToString()));
                table1.Visible = false;
                DropDownList1.SelectedIndex = DropDownList1.Items.IndexOf(DropDownList1.Items.FindByText("Select"));
            }

        }

        protected void Buttonaddmanager_Click(object sender, EventArgs e)
        {
            UserHandler u = new UserHandler();
            if (u.MakeNewManger(Session["editshop"].ToString(), Session["username"].ToString(), DropDownList2.SelectedItem.Text.ToString(), 1))
            {
                table2.Visible = false;
                DropDownList2.Items.Clear(); 
            }
                DropDownList1.SelectedIndex = DropDownList1.Items.IndexOf(DropDownList1.Items.FindByText("Select"));
           

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            UserHandler u = new UserHandler();
            if (u.MakeNewOwner(Session["editshop"].ToString(), Session["username"].ToString(), DropDownList3.SelectedItem.Text.ToString(), 1))
            {
                table3.Visible = false;
                DropDownList3.Items.Clear();
            }
            DropDownList1.SelectedIndex = DropDownList1.Items.IndexOf(DropDownList1.Items.FindByText("Select"));


        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            UserHandler u = new UserHandler();
            if (u.removeManager( Session["username"].ToString(), Session["editshop"].ToString(), DropDownList4.SelectedItem.Text.ToString()))
            {
                table4.Visible = false;
                DropDownList4.Items.Clear();
            }
            DropDownList1.SelectedIndex = DropDownList1.Items.IndexOf(DropDownList1.Items.FindByText("Select"));

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            UserHandler u = new UserHandler();
            if (u.removeOwner(Session["username"].ToString(), Session["editshop"].ToString(), DropDownList5.SelectedItem.Text.ToString()))
            {
                table5.Visible = false;
                DropDownList5.Items.Clear();
            }
            DropDownList1.SelectedIndex = DropDownList1.Items.IndexOf(DropDownList1.Items.FindByText("Select"));

        }
    }
}
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
               

            }
            if (DropDownList1.SelectedItem.Text == "Add New Owner")
            {

                table1.Visible = false;
                table2.Visible = false;
                table3.Visible = true;
                table4.Visible = false;
                table5.Visible = false;
                table6.Visible = false;

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
                List<ListItem> items = new List<ListItem>();
                DropDownList4.Items.Add(new ListItem("please select a menu", "-1"));
                for (int i = 0; i < d.Tables[0].Rows.Count; i++)
                {

                    DropDownList2.Items.Insert(i, new ListItem(d.Tables[0].Rows[i]["username"].ToString()));
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
            }
        }

        protected void Buttonaddmanager_Click(object sender, EventArgs e)
        {

        }
    }
}
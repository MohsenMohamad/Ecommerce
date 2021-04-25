using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Client.Code
{
    public class ShopHandler
    {

        public ShopHandler() { }

        public DataSet getAllProducts()
        {
            string param = "";
            JArray jarray = (JArray)JsonConvert.DeserializeObject(System.SendApi(System.Service_type.SHOP, "getAllProducts", param).ToString());
            DataTable t1 = new DataTable("products");
            t1.Columns.Add("productName");
            t1.Columns.Add("descerption");
            t1.Columns.Add("barcode");
            t1.Columns.Add("price");
            t1.Columns.Add("catagory");

            for (int i = 0; i < jarray.Count; i++) {
                t1.Rows.Add(jarray[i][0], jarray[i][1], jarray[i][2], jarray[i][3], jarray[i][4]);
            }

            DataSet d1 = new DataSet("products");
            d1.Tables.Add(t1);
            return d1;

        }

        public bool OpenShop(string shopName, string userName, string policy)
        {
            string param = string.Format("shopName={0}&userName={1}&policy={2}", shopName, userName, policy);
            return bool.Parse(System.SendApi(System.Service_type.SHOP, "OpenShop", param));
        }

        public DataSet getAllStores() {
            string param = "";
            JArray jarray = (JArray)JsonConvert.DeserializeObject(System.SendApi(System.Service_type.SHOP, "getAllStores", param).ToString());
            DataTable t1 = new DataTable("Stores");
            t1.Columns.Add("storeName");
            t1.Columns.Add("ownerName");
            t1.Columns.Add("sellingpolicy");
            t1.Columns.Add("message");

            for (int i = 0; i < jarray.Count; i++)
            {
                t1.Rows.Add(jarray[i][0], jarray[i][1], jarray[i][2], jarray[i][3]);
            }

            DataSet d1 = new DataSet("Stores");
            d1.Tables.Add(t1);
            return d1;
        }
    }
}
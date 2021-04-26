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
            JArray jarray = (JArray)JsonConvert.DeserializeObject(System.SendApi(System.Service_type.SHOP, "GetStoresProducts", param).ToString());
            DataTable t1 = new DataTable("products");
            t1.Columns.Add("productName");
            t1.Columns.Add("descerption");
            t1.Columns.Add("barcode");
            t1.Columns.Add("price");
            t1.Columns.Add("catagory");
            t1.Columns.Add("nameShop");

            for (int i = 0; i < jarray.Count; i++) {
                t1.Rows.Add(jarray[i][0], jarray[i][1], jarray[i][2], jarray[i][3], jarray[i][4],jarray[i][5]);
            }

            DataSet d1 = new DataSet("products");
            d1.Tables.Add(t1);
            return d1;

        }

        public bool OpenShop(string userName, string shopName, string policy)
        {
            string param = string.Format("userName={0}&shopName={1}&policy={2}", userName, shopName, policy);
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

        public bool AddProductToBasket(string userName, string storeName, string productBarCode, int amount)
        {

            string param = string.Format("userName={0}&storeName={1}&productBarCode={2}&amount={3}", userName, storeName, productBarCode,amount);
            return bool.Parse(System.SendApi(System.Service_type.SHOP, "AddProductToBasket", param));
        }

        public DataSet GetUserBaskets(string userName)
        {

            string param = string.Format("userName={0}", userName);
            JArray jarray = (JArray)JsonConvert.DeserializeObject(System.SendApi(System.Service_type.SHOP, "GetUserBaskets", param).ToString());
            DataTable t1 = new DataTable("products");
            t1.Columns.Add("productName");
            t1.Columns.Add("descerption");
            t1.Columns.Add("barcode");
            t1.Columns.Add("price");
            t1.Columns.Add("catagory");
            t1.Columns.Add("nameShop");
            t1.Columns.Add("Amount");

            for (int i = 0; i < jarray.Count; i++)
            {
                t1.Rows.Add(jarray[i][0], jarray[i][1], jarray[i][2], jarray[i][3], jarray[i][4], jarray[i][5] , jarray[i][6]);
            }

            DataSet d1 = new DataSet("products");
            d1.Tables.Add(t1);
            return d1;
        }

        
    }
}
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
            //Notifications.SendMessage("userName","message That you Want To Send");
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

        public DataSet GetUserStores(string userName)
        {
            string param = string.Format("userName={0}", userName);
            JArray jarray = (JArray)JsonConvert.DeserializeObject(System.SendApi(System.Service_type.SHOP, "GetUserStores", param).ToString());
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

        public bool AddItemToStore(string shopName, string itemBarCode, int amount)
        {
            string param = string.Format("shopName={0}&itemBarCode={1}&amount={2}", shopName, itemBarCode, amount);
            return bool.Parse(System.SendApi(System.Service_type.SHOP, "AddItemToStore", param));

        }

        public bool AddNewProductToSystem(string barcode, string productName, string description, double price,
           string categories)
        {
            
            string param = string.Format("barcode={0}&productName={1}&description={2}&price={3}&categories={4}", barcode, productName, description,price,categories);
            return bool.Parse(System.SendApi(System.Service_type.SHOP, "AddNewProductToSystem", param));
        }

        public DataSet GetStoreManagers(string storeName)
        {
            string param = string.Format("storeName={0}", storeName);
            JArray jarray = (JArray)JsonConvert.DeserializeObject(System.SendApi(System.Service_type.SHOP, "GetStoreManagers", param).ToString());
            DataTable t1 = new DataTable("manager");
            t1.Columns.Add("username");

            for (int i = 0; i < jarray.Count; i++)
            {
                t1.Rows.Add(jarray[i]);
            }

            DataSet d1 = new DataSet("manager");
            d1.Tables.Add(t1);
            return d1;
        }


        public DataSet GetStoreOwners(string storeName)
        {
            string param = string.Format("storeName={0}", storeName);
            JArray jarray = (JArray)JsonConvert.DeserializeObject(System.SendApi(System.Service_type.SHOP, "GetStoreOwners", param).ToString());
            DataTable t1 = new DataTable("owners");
            t1.Columns.Add("username");

            for (int i = 0; i < jarray.Count; i++)
            {
                t1.Rows.Add(jarray[i]);
            }

            DataSet d1 = new DataSet("owners");
            d1.Tables.Add(t1);
            return d1;
        }

        public DataSet GetAllUserNamesInSystem()
        {
            string param = "";
            JArray jarray = (JArray)JsonConvert.DeserializeObject(System.SendApi(System.Service_type.SHOP, "GetAllUserNamesInSystem", param).ToString());
            DataTable t1 = new DataTable("Users");
            t1.Columns.Add("username");

            for (int i = 0; i < jarray.Count; i++)
            {
                t1.Rows.Add(jarray[i]);
            }

            DataSet d1 = new DataSet("Users");
            d1.Tables.Add(t1);
            return d1;
        }


        public DataSet search(string keyword)
        {
            string param = string.Format("keyword={0}", keyword);
            JArray jarray = (JArray)JsonConvert.DeserializeObject(System.SendApi(System.Service_type.SHOP, "search", param).ToString());
            DataTable t1 = new DataTable("products");
            t1.Columns.Add("productName");
            t1.Columns.Add("descerption");
            t1.Columns.Add("barcode");
            t1.Columns.Add("price");
            t1.Columns.Add("catagory");
            t1.Columns.Add("nameShop");

            for (int i = 0; i < jarray.Count; i++)
            {
                t1.Rows.Add(jarray[i][0], jarray[i][1], jarray[i][2], jarray[i][3], jarray[i][4], jarray[i][5]);
            }

            DataSet d1 = new DataSet("products");
            d1.Tables.Add(t1);
            return d1;
        }




    }
}

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Web;

namespace Client.Code
{
    public class ShopHandler
    {

        public ShopHandler() { }

        public DataSet getAllProducts()
        {
            string param = "";
            JArray jarray = (JArray)JsonConvert.DeserializeObject(System.SendApi("GetStoresProducts", param).ToString());
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
            //Notifications.SendMessage("userName","message That you Want To Send");
        }

        public bool OpenShop(string userName, string shopName, string policy)
        {
            string param = string.Format("userName={0}&shopName={1}&policy={2}", userName, shopName, policy);
            return bool.Parse(System.SendApi("OpenShop", param));
        }

        public DataSet getAllStores() {
            string param = "";
            JArray jarray = (JArray)JsonConvert.DeserializeObject(System.SendApi("getAllStores", param).ToString());
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
            return bool.Parse(System.SendApi("AddProductToBasket", param));
        }

        public DataSet GetUserBaskets(string userName)
        {

            string param = string.Format("userName={0}", userName);
            JArray jarray = (JArray)JsonConvert.DeserializeObject(System.SendApi("GetUserBaskets", param).ToString());
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
            JArray jarray = (JArray)JsonConvert.DeserializeObject(System.SendApi("GetUserStores", param).ToString());
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

        public bool AddItemToStore(string ownername, string itemBarCode, string item_name, int amount, int price, string shopName, string descreption, string catagorie)
        {
            string param = string.Format("ownername={0}&itemBarCode={1}&item_name={2}&amount={3}&price={4}&shopName={5}&descreption={6}&catagorie={7}", ownername, itemBarCode, item_name, amount, price, shopName, descreption, catagorie);
            return bool.Parse(System.SendApi("AddItemToStore", param));

        }

        public bool UpdateProductAmountInStore(string userName, string storeName, string productBarcode, int amount)
        {
            string param = string.Format("userName={0}&storeName={1}&productBarcode={2}&amount={3}", userName, storeName, productBarcode, amount);
            return bool.Parse(System.SendApi("UpdateProductAmountInStore", param));
        }

        /* public bool AddNewProductToSystem(string barcode, string productName, string description, double price,
            string categories)
         {

             string param = string.Format("barcode={0}&productName={1}&description={2}&price={3}&categories={4}", barcode, productName, description,price,categories);
             return bool.Parse(System.SendApi("AddNewProductToSystem", param));
         }
 */
        public DataSet GetStoreManagers(string storeName)
        {
            string param = string.Format("storeName={0}", storeName);
            JArray jarray = (JArray)JsonConvert.DeserializeObject(System.SendApi("GetStoreManagers", param).ToString());
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
            JArray jarray = (JArray)JsonConvert.DeserializeObject(System.SendApi("GetStoreOwners", param).ToString());
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
            JArray jarray = (JArray)JsonConvert.DeserializeObject(System.SendApi("GetAllUserNamesInSystem", param).ToString());
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
            JArray jarray = (JArray)JsonConvert.DeserializeObject(System.SendApi("search", param).ToString());
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

        public bool remove_item_from_cart(string userName, string storeName, string productBarcode, int amount)
        {
            string param = string.Format("userName={0}&storeName={1}&productBarcode={2}&amount={3}", userName, storeName, productBarcode , amount);
            return bool.Parse(System.SendApi("remove_item_from_cart", param));
        }

        public bool UpdateCart(string userName, string storeName, string productBarcode, int newAmount)
        {
            string param = string.Format("userName={0}&storeName={1}&productBarcode={2}&newAmount={3}", userName, storeName, productBarcode, newAmount);
            return bool.Parse(System.SendApi("UpdateCart", param));
        }


        public bool Purchase(string userName, string creditCard)
        {
            string param = string.Format("userName={0}&creditCard={1}", userName,creditCard);
            return bool.Parse(System.SendApi("Purchase", param));

        }

        public bool InitSystem()
        {
            string param = "";
            return bool.Parse(System.SendApi("InitSystem", param));
        }




    }
}
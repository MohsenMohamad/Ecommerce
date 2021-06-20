using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
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
            t1.Columns.Add("discount");
            t1.Columns.Add("catagory");
            t1.Columns.Add("nameShop");

            for (int i = 0; i < jarray.Count; i++) {
                t1.Rows.Add(jarray[i][0], jarray[i][1], jarray[i][2], jarray[i][3], jarray[i][4],jarray[i][5], jarray[i][6]);
            }
            DataSet d1 = new DataSet("products");
            d1.Tables.Add(t1);
            return d1;
            //Notifications.SendMessage("userName","message That you Want To Send");
        }


        public DataSet getAllProductswithfilter(int min, int max)
        {
            string param = "";
            JArray jarray = (JArray)JsonConvert.DeserializeObject(System.SendApi("GetStoresProducts", param).ToString());
            DataTable t1 = new DataTable("products");
            t1.Columns.Add("productName");
            t1.Columns.Add("descerption");
            t1.Columns.Add("barcode");
            t1.Columns.Add("price");
            t1.Columns.Add("discount");
            t1.Columns.Add("catagory");
            t1.Columns.Add("nameShop");

            for (int i = 0; i < jarray.Count; i++)
            {
                if (double.Parse((string)jarray[i][3]) >= min && double.Parse((string)jarray[i][3]) <= max)
                {
                    t1.Rows.Add(jarray[i][0], jarray[i][1], jarray[i][2], jarray[i][3], jarray[i][4], jarray[i][5], jarray[i][6]);

                }
            }
            
        
            DataSet d1 = new DataSet("products");
            d1.Tables.Add(t1);
            return d1;
            //Notifications.SendMessage("userName","message That you Want To Send");
        }

        public void CounterOffer(string barcode, string price, string username, string storename, int amount, string owner, string oldprice)
        {
            string param = string.Format("barcode={0}&price={1}&username={2}&storename={3}&amount={4}&owner={5}&oldprice={6}", barcode, price, username, storename, amount, owner, oldprice);
            System.SendApi("CounterOffer", param);
        }

        public void acceptoffer(string barcode, string price, string username, string storename, int amount, string by_username)
        {
            string param = string.Format("barcode={0}&price={1}&username={2}&storename={3}&amount={4}&by_username={5}", barcode, price, username, storename, amount, by_username);
            System.SendApi("acceptoffer", param);

        }

        public void Recieve_purchase_offer(string username, string storename, string price, string barcode, int amount)
        {
            string param = string.Format("username={0}&storename={1}&price={2}&barcode={3}&amount={4}", username, storename, price, barcode, amount);
            System.SendApi("Recieve_purchase_offer", param);

        }

        public void rejectoffer(string barcode, string price, string username, string storename, int amount, string by_username)
        {
            string param = string.Format("barcode={0}&price={1}&username={2}&storename={3}&amount={4}&by_username={5}", barcode, price, username, storename, amount, by_username);
            System.SendApi("rejectoffer", param);
        }




        public DataSet GetStoreProducts(string storeName)
        {
            string param = string.Format("storeName={0}", storeName);
            JArray jarray = (JArray)JsonConvert.DeserializeObject(System.SendApi("GetStoreProducts", param).ToString());
            DataTable t1 = new DataTable("products");
            t1.Columns.Add("productName");
            t1.Columns.Add("barcode");

            for (int i = 0; i < jarray.Count; i++)
            {
                t1.Rows.Add(jarray[i][0], jarray[i][2]);
            }
            DataSet d1 = new DataSet("products");
            d1.Tables.Add(t1);
            return d1;
        }

        public int addPublicDiscountToItem(string storeName, string barcode, int percentage)
        {
            string param = string.Format("storeName={0}&barcode={1}&percentage={2}", storeName, barcode, percentage);
            return int.Parse(System.SendApi("addPublicDiscountToItem", param));
        }


        public int addStoreDiscount(string storeName, int percentage)
        {
            string param = string.Format("storeName={0}&percentage={1}", storeName, percentage);
            return int.Parse(System.SendApi("addStoreDiscount", param));
        }

        public string OpenShop(string userName, string shopName, string policy)
        {
            string param = string.Format("userName={0}&shopName={1}&policy={2}", userName, shopName, policy);
            return (System.SendApi("OpenShop", param));
        }

        public int GetPermissions(string userName, string storeName)
        {
            string param = string.Format("userName={0}&storeName={1}", userName, storeName);
            return int.Parse(System.SendApi("GetPermissions", param));
        }

        public string UpdatePermissions(string userName, string storeName, int newPermissions)
        {
            string param = string.Format("userName={0}&storeName={1}&newPermissions={2}", userName, storeName, newPermissions);
            return (System.SendApi("UpdatePermissions", param));
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

        public DataSet GetStorePurchaseHistory(string StoreName)
        {
            string param = string.Format("StoreName={0}", StoreName);
            JArray arr = (JArray)JsonConvert.DeserializeObject(System.SendApi("GetStorePurchaseHistory", param));
            DataTable t1 = new DataTable("Historys");
            t1.Columns.Add("id");
            t1.Columns.Add("History");
            if (arr != null)
            {
                for (int i = 0; i < arr.Count && arr[i] != null; i++)
                {
                    try
                    {
                        t1.Rows.Add(i, arr[i]);
                    }
                    catch
                    { }
                }
            }
            DataSet set = new DataSet("Historys");
            set.Tables.Add(t1);
            return set;

        }

        public string AddProductToBasket(string userName, string storeName, string productBarCode, int amount, double priceofone)
        {
            string param = string.Format("userName={0}&storeName={1}&productBarCode={2}&amount={3}&priceofone={4}", userName, storeName, productBarCode,amount, priceofone);
            return (System.SendApi("AddProductToBasket", param));
        }


        public DataSet GetStaff(string storeName)
        {
            string param = string.Format("storeName={0}", storeName);
            JArray arr = (JArray)JsonConvert.DeserializeObject(System.SendApi("GetStaff", param).ToString());
            DataTable t1 = new DataTable("Staff");
            t1.Columns.Add("id");
            t1.Columns.Add("Name");

            for (int i = 0; i < arr.Count; i++)
            {
                t1.Rows.Add(i, arr[i]);
            }

            DataSet set = new DataSet("Staff");
            set.Tables.Add(t1);
            return set;
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
                t1.Rows.Add(jarray[i][0], jarray[i][1], jarray[i][2], jarray[i][3], jarray[i][4], jarray[i][6] , jarray[i][7]);
            }

            DataSet d1 = new DataSet("products");
            d1.Tables.Add(t1);
            return d1;
        }

        public string CloseStore(string storeName, string ownerName)
        {
            string param = string.Format("storeName={0}&ownerName={1}", storeName, ownerName);
            return (System.SendApi("CloseStore", param));
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

        public string AddItemToStore(string ownername, string itemBarCode, string item_name, int amount, int price, string shopName, string descreption, string catagorie)
        {
            string param = string.Format("ownername={0}&itemBarCode={1}&item_name={2}&amount={3}&price={4}&shopName={5}&descreption={6}&catagorie={7}", ownername, itemBarCode, item_name, amount, price, shopName, descreption, catagorie);
            return (System.SendApi("AddItemToStore", param));
        }

        public string UpdateProductAmountInStore(string userName, string storeName, string productBarcode, int amount)
        {
            string param = string.Format("userName={0}&storeName={1}&productBarcode={2}&amount={3}", userName, storeName, productBarcode, amount);
            return (System.SendApi("UpdateProductAmountInStore", param));
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
            string param = string.Format("productName={0}", keyword);
            JArray jarray = (JArray)JsonConvert.DeserializeObject(System.SendApi("search", param).ToString());
            DataTable t1 = new DataTable("products");
            t1.Columns.Add("productName");
            t1.Columns.Add("descerption");
            t1.Columns.Add("barcode");
            t1.Columns.Add("price");
            t1.Columns.Add("discount");
            t1.Columns.Add("catagory");
            t1.Columns.Add("nameShop");

            for (int i = 0; i < jarray.Count; i++)
            {
                t1.Rows.Add(jarray[i][0], jarray[i][1], jarray[i][2], jarray[i][3], jarray[i][4], jarray[i][5], jarray[i][6]);
            }

            DataSet d1 = new DataSet("products");
            d1.Tables.Add(t1);
            return d1;
        }

        public DataSet SearchByProductName(string productName)
        {
            string param = string.Format("productName={0}", productName);
            JArray jarray = (JArray)JsonConvert.DeserializeObject(System.SendApi("SearchByProductName", param).ToString());
            DataTable t1 = new DataTable("products");
            t1.Columns.Add("productName");
            t1.Columns.Add("descerption");
            t1.Columns.Add("barcode");
            t1.Columns.Add("price");
            t1.Columns.Add("discount");
            t1.Columns.Add("catagory");
            t1.Columns.Add("nameShop");

            for (int i = 0; i < jarray.Count; i++)
            {
                t1.Rows.Add(jarray[i][0], jarray[i][1], jarray[i][2], jarray[i][3], jarray[i][4], jarray[i][5], jarray[i][6]);
            }

            DataSet d1 = new DataSet("products");
            d1.Tables.Add(t1);
            return d1;

        }

        public DataSet SearchByKeyword(string keyword)
        {
            string param = string.Format("keyword={0}", keyword);
            JArray jarray = (JArray)JsonConvert.DeserializeObject(System.SendApi("SearchByKeyword", param).ToString());
            DataTable t1 = new DataTable("products");
            t1.Columns.Add("productName");
            t1.Columns.Add("descerption");
            t1.Columns.Add("barcode");
            t1.Columns.Add("price");
            t1.Columns.Add("discount");
            t1.Columns.Add("catagory");
            t1.Columns.Add("nameShop");

            for (int i = 0; i < jarray.Count; i++)
            {
                t1.Rows.Add(jarray[i][0], jarray[i][1], jarray[i][2], jarray[i][3], jarray[i][4], jarray[i][5], jarray[i][6]);
            }

            DataSet d1 = new DataSet("products");
            d1.Tables.Add(t1);
            return d1;

        }

        public DataSet SearchByCategory(string category)
        {
            string param = string.Format("category={0}", category);
            JArray jarray = (JArray)JsonConvert.DeserializeObject(System.SendApi("SearchByCategory", param).ToString());
            DataTable t1 = new DataTable("products");
            t1.Columns.Add("productName");
            t1.Columns.Add("descerption");
            t1.Columns.Add("barcode");
            t1.Columns.Add("price");
            t1.Columns.Add("discount");
            t1.Columns.Add("catagory");
            t1.Columns.Add("nameShop");

            for (int i = 0; i < jarray.Count; i++)
            {
                t1.Rows.Add(jarray[i][0], jarray[i][1], jarray[i][2], jarray[i][3], jarray[i][4], jarray[i][5], jarray[i][6]);
            }

            DataSet d1 = new DataSet("products");
            d1.Tables.Add(t1);
            return d1;
        }


        public string remove_item_from_cart(string userName, string storeName, string productBarcode, int amount)
        {
            string param = string.Format("userName={0}&storeName={1}&productBarcode={2}&amount={3}", userName, storeName, productBarcode , amount);
            return (System.SendApi("remove_item_from_cart", param));
        }

        public string UpdateCart(string userName, string storeName, string productBarcode, int newAmount)
        {
            string param = string.Format("userName={0}&storeName={1}&productBarcode={2}&newAmount={3}", userName, storeName, productBarcode, newAmount);
            return (System.SendApi("UpdateCart", param));
        }


     /*   public bool Purchase(string userName, string creditCard)
        {
            string param = string.Format("userName={0}&creditCard={1}", userName,creditCard);
            return bool.Parse(System.SendApi("Purchase", param));

        }*/

        public bool InitSystem()
        {
            string param = "";
            return bool.Parse(System.SendApi("InitSystem", param));
        }


        public bool AddProductPolicies(string storeName, string productBarCode, int amount)
        {
            string param = string.Format("storeName={0}&productBarCode={1}&amount={2}", storeName, productBarCode, amount);
            return bool.Parse(System.SendApi("AddProductPolicies", param));
        }
        public bool AddCategortPolicies(string storeName, string Category, int hour, int minute)
        {
            string param = string.Format("storeName={0}&Category={1}&hour={2}&minute={3}", storeName, Category, hour , minute);
            return bool.Parse(System.SendApi("AddCategortPolicies", param));
        }
        public bool AddUserPolicies(string storeName, string productBarCode)
        {
            string param = string.Format("storeName={0}&productBarCode={1}", storeName, productBarCode);
            return bool.Parse(System.SendApi("AddUserPolicies", param));
        }
        public bool AddCartrPolicies(string storeName, int amount)
        {
            string param = string.Format("storeName={0}&amount={1}", storeName, amount);
            return bool.Parse(System.SendApi("AddCartrPolicies", param));
        }

        public int addConditionalDiscount(string shopName, int percentage, string condition)
        {
            string param = string.Format("shopName={0}&percentage={1}&condition={2}", shopName, percentage, condition);
            return int.Parse(System.SendApi("addConditionalDiscount", param));
        }

        public bool CompositePolicy(string shopName, string innerText)
        {
            string param = string.Format("shopName={0}&innerText={1}", shopName, innerText);
            return bool.Parse(System.SendApi("CompositePolicy", param));
        }
    }
}
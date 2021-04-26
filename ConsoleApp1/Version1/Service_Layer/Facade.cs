using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Version1.DataAccessLayer;
using Version1.domainLayer;
using Version1.domainLayer.UserRoles;
using Version1.LogicLayer;

namespace Version1.Service_Layer
{
    public class Facade
    {
        private Logic logicInstance = new Logic();
        private SystemAdmin admin;
        private ShoppingHandler shoppingHandler = new ShoppingHandler();
        private StoreAdministration storeAdministration = new StoreAdministration();


        //high priority
        public bool Login(string username, string password)
        {
            return logicInstance.UserLogin(username, password);
        }

        //high priority
        public bool Register(string username, string password)
        {
            return logicInstance.Register(username, password);
        }

        //high priority
        public bool Logout(string userid)
        {
            return logicInstance.UserLogout(userid);
        }

        //high priority
        public string[][] GetStoresProducts()
        {
            var finalList = new List<List<string>>();
            var storeNames = logicInstance.GetStoresNames();
            foreach (var storeName in storeNames)
            {
                var storeInventory = get_items_in_shop(storeName);
                var lists = storeInventory.Select(a => a.ToList()).ToList();
                foreach (var productData in lists)
                    productData.Add(storeName);

                finalList.AddRange(lists);
            }

            return finalList.Select(a => a.ToArray()).ToArray();
        }

        //high priority
        public string[][] GetAllStores()
        {
            var result = StoresTo2DStringArray(logicInstance.GetAllStores());
            return result;
        }

        //high priority
        public bool AddItemToStore(string shopName, string itemBarCode, int amount)
        {
            return logicInstance.AddProductToStore(shopName, itemBarCode, amount);
        }

        //high priority
        public bool AddNewProductToSystem(string barcode, string productName, string description, double price,
            string[] categories)
        {
            if (categories == null || categories.Length == 0)
                return false;
            return logicInstance.AddNewProduct(barcode, productName, description, price, categories.ToList());
        }

        //high priority
        public string[][] get_items_in_shop(string shopName)
        {
            var products = logicInstance.GetProductsFromShop(shopName);
            if (products == null)
                return null;
            var result = ProductsTo2DStringArray(products.Keys.ToList());
            return result;
        }

        //high priority
        public string[][] SearchByKeyword(string keyword)
        {
            var productList = logicInstance.SearchByKeyWord(keyword);
            var result = ProductsTo2DStringArray(productList);

            return result;
        }

        //high priority
        public bool MakeNewOwner(string apointerid, string storeName, string apointeeid)
        {
            return logicInstance.AddOwner(apointerid, storeName, apointeeid);
        }

        //todo make sure that the each number of the permissions
        // appoint to different permission from a *table* of permissions.
        public bool MakeNewManger(string apointerid, string storeName, string apointeeid, List<int> permissions)
        {
            return logicInstance.AddManager(apointerid, storeName, apointeeid, permissions);
        }

        public bool RemoveOwner(string apointerid, string storeName, string apointeeid)
        {
            return logicInstance.RemoveOwner(apointerid, storeName, apointeeid);
        }

        public bool RemoveManager(string apointerid, string storeName, string apointeeid)
        {
            return logicInstance.RemoveManager(apointerid, storeName, apointeeid);
        }


        public bool AddProductToBasket(string userName, string storeName, string productBarCode,int amount)
        {
            return logicInstance.AddProductToBasket(userName, storeName, productBarCode,amount);
        }


        public bool UpdateProduct(string name, string desc, string barcode, List<string> categories)
        {
            throw new NotImplementedException();
        }

        // low
        public bool DeleteProduct(string shopName, string userName, string productBarCode)
        {
            throw new NotImplementedException();
        }

        public bool OpenShop(string userName, string shopName, string policy)
        {
            return logicInstance.OpenStore(userName, shopName, policy);
        }

        // low
        public bool CloseShop(string shopName, string ownerName)
        {
            throw new NotImplementedException();
        }

        public bool HasPermission(string shopName, string userName, int permission)
        {
            throw new NotImplementedException();
        }


        public bool IsLoggedIn(string userName)
        {
            return logicInstance.IsLoggedIn(userName);
        }


        public string[] GetAllLogInUsersInSystem()
        {
            return logicInstance.GetAllLoggedInUsers().ToArray();
        }

        public string[][] GetUserBaskets(string userName)
        {
            var finalList = new List<List<string>>();
            var storeNames = logicInstance.GetStoresNames();
            foreach (var storeName in storeNames)
            {
                var userBasket = GetBasketProducts(userName, storeName);
                if (userBasket == null) continue;
                var lists = userBasket.Select(a => a.ToList()).ToList();
                foreach (var productData in lists)
                {
                    productData.Add(storeName);
                    productData.Add(DataHandler.Instance.GetUser(userName).GetShoppingCart().GetBasket(storeName).Products[DataHandler.Instance.GetProduct(productData[2])].ToString());

                }

                finalList.AddRange(lists);
            }

            return finalList.Select(a => a.ToArray()).ToArray();
            /* var basketsProducts = logicInstance.GetUserBaskets(userName);
             if (basketsProducts == null)
                 return null;
             return ProductsTo2DStringArray(basketsProducts);*/
        }

        public bool remove_item_from_cart(string userName, string storeName, string productBarcode, int amount)
        {
            return logicInstance.RemoveProductFromCart(userName, storeName, productBarcode, amount);
        }

        public bool IsAdmin(string userName)
        {
            throw new NotImplementedException();
        }

        // low
        public int[] GetAppointmentPermissions(int shopid, int apointeeid)
        {
            throw new NotImplementedException();
        }

        // high
        public string[][] GetBasketProducts(string userName, string storeName)
        {
            var products = logicInstance.GetBasketProducts(userName, storeName);
            if (products == null)
                return null;
            return ProductsTo2DStringArray(products);
        }

        public bool SendNotifications(string userName, string msg)
        {
            return logicInstance.AddUserNotification(userName, msg);
        }

        public string[] GetAllUserNotifications(string userid)
        {
            var notifications = logicInstance.GetUserNotifications(userid);
            return notifications?.ToArray();
        }

        public bool UpdatePurchasePolicy(string shopName, string policy)
        {
            return logicInstance.UpdateStorePolicy(shopName, policy);
        }

        public string[][] GetUserStores(string userName)
        {
            var stores = logicInstance.GetUserStores(userName);
            if (stores == null)
                return null;
            return StoresTo2DStringArray(stores);
        }


        public string GetPurchasePolicy(string shopName)
        {
            return logicInstance.GetStorePolicy(shopName);
        }

        private string[][] ProductsTo2DStringArray(List<Product> products)
        {
            string[][] result = new string[products.Count][];
            int index = 0;
            foreach (var product in products)
            {
                string[] productData = new string[5];

                productData[0] = product.Name;
                productData[1] = product.Description;
                productData[2] = product.Barcode;
                productData[3] = product.Price.ToString(CultureInfo.CurrentCulture);

                var categories = "";
                foreach (var category in product.Categories)
                {
                    categories = categories + category + "#";
                }

                productData[4] = categories;


                result[index] = productData;
                index += 1;
            }

            return result;
        }

        private string[][] StoresTo2DStringArray(List<Store> stores)
        {
            string[][] result = new string[stores.Count][];
            int index = 0;
            foreach (var store in stores)
            {
                string[] storeData = new string[4];
                storeData[0] = store.GetName();
                storeData[1] = store.GetOwner();
                storeData[2] = store.GetSellingPolicy();

                var messages = "";
                foreach (var message in store.GetNotifications())
                {
                    messages = messages + message + "#";
                }

                storeData[3] = messages;
                /*      
                      var paymenstInfo = "";
                      foreach (var payment in store.GetPaymentsInfo())
                      {
                          paymenstInfo = paymenstInfo + payment + "#";
                      }
                      storeData[4] = paymenstInfo;
                      
                      var managers = "";
                      foreach (var manager in store.GetManagers())
                      {
                          managers = managers + manager + "#";
                      }
                      storeData[5] = managers;
                      
                      var owners = "";
                      foreach (var owner in store.GetOwners())
                      {
                          owners = owners + owner + "#";
                      }
                      storeData[6] = owners;
                      
                      var discounts = "";
                      foreach (var discount in store.GetDiscounts())
                      {
                          discounts = discounts + discount + "#";
                      }
                      storeData[7] = discounts;
                      
                      var history = "";
                      foreach (var purchase in store.GetHistory())
                      {
                          history = history + purchase.date.ToString(CultureInfo.InvariantCulture) + "#";
                      }
                      storeData[8] = history;
                      
                      var products = "";
                      foreach (var product in store.GetInventory().Keys)
                      {
                          products = products + product + "#";
                      }
                      storeData[9] = products;
                      */
                result[index] = storeData;
                index += 1;
            }

            return result;
        }
    }
}
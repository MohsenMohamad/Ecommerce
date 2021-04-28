using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Version1.DataAccessLayer;
using Version1.domainLayer;
using Version1.domainLayer.DataStructures;
using Version1.domainLayer.UserRoles;
using Version1.LogicLayer;

namespace Version1.Service_Layer
{
    public class Facade
    {
        private readonly Logic logicInstance = new Logic();
        private SystemAdmin admin;


        //high priority
        public bool Login(string username, string password)
        {
            return logicInstance.UserLogin(username, password);
        }

        public long GuestLogin()
        {
            return logicInstance.GuestLogin();
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

        public bool AddNewProductToSystem1(string barcode, string productName, string description, double price,
           string categories1)
        {
            string[] categories = categories1.Split(',');
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

        public bool Purchase(string userName)
        {
            return true;
        }

        //high priority
        public string[][] SearchByKeyword(string keyword)
        {
            var productList = logicInstance.SearchByKeyWord(keyword);
            var result = ProductsTo2DStringArray(productList);

            return result;
        }


        public string[] GetStoreOwners(string storeName)
        {
            return logicInstance.GetStoreOwners(storeName)?.ToArray();
        }
        
        public string[] GetStoreManagers(string storeName)
        {
            return logicInstance.GetStoreManagers(storeName)?.ToArray();
        }
        
        //high priority
        public bool MakeNewOwner(string storeName, string apointerid, string apointeeid)
        {
            return logicInstance.AddOwner(storeName, apointerid, apointeeid);
        }

        //todo make sure that the each number of the permissions
        // appoint to different permission from a *table* of permissions.
        public bool MakeNewManger(string storeName,string apointerid, string apointeeid, int permissions)
        {
            Console.WriteLine(storeName+" "+ apointerid + " " + apointeeid + " " + permissions + " ");
            return logicInstance.AddManager(storeName, apointerid, apointeeid, permissions);
        }

        public bool RemoveOwner(string apointerid, string storeName, string apointeeid)
        {
            return logicInstance.RemoveOwner(apointerid, storeName, apointeeid);
        }

        public bool RemoveManager(string apointerid, string storeName, string apointeeid)
        {
            return logicInstance.RemoveManager(apointerid, storeName, apointeeid);
        }


        public bool AddProductToBasket(string userName, string storeName, string productBarCode, int amount)
        {
            return logicInstance.AddProductToBasket(userName, storeName, productBarCode, amount);
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


        public string[] GetAllLoggedInUsers()
        {
            return logicInstance.GetAllLoggedInUsers().ToArray();
        }
        
        public string[] GetAllUserNamesInSystem()
        {
            return logicInstance.GetAllUserNamesInSystem().ToArray();
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
                    productData.Add(DataHandler.Instance.GetUser(userName).GetShoppingCart().GetBasket(storeName)
                        .Products[DataHandler.Instance.GetProduct(productData[2])].ToString());
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

        public string[] GetAllUserNotifications(string userName)
        {
            var notifications = logicInstance.GetUserNotifications(userName);
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
                storeData[2] = store.GetPurchasePolicies().ToString();

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

        public void InitSystem()


        {
            var facade = new Facade();
            /* ----------------------------  users -------------------------------*/

            Register("mohamedm", "1111");
            Register("adnan", "2222");
            Register("mohameda", "3333");
            Register("yara", "4444");
            Register("shadi", "5555");
            Register("asd", "123");

            /* ----------------------------  categories -------------------------------*/

            Category Electronics = new Category("Electronics");
            Category Fashion = new Category("Fashion");
            Category Health = new Category("Health");
            Category Beauty = new Category("Beauty");
            Category Sports = new Category("Sports");
            Category Arts = new Category("Arts");
            Category Industrial_Equipment = new Category("Industrial_Equipment");

            List<Category> categories = new List<Category>();

            categories.Add(Electronics);
            categories.Add(Fashion);
            categories.Add(Health);
            categories.Add(Beauty);
            categories.Add(Sports);
            categories.Add(Arts);
            categories.Add(Industrial_Equipment);


            /* ----------------------------  products -------------------------------*/

            AddNewProductToSystem("1", "camera", "Sony Alpha a7 III Mirrorless Digital Camera Body - ILCE7M3/B",
                800,
                new[] {Electronics.Name});
            AddNewProductToSystem("2", "women shoes",
                "Nike React Element 55 Women’s Running Shoes Grey Purple Blue Size 11 BQ2728-008.", 450,
                new[] {Fashion.Name, Sports.Name});
            AddNewProductToSystem("3", "shampo keef", "shampo", 25, new[] {Beauty.Name});
            AddNewProductToSystem("4", "hand cream", "hand cream with good smell", 50,
                new[] {Health.Name, Beauty.Name});
            AddNewProductToSystem("5", "sandals", "comfortable sandals", 349.99,
                new[] {Fashion.Name, Health.Name, Sports.Name});
            AddNewProductToSystem("6", "brush", "just a normal brush , what did you expect ...", 33,
                new[] {Arts.Name});

            /* ----------------------------  discounts -------------------------------*/

            //    Discount dis1 = new Discount();
            //    dis1.ModifyItem(camera, 1499.99);
            //    dis1.ModifyItem(shoes, 49.90);

            //    Discount dis2 = new Discount();
            //    dis2.ModifyItem(shampo, 9.99);


            /* ----------------------------  purchase -------------------------------*/


            //    Purchase pr1 = new Purchase();
            //    Purchase pr2 = new Purchase();
            //    pr1.addProduct(camera, 1);
            //    pr1.addProduct(shoes, 2);
            //    pr2.addProduct(shampo, 1);
            //    pr2.addProduct(camera, 1);
            //    pr2.addProduct(flats, 1);
            //    pr2.addProduct(cream, 5);


            /* ----------------------------- Stores ---------------------------------*/

            OpenShop("MohamedStore", "mohamedm", "MohamedPolicy");
            MakeNewManger("mohamedm", "MohamedStore", "yara", 4);
            //         MohamedStore.AddDiscount(dis1);
            AddItemToStore("MohamedStore", "3", 8);
            AddItemToStore("MohamedStore", "1", 11);


            OpenShop("adnan", "AdnanStore", "AdnanPolicy");
            MakeNewManger("AdnanStore", "adnan", "shadi", 1);
            MakeNewOwner("AdnanStore", "adnan", "yara");
            //     AdnanStore.AddDiscount(dis2);
            AddItemToStore("AdnanStore", "2", 12);
            AddItemToStore("AdnanStore", "4", 20);
            AddItemToStore("AdnanStore", "5", 7);


            /*--------------------------------------------------------------------------*/

            AddProductToBasket("mohameda", "AdnanStore", "5", 3);
            AddProductToBasket("mohameda", "AdnanStore", "2", 4);
            AddProductToBasket("adnan", "MohamedStore", "1", 2);
            AddProductToBasket("yara", "MohamedStore", "5", 1);
            AddProductToBasket("shadi", "AdnanStore", "4", 10);


            /*--------------------------------------------------------------------------*/
        }
    }
}
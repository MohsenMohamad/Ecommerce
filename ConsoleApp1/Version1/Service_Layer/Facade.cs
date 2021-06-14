using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Version1.DataAccessLayer;
using Version1.domainLayer;
using Version1.domainLayer.CompositeDP;
using Version1.domainLayer.DataStructures;
using Version1.domainLayer.StorePolicies;
using Version1.LogicLayer;

namespace Version1.Service_Layer
{
    public class Facade : GenInterface
    {
        private readonly Logic logicInstance = new Logic();


        public bool Login(string username, string password)
        {
            var hashPassword = GetHashString(password + "s1a3dAn3a"); // hash with salting
            return hashPassword != null && logicInstance.UserLogin(username, hashPassword);
        }

        public void Recieve_purchase_offer(string username,string storename,string price,string barcode,int amount)
        {
            var product = DataHandler.Instance.GetProduct(barcode, storename);
            var user = DataHandler.Instance.GetUser(username);
            var store = DataHandler.Instance.GetStore(storename);
            var offer = new PurchaseOffer(product, (User)user, store,double.Parse( price),amount);
            DataHandler.Instance.Offers.Add(offer);
            offer.makeOffer();

        }


        public void acceptoffer(string barcode, string price, string username, string storename, int amount,string by_username)
        {
           if(!IsOwner(storename, by_username)){
                var product = DataHandler.Instance.GetProduct(barcode, storename);
                var user = DataHandler.Instance.GetUser(by_username);
                var store = DataHandler.Instance.GetStore(storename);
                var offer = DataHandler.Instance.GetPurchaseOffer(product, (User)user, store, double.Parse(price), amount);
                if (offer == null)
                {
                    offer = new PurchaseOffer(product, (User)user, store, double.Parse(price), amount);
                    DataHandler.Instance.Offers.Add(offer);
                }
                if(offer.acceptOffer())
                AddProductToBasket(by_username, storename, barcode, amount,double.Parse(price));
            }
            else
            {
                var product = DataHandler.Instance.GetProduct(barcode, storename);
                var user = DataHandler.Instance.GetUser(username);
                var store = DataHandler.Instance.GetStore(storename);
                var offer = DataHandler.Instance.GetPurchaseOffer(product, (User)user, store, double.Parse(price), amount);
                if (offer == null)
                {
                    offer = new PurchaseOffer(product, (User)user, store, double.Parse(price), amount);
                    DataHandler.Instance.Offers.Add(offer);
                }
                if(offer.acceptOffernotfinal(by_username))
                    AddProductToBasket(username, storename, barcode, amount, double.Parse(price));

            }
        }

        public void rejectoffer(string barcode, string price, string username, string storename, int amount,string by_username)
        {
            if (!IsOwner(storename, by_username))
            {
                var product = DataHandler.Instance.GetProduct(barcode, storename);
                var user = DataHandler.Instance.GetUser(by_username);
                var store = DataHandler.Instance.GetStore(storename);
                var offer = DataHandler.Instance.GetPurchaseOffer(product, (User)user, store, double.Parse(price), amount);
                offer.rejectOffer();
            }
            else {
                var product = DataHandler.Instance.GetProduct(barcode, storename);
                var user = DataHandler.Instance.GetUser(username);
                var store = DataHandler.Instance.GetStore(storename);
                var offer = DataHandler.Instance.GetPurchaseOffer(product, (User)user, store, double.Parse(price), amount);
                offer.rejectOffer();
            }
        }

        public void CounterOffer(string barcode, string price, string username, string storename, int amount, string owner, string oldprice)
        {
            var product = DataHandler.Instance.GetProduct(barcode, storename);
            var user = DataHandler.Instance.GetUser(username);
            var store = DataHandler.Instance.GetStore(storename);



            if (IsOwner(storename, owner))
            {
                var offer = new PurchaseOffer(product, (User)user, store, double.Parse(price), amount);
                DataHandler.Instance.Offers.Add(offer);
                offer.counteroffer(owner, oldprice);
            }

            else
            {
                string tmp = username;
                username = owner;
                owner = tmp;
                user = DataHandler.Instance.GetUser(username);
                var offer = new PurchaseOffer(product, (User)user, store, double.Parse(price), amount);
                DataHandler.Instance.Offers.Add(offer);
                offer.counterofferifnotowner(owner, oldprice);
            }
        }

        public long GuestLogin()
        {
            return logicInstance.GuestLogin();
        }

        public bool GuestLogout(long id)
        {
            return logicInstance.GuestLogout(id);
        }

        public bool Register(string username, string password)
        {
            var hashPassword = GetHashString(password + "s1a3dAn3a"); // hash with salting
            return hashPassword != null && logicInstance.Register(username, hashPassword);

        }


        public bool Logout(string userid)
        {
            return logicInstance.UserLogout(userid);
        }


        public string[][] GetStoresProducts()
        {
            var finalList = new List<List<string>>();
            var storeNames = logicInstance.GetStoresNames();
            foreach (var storeName in storeNames)
            {
                var storeInventory = GetStoreProducts(storeName);
                var lists = storeInventory.Select(a => a.ToList()).ToList();
                foreach (var productData in lists)
                    productData.Add(storeName);

                finalList.AddRange(lists);
            }

            return finalList.Select(a => a.ToArray()).ToArray();
        }


        public string[][] GetAllStores()
        {
            var result = StoresTo2DStringArray(logicInstance.GetAllStores());
            return result;
        }


        public bool ValidateBasketPolicies(string userName, string storeName)
        {
            var user = DataHandler.Instance.GetUser(userName);
            var store = DataHandler.Instance.GetStore(storeName);

            var basket = user.GetShoppingCart().GetBasket(storeName);

            foreach (var policy in store.GetPurchasePolicies())
            {
                if (!policy.Validate(basket))
                    return false;
            }

            return true;
        }

        public bool AddProductToStore(string ownerName, string storeName, string barcode, string productName,
            string description, double price,
            string categories1, int amount)
        {
            if (string.IsNullOrEmpty(categories1)) return false;
            var categories = categories1.Split(',').ToList();
            return logicInstance.AddProductToStore(storeName, barcode, productName, description, price, categories,
                amount);
        }

        public string[][] GetStoreProducts(string storeName)
        {
            var storeProducts = logicInstance.GetStoreProducts(storeName);
            if (storeProducts == null)
                return null;
            var products = new Dictionary<string, List<string>> {{storeName, storeProducts}};

            return ProductsTo2DStringArray(products);
        }

        public bool Purchase(string userName, string creditCard)
        {
            return logicInstance.Purchase(userName, creditCard);
        }

        public bool UpdateCart(string userName, string storeName, string productBarcode, int newAmount)
        {
            return logicInstance.UpdateCart(userName, storeName, productBarcode, newAmount);
        }

        public string GetHash(string inputString)
        {
            return logicInstance.GetHash(inputString);
        }

        public string GetHashString(string inputString)
        {
            return logicInstance.GetHashString(inputString);
        }
        


        public string[][] SearchByKeyword(string keyword)
        {
            var searchResult = logicInstance.SearchByKeyWord(keyword);
            var result = ProductsTo2DStringArray(searchResult);
            var lists1 = result.Select(a => a.ToList()).ToList();

            var finalList = new List<List<string>>();
            var storeNames = logicInstance.GetStoresNames();
            foreach (var storeName in storeNames)
            {
                var storeInventory = GetStoreProducts(storeName);
                var lists = storeInventory.Select(a => a.ToList()).ToList();
                foreach (var product in lists1)
                {
                    foreach (var productData in lists)
                    {
                        if (productData[2].Equals(product[2]))
                        {
                            product.Add(storeName);
                        }
                    }
                }

                finalList.AddRange(lists1);
            }

            return finalList.Select(a => a.ToArray()).ToArray();
        }


        public string[] GetStoreOwners(string storeName)
        {
            return logicInstance.GetStoreOwners(storeName)?.ToArray();
        }

        public bool IsOwner(string storeName, string ownerName)
        {
            return GetStoreOwners(storeName).Contains(ownerName);
        }

        //do not use
        public bool AddNewManger(string user, string store, string newMangerName)
        {
            //todo add permissions parameter
            return MakeNewManger(store, user, newMangerName, 0);
        }

        public bool IsManger(string storeName, string mangerName)
        {
            return GetStoreManagers(storeName).Contains(mangerName);
        }


        public bool deleteManger(string ownerUser, string storeName, string oldMangerName)
        {
            return RemoveManager(ownerUser, storeName, oldMangerName);
        }

        public bool buyProduct(string buyer, string store, string product, int amount)
        {
            return Purchase(buyer, "111");
        }
        
        
        // change this so it calls addProductToStore
        public bool uc_4_1_addEditRemovePruduct(string storeOwnerName, string storeName, string productName,
            string desc, int amount,
            List<string> categories)
        {
            return UpdateProductAmountInStore(storeOwnerName, storeName, productName, amount);
        }


        public string[] GetStoreManagers(string storeName)
        {
            return logicInstance.GetStoreManagers(storeName)?.ToArray();
        }


        public bool MakeNewOwner(string storeName, string apointerid, string apointeeid)
        {
            return logicInstance.AddOwner(storeName, apointerid, apointeeid);
        }

        // appoint to different permission from a *table* of permissions.
        public bool MakeNewManger(string storeName, string apointerid, string apointeeid, int permissions)
        {
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


        public bool AddProductToBasket(string userName, string storeName, string productBarCode, int amount,double priceofone)
        {
            return logicInstance.AddProductToBasket(userName, storeName, productBarCode, amount,priceofone);
        }
        
        public bool OpenStore(string userName, string shopName, string policy)
        {
            return logicInstance.OpenStore(userName, shopName, policy);
        }


        public bool AddMaxProductPolicy(string storeName, string productBarCode, int amount)
        {
            return logicInstance.AddMaxProductPolicy(storeName, productBarCode, amount);
        }
        public bool AddCategoryPolicy(string storeName, string productCategory, int hour, int minute)
        {
            return logicInstance.AddCategoryPolicy(storeName, productCategory, hour, minute);
        }
        public bool AddUserPolicy(string storeName, string productBarCode)
        {
            return logicInstance.AddUserPolicy(storeName, productBarCode);
        }
        
        public bool AddCartPolicy(string storeName, int amount)
        {
            return logicInstance.AddCartPolicy(storeName, amount);
        }

        public string[][] GetAllWorkersInStore(string storeName)
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
                        .Products[productData[2]].ToString());
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



        // low
        public int[] GetAppointmentPermissions(int shopid, int apointeeid)
        {
            throw new NotImplementedException();
        }


        public string[][] GetBasketProducts(string userName, string storeName)
        {
            var basketProducts = logicInstance.GetBasketProducts(userName, storeName);
            if (basketProducts == null)
                return null;
            var products = new Dictionary<string, List<string>> {{storeName, basketProducts}};

            return ProductsTo2DStringArray2(products,userName);
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

        public string[] GetAllUserNotificationsoffer(string userName)
        {
            var notifications = logicInstance.GetUserNotificationsoffer(userName);
            return notifications?.ToArray();
        }

        public bool UpdatePurchasePolicy(string shopName, Component policy)
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


        // products : <string,List<string>> = <storeName,List<barcode>>
        private string[][] ProductsTo2DStringArray(Dictionary<string, List<string>> products)
        {
            string[][] result = new string[products.Values.SelectMany(p => p).Count()][];
            int index = 0;

            foreach (var storeProducts in products)
            {
                var storeName = storeProducts.Key;
                foreach (var productBarcode in storeProducts.Value)
                {
                    var product = DataHandler.Instance.GetProduct(productBarcode, storeName);
                    string[] productData = new string[6];

                    productData[0] = product.Name;
                    productData[1] = product.Description;
                    productData[2] = product.Barcode;
                    productData[3] = product.Price.ToString(CultureInfo.CurrentCulture);
                    productData[4] = product.discountPolicy.discount_description;

                    var categories = "";
                    foreach (var category in product.Categories)
                    {
                        categories = categories + category + "#";
                    }

                    categories =  categories.Substring(0, categories.Length - 1);

                    productData[5] = categories;


                    result[index] = productData;
                    index += 1;
                }
            }

            return result;
        }

        private string[][] ProductsTo2DStringArray2(Dictionary<string, List<string>> products, string userName)
        {
            string[][] result = new string[products.Values.SelectMany(p => p).Count()][];
            int index = 0;
            var user = DataHandler.Instance.GetUser(userName);
            foreach (var storeProducts in products)
            {
                var storeName = storeProducts.Key;
                foreach (var productBarcode in storeProducts.Value)
                {
                    var product = DataHandler.Instance.GetProduct(productBarcode, storeName);
                    string[] productData = new string[6];
                    var shopbasket = user.GetShoppingCart().shoppingBaskets[storeName].priceperproduct;
                    productData[0] = product.Name;
                    productData[1] = product.Description;
                    productData[2] = product.Barcode;
                    productData[3] = shopbasket[product.Barcode].ToString();
                    productData[4] = product.discountPolicy.discount_description;

                    var categories = "";
                    foreach (var category in product.Categories)
                    {
                        categories = categories + category + "#";
                    }

                    categories = categories.Substring(0, categories.Length - 1);

                    productData[5] = categories;


                    result[index] = productData;
                    index += 1;
                }
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





        public bool AdminInitSystem()
        {
            /* ----------------------------  users -------------------------------*/

/*            ExternalServices.ExternalFinanceService.CreateConnection();
            ExternalServices.ExternalSupplyService.CreateConnection();*/

            Register("mohamedm", "1111");
            Register("adnan", "2222");
            Register("mohameda", "3333");
            Register("yara", "4444");
            Register("shadi", "5555");
            Register("asd", "123");

            /* ----------------------------  categories -------------------------------*/

            var electronics = new Category("Electronics");
            var fashion = new Category("Fashion");
            var health = new Category("Health");
            var beauty = new Category("Beauty");
            var sports = new Category("Sports");
            var arts = new Category("Arts");

            /* ----------------------------  products -------------------------------*/

            var product1 = new Product("1", "camera", "Sony Alpha a7 III Mirrorless Digital Camera Body - ILCE7M3/B",
                800,
                new[] {electronics.Name}.ToList());
            var product2 = new Product("2", "women shoes",
                "Nike React Element 55 Women’s Running Shoes Grey Purple Blue Size 11 BQ2728-008.", 450,
                new[] {fashion.Name, sports.Name}.ToList());
            var product3 = new Product("3", "shampo keef", "shampo", 25, new[] {beauty.Name}.ToList());
            var product4 = new Product("4", "hand cream", "hand cream with good smell", 50,
                new[] {health.Name, beauty.Name}.ToList());
            var product5 = new Product("5", "sandals", "comfortable sandals", 349.99,
                new[] {fashion.Name, health.Name, sports.Name}.ToList());
            var product6 = new Product("6", "brush", "just a normal brush  what did you expect ...", 33,
                new[] {arts.Name}.ToList());

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

            OpenStore("mohamedm", "MohamedStore", "MohamedPolicy");
            MakeNewManger("MohamedStore", "mohamedm", "yara", 4);
            //         MohamedStore.AddDiscount(dis1);
            AddProductToStore("mohamedm", "MohamedStore", product3.Barcode, product3.Name, product3.Description,
                product3.Price, product3.Categories[0].ToString(), 8);
            AddProductToStore("mohamedm", "MohamedStore", product1.Barcode, product1.Name, product1.Description,
                product1.Price, product1.Categories[0].ToString(), 11);
            AddProductToStore("mohamedm", "MohamedStore", product6.Barcode, product6.Name, product6.Description,
                product6.Price, product6.Categories[0].ToString(), 20);


            OpenStore("adnan", "AdnanStore", "AdnanPolicy");
            MakeNewManger("AdnanStore", "adnan", "shadi", 1);
            MakeNewOwner("AdnanStore", "adnan", "yara");
            //     AdnanStore.AddDiscount(dis2);
            AddProductToStore("adnan", "AdnanStore", product2.Barcode, product2.Name, product2.Description,
                product2.Price, product2.Categories[0].ToString()+"#"+ product2.Categories[1].ToString(), 18);
            AddProductToStore("adnan", "AdnanStore", product4.Barcode, product4.Name, product4.Description,
                product4.Price, product4.Categories[0].ToString() + "#" + product4.Categories[1].ToString(), 20);
            AddProductToStore("adnan", "AdnanStore", product5.Barcode, product5.Name, product5.Description,
                product5.Price, product5.Categories[0].ToString() + "#" + product5.Categories[1].ToString() + "#" + product5.Categories[2].ToString(), 7);


            /*--------------------------------------------------------------------------*/

            AddProductToBasket("mohameda", "AdnanStore", "5", 3, 349.99);
            AddProductToBasket("mohameda", "AdnanStore", "2", 4,450);
            AddProductToBasket("adnan", "MohamedStore", "1", 2,800);
            AddProductToBasket("yara", "MohamedStore", "5", 1, 349.99);
            AddProductToBasket("shadi", "AdnanStore", "4", 10,50);


            

            /*--------------------------------------------------------------------------*/
            return true;
        }

        //do not use

        public ConcurrentDictionary<string, int> GetStoreInventory(string ownerName, string storeName)
        {
            return logicInstance.GetStoreInventory(storeName);
        }

        public bool CloseStore(string storeName, string ownerName)
        {
            return logicInstance.CloseStore(storeName, ownerName);
        }

        public bool HasPermission(string shopName, string userName, int permission)
        {
            throw new NotImplementedException();
        }

        public bool CheckStoreInventory(string storeName, Hashtable products)
        {
            throw new NotImplementedException();
        }

        public List<string> SearchFilter(string userName, string sortOption, List<string> filters)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, int> GetCartByStore(string userName, string storeName)
        {
            return logicInstance.GetCartByStore(userName, storeName);
        }

        public string[] getUsersStore(string userName, string storeName)
        {
            throw new NotImplementedException();
        }

        /* ******************* high priority todo all this function for the tests ********************* */
        //1

        public bool UpdateProductAmountInStore(string userName, string storeName, string productBarcode, int amount)
        {
            return logicInstance.UpdateProductAmountInStore(userName, storeName, productBarcode, amount);
        }

        //2
        public bool RemoveProductFromStore(string userName, string storeName, string productBarcode)
        {
            return logicInstance.RemoveProductFromStore(userName, storeName, productBarcode);
        } //3

        public string getInfo(string user, string store)
        {
            throw new NotImplementedException();
        }

        //4
        public bool updateMangerResponsibilities(string user, string storeName, List<string> responsibilities)
        {
            throw new NotImplementedException();
        }

        //5
        public List<string> getMangerResponsibilities(string user, string store, string newMangerName)
        {
            throw new NotImplementedException();
        }

        //6
        public List<string> updatePaymentInfo(string owner, string storeName, List<string> allInfo)
        {
            throw new NotImplementedException();
        }

        //7
        public List<string> getPaymentInfo(string owner, string storeName)
        {
            throw new NotImplementedException();
        }

        //8
        public List<string> addPaymentInfo(string owner, string storeName, string info)
        {
            throw new NotImplementedException();
        } //9

        public List<string> getStorePurchaseHistory(string ownerUser, string storeName)
        {
            return logicInstance.GetStorePurchaseHistory(ownerUser, storeName);
        } //10

        public string GetStoreInfo(string userName, string storeName)
        {
            return logicInstance.GetStorePolicy(storeName);
        }

        // ???? make sure that the one who is init the system is sysAdmin
        public bool initSystem(string admin)
        {
            throw new NotImplementedException();
        }

        public int addPublicStoreDiscount(string storeName, int percentage)
        {
            return logicInstance.addPublicDiscount(storeName, percentage);
        }

        public int addPublicDiscountToItem(string storeName, string barcode, int percentage)
        {
            return logicInstance.addPublicDiscount_toItem(storeName, barcode, percentage);
        }

        public int addConditionalDiscount(string shopName, int percentage, string condition)
        {
            return logicInstance.addConditionalDiscount(shopName, percentage, condition);
        }

        public double GetTotalCart(string userName)
        {
            return logicInstance.GetTotalCart(userName);
        }
    }
}
using System;
using System.Web.Http;
using System.Web.Http.Cors;
using Version1.Service_Layer;
using System.Configuration;
namespace ServerApi
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class facadeController : ApiController
    {
        private Facade facade = new Facade("false");
        public facadeController()
        {
            string sAttr = ConfigurationManager.AppSettings.Get("mock");
            facade = new Facade(sAttr);
        }
        [HttpGet]
        public string[][] GetStoresProducts()
        {
            var a = facade.GetStoresProducts();
            return a;
        }

        [HttpGet]
        public string[][] GetStoreProducts(string storeName)
        {
            return facade.GetStoreProducts(storeName);
        }

        [HttpGet]
        public string[][] getAllStores()
        {
            return facade.GetAllStores();
        }

        [HttpGet]
        public int GetPermissions(string userName, string storeName)
        {
            return facade.GetPermissions(userName, storeName);
        }

        [HttpGet]
        public bool UpdatePermissions(string userName, string storeName, int newPermissions)
        {
            return facade.UpdatePermissions(userName, storeName, newPermissions);
        }

        [HttpGet]
        public string addItemToStore(string ownername, string itemBarCode, string item_name, int amount, int price,
            string shopName, string descreption, string catagorie)
        {
            try
            {
                Logger.GetInstance()
                    .Event("product with barcode " + itemBarCode + " has been added to the shop " + shopName);

                var msg = facade.AddProductToStore(ownername, shopName, itemBarCode, item_name, descreption, price,
                    catagorie, amount);
                return msg.ToString();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        [HttpGet]
        public void Recieve_purchase_offer(string username, string storename, string price, string barcode, int amount)
        {
            facade.Recieve_purchase_offer(username, storename, price, barcode, amount);
        }

        [HttpGet]
        public bool IsOwner(string storeName, string ownerName)
        {
            return facade.IsOwner(storeName, ownerName);
        }

        [HttpGet]
        public bool CloseStore(string storeName, string ownerName)
        {
            var result = facade.CloseStore(storeName, ownerName);
            if (result)
                Logger.GetInstance().Event(storeName + " has been closed by " + ownerName);
            return result;
        }

        [HttpGet]
        public string UpdateProductAmountInStore(string userName, string storeName, string productBarcode, int amount)
        {
            try
            {
                var msg = facade.UpdateProductAmountInStore(userName, storeName, productBarcode, amount);
                return msg.ToString();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        [HttpGet]
        public string[][] GetUserBaskets(string userName)
        {
            return facade.GetUserBaskets(userName);
        }

        [HttpGet]
        public string InitByStateFile(string path)
        {
            try
            {
                var msg = facade.InitByStateFile(path);
                return msg.ToString();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        [HttpGet]
        public string OpenShop(string userName, string shopName, string policy)
        {
            try
            {
                Logger.GetInstance().Event(userName + " has opened shop : " + shopName);
                var msg = facade.OpenStore(userName, shopName, policy);
                return msg.ToString();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        [HttpGet]
        public int addStoreDiscount(string storeName, int percentage)
        {
            return facade.addPublicStoreDiscount(storeName, percentage);
        }

        [HttpGet]
        public int addPublicDiscountToItem(string storeName, string barcode, int percentage)
        {
            return facade.addPublicDiscountToItem(storeName, barcode, percentage);
        }


        [HttpGet]
        public int addConditionalDiscount(string shopName, int percentage, string condition)
        {
            return facade.addConditionalDiscount(shopName, percentage, condition);
        }

        [HttpGet]
        public double GetTotalCart(string userName)
        {
            return facade.GetTotalCart(userName);
        }

        [HttpGet]
        public string[][] search(string keyword)
        {
            return facade.SearchByKeyword(keyword);
        }


        [HttpGet]
        public bool AddProductPolicies(string storeName, string productBarCode, int amount)
        {
            var result = facade.AddMaxProductPolicy(storeName, productBarCode, amount);
            if (result)
                Logger.GetInstance().Event("A new amount ( " + amount + " ) restriction policy has been added for " +
                                           productBarCode + " at " + storeName);
            return result;
        }

        [HttpGet]
        public bool AddCategortPolicies(string storeName, string category, int hour, int minute)
        {
            var result = facade.AddCategoryPolicy(storeName, category, hour, minute);
            if (result)
                Logger.GetInstance().Event("A new DayTime restriction policy has been added for the category " +
                                           category + " at " + storeName);
            return result;
        }

        [HttpGet]
        public bool AddUserPolicies(string storeName, string productBarCode)
        {
            var result = facade.AddUserPolicy(storeName, productBarCode);
            if (result)
                Logger.GetInstance().Event("A new User only product policy for = " + productBarCode +
                                           "has been added to " + storeName);
            return result;
        }

        [HttpGet]
        public bool AddCartrPolicies(string storeName, int amount)
        {
            var result = facade.AddCartPolicy(storeName, amount);
            if (result)
                Logger.GetInstance().Event("A new Max amount policy = " + amount + "has been added to " + storeName);
            return result;
        }


        [HttpGet]
        public string makeNewOwner(string storeName, string apointerid, string apointeeid)
        {
            try
            {
                var output = facade.MakeNewOwner(storeName, apointerid, apointeeid);
                Logger.GetInstance().Event(output
                    ? apointerid + " has make new owner for " + storeName
                    : apointerid + " could not make new owner for " + storeName);
                return output.ToString();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        [HttpGet]
        public string makeNewManger(string storeName, string apointerid, string apointeeid, int permissions)
        {
            //todo split the permissions and make dataStructures that saves the permissions
            try
            {
                var output = facade.MakeNewManger(storeName, apointerid, apointeeid, permissions);
                Logger.GetInstance().Event(output
                    ? apointerid + " has make new manger " + apointeeid + " for " + storeName
                    : apointerid + " could not make new manger for " + storeName);
                return output.ToString();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        [HttpGet]
        public bool CompositePolicy(string shopName, string innerText)
        {
            return facade.CompositePolicy(shopName, innerText);
        }

        [HttpGet]
        public string removeOwner(string apointerid, string storeName, string apointeeid)
        {
            try
            {
                var output = facade.RemoveOwner(apointerid, storeName, apointeeid);
                Logger.GetInstance().Event(output
                    ? apointerid + " has has removed owner" + apointeeid + "form store: " + storeName
                    : apointerid + " could not removed owner for " + storeName);
                return output.ToString();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        [HttpGet]
        public string removeManager(string apointerid, string storeName, string apointeeid)
        {
            try
            {
                var output = facade.RemoveManager(apointerid, storeName, apointeeid);
                Logger.GetInstance().Event(output
                    ? apointerid + " has has removed manger" + apointeeid + "form store: " + storeName
                    : apointerid + " could not removed manger for " + storeName);
                return output.ToString();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        [HttpGet]
        public bool AddProductToBasket(string userName, string storeName, string productBarCode, int amount,
            double priceofone)
        {
            var output = facade.AddProductToBasket(userName, storeName, productBarCode, amount, priceofone);
            Logger.GetInstance().Event(output
                ? userName + " has has added product :" + productBarCode + "form store: " + storeName + " to his Basket"
                : userName + " could not add product :" + productBarCode + "form store: " + storeName +
                  " to his Basket");
            return output;
        }
/*
        [HttpGet]
        public bool AddNewProductToSystem(string barcode, string productName, string description, double price,
           string categories)
        {
            bool output = facade.AddNewProductToSystem1(barcode, productName, description, price, categories);
            Logger.GetInstance().Event(output
                ? productName + "with barcode:" + barcode + " has been added to the system "
                : productName + "with barcode:" + barcode + " has not been added to the system");
            return output;

        }*/

        //  [HttpGet]
        /*public bool AddItemToStore(string shopName, string itemBarCode, int amount)
        {
            bool output = facade.AddItemToStore(shopName, itemBarCode, amount);
            Logger.GetInstance().Event(output
                ? " barcode: " + itemBarCode + " has been added to the shop : " + shopName
                : " barcode: " + itemBarCode + " has not been added to the shop : " + shopName);
            return output;
        }*/
        [HttpGet]
        public bool remove_item_from_cart(string userName, string storeName, string productBarcode, int amount)
        {
            var output = facade.remove_item_from_cart(userName, storeName, productBarcode, amount);
            Logger.GetInstance().Event(output
                ? userName + " has has added product :" + productBarcode + "form store: " + storeName + " to his cart"
                : userName + " could not add product :" + productBarcode + "form store: " + storeName + " to his cart");
            return output;
        }

        [HttpGet]
        public string[] GetStoreOwners(string storeName)
        {
            return facade.GetStoreOwners(storeName);
        }

        [HttpGet]
        public string[][] GetUserStores(string userName)
        {
            return facade.GetUserStores(userName);
        }

        [HttpGet]
        public string[] GetStoreManagers(string storeName)
        {
            return facade.GetStoreManagers(storeName);
        }

        [HttpGet]
        public string[] GetAllUserNamesInSystem()
        {
            return facade.GetAllUserNamesInSystem();
        }

        [HttpGet]
        public bool UpdateCart(string userName, string storeName, string productBarcode, int newAmount)
        {
            var result = facade.UpdateCart(userName, storeName, productBarcode, newAmount);
            /*    if (result)
                    Logger.GetInstance().Event(userName + "has changed the amount of " + productBarcode + " in his " +
                                               storeName + " basket");
                                               */
            return result;
        }

        /*       [HttpGet]
               public bool Purchase(string userName, string creditCard)
               {
                   return facade.Purchase(userName, creditCard);
               }*/

        [HttpGet]
        public bool InitSystem()
        {
            return facade.AdminInitSystem();
        }

        [HttpGet]
        public string Register(string username, string password)
        {
            try
            {
                bool output = facade.Register(username, password);
                if (output)
                {
                    Logger.GetInstance().Event(username + "has Register succesfully ");
                }

                return output.ToString();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        [HttpGet]
        public string Login(string username, string password)
        {
            try
            {
                bool output = facade.Login(username, password);
                if (output)
                {
                    Logger.GetInstance().Event(username + "has LoggedIn ");
                }

                return output.ToString();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        [HttpGet]
        public bool Logout(string username)
        {
            var output = facade.Logout(username);
            if (output)
            {
                Logger.GetInstance().Event(username + "has LoggedOut ");
            }

            return output;
        }

        [HttpGet]
        public string[] GetAllNotifications(string userName)
        {
            return facade.GetAllUserNotifications(userName);
        }

        [HttpGet]
        public string[] GetAllUserNotificationsoffer(string userName)
        {
            return facade.GetAllUserNotificationsoffer(userName);
        }


        [HttpGet]
        public string[] GetStaff(string storeName)
        {
            return facade.GetStaff(storeName);
        }


        [HttpGet]
        public void acceptoffer(string barcode, string price, string username, string storename, int amount,
            string by_username)
        {
            facade.acceptoffer(barcode, price, username, storename, amount, by_username);
            Logger.GetInstance().Event(username + " has accepted " + by_username + " offer worth " + price +
                                       " for product BR " + barcode + " at " + storename);
        }

        [HttpGet]
        public bool Purchase(string userName, string cardNumber, int expMonth, int expYear, string cardHolder,
            int cardCcv, int holderId, string nameF, string address, string city, string country, int zip)
        {
            var result = facade.Purchase(userName, cardNumber, expMonth, expYear, cardHolder, cardCcv, holderId, nameF,
                address, city, country, zip);

            if (result)
                Logger.GetInstance().Event(userName + " has completed a purchase ");

            return result;
        }

        [HttpGet]
        public void rejectoffer(string barcode, string price, string username, string storename, int amount,
            string by_username)
        {
            facade.rejectoffer(barcode, price, username, storename, amount, by_username);
            Logger.GetInstance().Event(username + " has rejected " + by_username + " offer worth " + price +
                                       " for product BR " + barcode + " at " + storename);
        }

        [HttpGet]
        public string[][] SearchByProductName(string productName)
        {
            return facade.SearchByProductName(productName);
        }

        [HttpGet]
        public string[][] SearchByKeyword(string keyword)
        {
            return facade.SearchByKeyword(keyword);
        }

        [HttpGet]
        public string[][] SearchByCategory(string category)
        {
            return facade.SearchByCategory(category);
        }


        [HttpGet]
        public void CounterOffer(string barcode, string price, string username, string storename, int amount,
            string owner, string oldprice)
        {
            facade.CounterOffer(barcode, price, username, storename, amount, owner, oldprice);
            Logger.GetInstance().Event(username + " has made a counter offer worth " + price + " for product BR " +
                                       barcode + " at " + storename);
        }

        [HttpGet]
        public long GuestLogin()
        {
            var output = facade.GuestLogin();
            if (output >= 0)
                Logger.GetInstance().Event("Guest has connected with pid : " + output);
            return output;
        }

        [HttpGet]
        public string[] GetUserPurchaseHistory(string userName)
        {
            return facade.GetUserPurchaseHistory(userName);
        }

        [HttpGet]
        public string[] GetStorePurchaseHistory(string StoreName)
        {
            return facade.GetStorePurchaseHistory(StoreName);
        }

        [HttpGet]
        public string UpdateUserPassword(string userName, string newPassword)
        {
            try
            {
                var output = facade.UpdateUserPassword(userName, newPassword);
                if (output)
                    Logger.GetInstance().Event(userName + " updated his password successfully");
                return output.ToString();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
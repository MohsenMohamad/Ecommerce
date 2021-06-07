using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

using System.Web.Http.Cors;
using Version1.Service_Layer;

namespace ServerApi
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class facadeController : ApiController
    {
        private Facade facade = new Facade();
        [HttpGet]
        public string[][] GetStoresProducts()
        {
            var a = facade.GetStoresProducts();
            return a;
        }
        [HttpGet]
        public string[][] getAllStores()
        {
            return facade.GetAllStores();
        }
        [HttpGet]
        public string addItemToStore(string ownername, string itemBarCode, string item_name, int amount, int price, string shopName, string descreption, string catagorie)
        {
            try
            {
                Logger.GetInstance().Event("product with barcode " + itemBarCode + " has been added to the shop " + shopName);

                bool msg = facade.AddProductToStore(ownername, shopName, itemBarCode, item_name, descreption, price, catagorie, amount);
                return msg.ToString();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        [HttpGet]
        public void Recieve_purchase_offer(string username, string storename, string price, string barcode)
        {
            facade.Recieve_purchase_offer(username, storename, price, barcode);

        }

        [HttpGet]
        public bool IsOwner(string storeName, string ownerName)
        {
            return facade.IsOwner(storeName, ownerName);
        }

        [HttpGet]
        public bool CloseStore(string storeName, string ownerName)
        {
            return facade.CloseStore(storeName, ownerName);
        }

        [HttpGet]
        public string UpdateProductAmountInStore(string userName, string storeName, string productBarcode, int amount)
        {
            try
            {
                bool msg = facade.UpdateProductAmountInStore(userName, storeName, productBarcode, amount);
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
        public string OpenShop(string userName, string shopName, string policy)
        {
            try
            {
                Logger.GetInstance().Event(userName + " has opened shop : " + shopName);
                bool msg=facade.OpenStore(userName, shopName, policy);
                return msg.ToString();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        [HttpGet]
        public string[][] search(string keyword)
        {
            return facade.SearchByKeyword(keyword);
        }


        [HttpGet]
        public bool AddProductPolicies(string storeName, string productBarCode, int amount)
        {
            return facade.AddMaxProductPolicy(storeName, productBarCode, amount);
        }

        [HttpGet]
        public bool AddCategortPolicies(string storeName, string category, int hour, int minute)
        {
            return facade.AddCategoryPolicy(storeName, category, hour, minute);
        }

        [HttpGet]
        public bool AddUserPolicies(string storeName, string productBarCode)
        {
            return facade.AddUserPolicy(storeName, productBarCode);
        }

        [HttpGet]
        public bool AddCartrPolicies(string storeName, int amount)
        {
            return facade.AddCartPolicy( storeName,  amount);
        }


        [HttpGet]
        public string makeNewOwner(string storeName, string apointerid, string apointeeid)
        {
            try {
                bool output = facade.MakeNewOwner(storeName, apointerid, apointeeid);
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
        {   //todo split the permissions and make dataStructures that saves the permissions
            try
            {
                bool output = facade.MakeNewManger(storeName, apointerid, apointeeid, permissions);
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
        public string removeOwner(string apointerid, string storeName, string apointeeid)
        {
            try
            {
                bool output = facade.RemoveOwner(apointerid, storeName, apointeeid);
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
                bool output = facade.RemoveManager(apointerid, storeName, apointeeid);
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
        public bool AddProductToBasket(string userName, string storeName, string productBarCode, int amount)
        {
            bool output = facade.AddProductToBasket(userName, storeName, productBarCode, amount);
            Logger.GetInstance().Event(output
                ? userName + " has has added product :" + productBarCode + "form store: " + storeName + " to his Basket"
                : userName + " could not add product :" + productBarCode + "form store: " + storeName + " to his Basket");
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
            bool output = facade.remove_item_from_cart(userName, storeName, productBarcode, amount);
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
            return facade.UpdateCart(userName, storeName, productBarcode, newAmount);
        }

        [HttpGet]
        public bool Purchase(string userName, string creditCard)
        {
            return facade.Purchase(userName, creditCard);
        }

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
            catch (Exception e) {
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
            catch(Exception e)
            {
                return e.Message;
            }
        }
        [HttpGet]
        public bool Logout(string username)
        {
            bool output = facade.Logout(username);
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
        public void acceptoffer(string barcode, string price, string username, string storename)
        {

           facade.acceptoffer(barcode, price, username, storename);
        
        }

        [HttpGet]
        public long GuestLogin()
        {
            long output = facade.GuestLogin();
            Logger.GetInstance().Event("Guest has connected with pid : " + output);
            return output;
        }
    }
}

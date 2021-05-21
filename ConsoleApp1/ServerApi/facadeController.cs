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
        public bool addItemToStore(string itemBarCode, string item_name, int amount, int price, string shopName, string descreption, string[] catagories)
        {
            Logger.GetInstance().Event("product with barcode " + itemBarCode + " has been added to the shop " + shopName);
            //todo check if works from mohsen!
            if (facade.AddNewProductToSystem(itemBarCode, item_name, descreption, price, catagories))
            {
                return facade.AddItemToStore(shopName, itemBarCode, amount);
            }
            //the item barcode does not match the ProductName in the inventory. 
            return false;
        }

        [HttpGet]
        public string[][] GetUserBaskets(string userName)
        {
            return facade.GetUserBaskets(userName);
        }

        [HttpGet]
        public bool OpenShop(string userName, string shopName, string policy)
        {
            Logger.GetInstance().Event(userName + " has opened shop : " + shopName);
            return facade.OpenStore(userName, shopName, policy);
        }

        [HttpGet]
        public string[][] search(string keyword)
        {
            return facade.SearchByKeyword(keyword);
        }
        [HttpGet]
        public bool makeNewOwner(string storeName, string apointerid, string apointeeid)
        {
            bool output = facade.MakeNewOwner(storeName, apointerid, apointeeid);
            Logger.GetInstance().Event(output
                ? apointerid + " has make new owner for " + storeName
                : apointerid + " could not make new owner for " + storeName);
            return output;
        }
        [HttpGet]
        public bool makeNewManger(string storeName, string apointerid, string apointeeid, int permissions)
        {   //todo split the permissions and make dataStructures that saves the permissions
            bool output = facade.MakeNewManger(storeName, apointerid, apointeeid, permissions);
            Logger.GetInstance().Event(output
                ? apointerid + " has make new manger " + apointeeid + " for " + storeName
                : apointerid + " could not make new manger for " + storeName);
            return output;
        }
        [HttpGet]
        public bool removeOwner(string apointerid, string storeName, string apointeeid)
        {
            bool output = facade.RemoveOwner(apointerid, storeName, apointeeid);
            Logger.GetInstance().Event(output
                ? apointerid + " has has removed owner" + apointeeid + "form store: " + storeName
                : apointerid + " could not removed owner for " + storeName);
            return output;
        }
        [HttpGet]
        public bool removeManager(string apointerid, string storeName, string apointeeid)
        {
            bool output = facade.RemoveManager(apointerid, storeName, apointeeid);
            Logger.GetInstance().Event(output
                ? apointerid + " has has removed manger" + apointeeid + "form store: " + storeName
                : apointerid + " could not removed manger for " + storeName);
            return output;
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

        [HttpGet]
        public bool AddNewProductToSystem(string barcode, string productName, string description, double price,
           string categories)
        {
            bool output = facade.AddNewProductToSystem1(barcode, productName, description, price, categories);
            Logger.GetInstance().Event(output
                ? productName + "with barcode:" + barcode + " has been added to the system "
                : productName + "with barcode:" + barcode + " has not been added to the system");
            return output;

        }

        [HttpGet]
        public bool AddItemToStore(string shopName, string itemBarCode, int amount)
        {
            bool output = facade.AddItemToStore(shopName, itemBarCode, amount);
            Logger.GetInstance().Event(output
                ? " barcode: " + itemBarCode + " has been added to the shop : " + shopName
                : " barcode: " + itemBarCode + " has not been added to the shop : " + shopName);
            return output;
        }
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
        public bool Register(string username, string password)
        {

            bool output = facade.Register(username, password);
            if (output)
            {
                Logger.GetInstance().Event(username + "has Register succesfully ");
            }
            return output;
        }

        [HttpGet]
        public bool Login(string username, string password)
        {
            bool output = facade.Login(username, password);
            if (output)
            {
                Logger.GetInstance().Event(username + "has LoggedIn ");
            }
            return output;
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
        public long GuestLogin()
        {
            long output = facade.GuestLogin();
            Logger.GetInstance().Event("Guest has connected with pid : " + output);
            return output;
        }
    }
}

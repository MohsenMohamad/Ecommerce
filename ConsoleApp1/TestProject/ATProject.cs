using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Version1.domainLayer.CompositeDP;
using Version1.domainLayer.DataStructures;
using Version1.Service_Layer;
using System.Configuration;

namespace TestProject
{
    public class ATProject
    {
        private readonly GenInterface service;

        protected ATProject()
        {
            service = Driver.getInstance();
        }

        protected bool AdminInitiateSystem()
        {
            return service.AdminInitSystem();
        }

        protected bool Register(string name, string password)
        {
            return service.Register(name, password);
        }

        protected long GuestLogin()
        {
            return service.GuestLogin();
        }
        
        protected bool GuestLogout(long id)
        {
            return service.GuestLogout(id);
        }

        protected bool UserLogin(string name, string password)
        {
            return service.Login(name, password);
        }

        protected bool UserLogout(string name)
        {
            return service.Logout(name);
        }

        protected string[] GetAllLoggedInUsers()
        {
            return service.GetAllLoggedInUsers();
        }
        
        protected bool OpenStore(string managerName, string storeName, string policy)
        {
            return service.OpenStore(managerName, storeName, policy);
        }
        
        protected string GetStoreInfo(string userName, string storeName)
        {
            return service.GetStoreInfo(userName, storeName);
        }

        protected bool AddProductToStore(string managerName , string storeName, string barcode, string productName, string description, double price,
            string categories, int amount)
        {
            return service.AddProductToStore(managerName, storeName, barcode, productName, description, price, categories, amount);
        }

        protected bool CheckStoreInventory(string storeName, Hashtable products)
        {
            return service.CheckStoreInventory(storeName, products);
        }

        protected List<string> SearchFilter(string userName, string sortOption, List<string> filters)
        {
            return service.SearchFilter(userName, sortOption, filters);
        }

        protected bool AddProductToCart(string userName, string storeName, string productCode,int amount,double priceofone)
        {
            return service.AddProductToBasket(userName, storeName, productCode,amount,priceofone);
        }

        protected Dictionary<string,int> GetCartByStore(string userName, string storeName)
        {
            return service.GetCartByStore(userName, storeName);
        }

        protected bool initSystem(string admin)
        {
            return service.initSystem(admin);
        }

        protected bool RemoveProductFromStore(string userName, string storeName, string productBarcode)
        {
            return service.RemoveProductFromStore(userName, storeName, productBarcode);
        }

        protected bool UpdateProductAmountInStore(string userName,string storeName, string productBarcode, int amount)
        {
            return service.UpdateProductAmountInStore(userName, storeName, productBarcode, amount);
        }
        
        protected List<string> getPaymentInfo(string owner, string storeName)
        {
            return service.getPaymentInfo(owner, storeName);
        }
        protected List<string> updatePaymentInfo(string owner, string storeName ,List<string> allInfo)
        {
            return service.updatePaymentInfo(owner, storeName,allInfo);
        }
        protected List<string> addPaymentInfo(string owner, string storeName ,string info)
        {
            return service.addPaymentInfo(owner, storeName,info);
        }
        protected ConcurrentDictionary<string,int> GetStoreInventory(string owner,string storeName)
        {
            return service.GetStoreInventory(owner, storeName);
        }
        
        protected string[] getUsersStore(string userName,string  storeName)
        {
            return service.getUsersStore(userName, storeName);
        }

        protected bool AddNewOwner(string store,string user, string  newOwnerName)
        {
            return service.MakeNewOwner(store, user, newOwnerName);
        }
        
        protected bool AddNewManger(string storeName, string apointerName, string apointeeNAme)
        {
            return service.AddNewManger(storeName, apointerName, apointeeNAme);
        }

        protected bool IsOwner(string storeName, string ownerName)
        {
            return service.IsOwner(storeName, ownerName);
        }
        protected bool IsManger(string storeName, string mangerName)
        {
            return service.IsOwner(storeName, mangerName);
        }

        protected List<string> getMangerResponsibilities(string user,string store, string newMangerName)
        {
            return service.getMangerResponsibilities(user, store, newMangerName);
        }

        protected bool updateMangerResponsibilities(string user,string storeName,List<string> responsibilities)
        {
            return service.updateMangerResponsibilities(user, storeName, responsibilities);
        }

        protected bool deleteManger(string ownerUser, string storeName,string newMangerName)
        {
            return service.deleteManger(ownerUser, storeName, newMangerName);
        }
        protected string getInfo(string ownerUser, string store)
        {
            return service.getInfo(ownerUser, store);
        }
        protected List<string> getStorePurchaseHistory(string ownerUser,string store)
        {
            return service.getStorePurchaseHistory(ownerUser, store);
        }
        protected bool buyProduct(string buyer,string store,string product, int amount)
        {
            return service.buyProduct(buyer, store,product,amount);
        }

        protected bool Purchase(string userName, string cardNumber, int expMonth, int expYear, string cardHolder, int cardCcv, int holderId,string nameF, string address, string city, string country, int zip)
        {
            return service.Purchase(userName, cardNumber,expMonth,expYear,cardHolder,cardCcv,holderId,nameF,address,city,country,zip);
        }
        
        public bool ValidateBasketPolicies(string userName, string storeName)
        {

            return service.ValidateBasketPolicies(userName, storeName);
        }
        
        protected string GetHash(string inputString)
        {
            return service.GetHash(inputString);
        }

        protected string GetHashString(string inputString)
        {
            return service.GetHashString(inputString);
        }

        protected bool UpdatePurchasePolicy(string storeName, Component policy)
        {
            return service.UpdatePurchasePolicy(storeName, policy);
        }

        public bool CloseStore(string storeName, string ownerName)
        {
            return new Facade().CloseStore(storeName, ownerName);
        }

        public List<string> GetUserNotifications(string userName)
        {
            return Enumerable.ToList<string>(new Facade().GetAllUserNotifications(userName));
        }
        public List<string> GetUserNotificationsoffer(string userName)
        {
            return Enumerable.ToList<string>(new Facade(ConfigurationManager.AppSettings.Get("mock")).GetAllUserNotificationsoffer(userName));
        }

        public void Recieve_purchase_offer(string username, string storename, string price, string barcode, int amount)
        {
            service.Recieve_purchase_offer(username, storename, price, barcode, amount);
        }

        public void acceptoffer(string barcode, string price, string username, string storename, int amount, string by_username)
        {
            service.acceptoffer(barcode, price, username, storename, amount, by_username);
        }

        public void rejectoffer(string barcode, string price, string username, string storename, int amount, string by_username)
        {
            service.rejectoffer(barcode, price, username, storename, amount, by_username);
        }

        public void CounterOffer(string barcode, string price, string username, string storename, int amount, string owner, string oldprice)
        {
            service.CounterOffer(barcode, price, username, storename, amount, owner, oldprice);
        }

        protected List<Purchase> GetUserPurchaseHistoryList(string userName)
        {
            return service.GetUserPurchaseHistoryList(userName);
        }

    }
}
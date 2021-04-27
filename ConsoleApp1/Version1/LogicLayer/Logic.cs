using System.Collections.Concurrent;
using System.Collections.Generic;
using Version1.domainLayer;

namespace Version1.LogicLayer
{
    public class Logic
    {
        
        public Logic()
        {
            
        }
        
        // 1.1) System init

        public bool InitiateSystem()
        {
            // check if loggedIn user has admin privileges
            return true;
        }
        
        // 2.1) Sign in as a guest

        public long GuestLogin()
        {
            var result = UserLogic.GuestLogin();
            return result;
        }
        
        // 2.2) Exit as a guest

        public bool GuestLogout(long guestId)
        {
            
            var result = UserLogic.GuestLogout(guestId);
            return result;
        }
        
        // 2.3) Register

        public bool Register(string userName, string userPassword)
        {
            var result = UserLogic.Register(userName, userPassword);
            return result;
        }
        
        // 2.4) Login as a user

        public bool UserLogin(string name, string password)
        {
            var result = UserLogic.UserLogin(name, password);
            return result;
        }
        
        // 2.5) Get store info
        
        // 2.6) Search

        public List<string> SearchFilter(string sortOption, List<string> filters)
        {
            return InventoryLogic.SearchFilter(sortOption, filters);
        }
        
        // 2.7) Add a product to a shopping basket

        public bool AddProductToBasket(string userName, string storeName, string productCode, int amount)
        {
            return CartLogic.AddProductToBasket(userName, storeName, productCode, amount);
        }
        
        // 2.8) Get info and edit shopping cart
        
        // 2.9) Purchase
        
        // 3.1) Logout

        public bool UserLogout(string userName)
        {
            var result = UserLogic.UserLogout(userName);
            return result;
        }
        
        // 3.2) Open a store
        public bool OpenStore(string username , string storeName, string policy)
        {
            return StoreLogic.OpenStore(username, storeName, policy);
        }

        public List<Store> GetAllStores()
        {
            return StoreLogic.GetAllStores();
        }

//-------------------------------------- Other ---------------------------------//

        public bool IsLoggedIn(string userName)
        {
            return UserLogic.IsLoggedIn(userName);
        }

        public List<string> GetAllLoggedInUsers()
        {
            return UserLogic.GetAllLoggedInUsers();
        }

        public List<string> GetAllUserNamesInSystem()
        {
            return UserLogic.GetAllUserNamesInSystem();
        }

        public List<string> GetStoreOwners(string storeName)
        {
            return StoreLogic.GetStoreOwners(storeName);
        }
        
        public List<string> GetStoreManagers(string storeName)
        {
            return StoreLogic.GetStoreManagers(storeName);
        }
        
        public List<Product> GetUserBaskets(string userName)
        {
            return CartLogic.GetUserBaskets(userName);

        }

        public bool AddOwner(string storeName, string apointerid, string apointeeid)
        {
            return StoreLogic.AddOwner(storeName, apointerid,apointeeid);
        }

        public bool AddManager(string storeName, string apointerid, string apointeeid, int permissions)
        {
            return StoreLogic.AddManager(storeName,apointerid, apointeeid,permissions);
        }

        public bool RemoveOwner(string apointerid, string storeName, string apointeeid)
        {
            return StoreLogic.RemoveOwner(storeName, apointeeid);
        }

        public bool RemoveManager(string apointerid, string storeName, string apointeeid)
        {
            return StoreLogic.RemoveManager(storeName, apointeeid);
        }

        public bool AddNewProduct(string barcode, string productName,string description, double price, List<string> categories)
        {
            return InventoryLogic.AddNewProduct(barcode, productName, description, price, categories);
        }

        public List<Product> GetBasketProducts(string userName, string storeName)
        {
            return CartLogic.GetBasketProducts(userName, storeName);
        }

        public List<Store> GetUserStores(string userName)
        {
            return StoreLogic.GetUserStores(userName);
        }

        public bool RemoveProductFromCart(string userName, string storeName, string productBarcode, int amount)
        {
            return CartLogic.RemoveProductFromBasket(userName, storeName, productBarcode, amount);
        }
        
        public bool AddUserNotification(string userName, string notification)
        {
            return UserLogic.AddUserNotification(userName, notification);
        }
        
        public List<string> GetUserNotifications(string userName)
        {
            return UserLogic.GetUserNotifications(userName);
        }
        
        public string GetStorePolicy(string storeName)
        {
            return StoreLogic.GetStorePolicy(storeName);
        }

        public bool UpdateStorePolicy(string storeName, string newPolicy)
        {
            return StoreLogic.UpdateStorePolicy(storeName, newPolicy);
        }
        
        public List<Product> SearchByKeyWord(string keyWord)
        {
            return InventoryLogic.SearchByKeyWord(keyWord);
        }
        
        public bool AddProductToStore(string shopName, string barcode, int amount)
        {
            return StoreLogic.AddProductToStore(shopName, barcode, amount);
        }
        
        public bool IsManger(string storeName, string mangerName)
        {
            return StoreLogic.IsManger(storeName, mangerName);
        }        
        
        public Dictionary<string, Product> GetInventory()
        {
            return InventoryLogic.GetInventory();
        }

        public ConcurrentDictionary<Product, int> GetProductsFromShop(string storeName)
        {
            return InventoryLogic.GetProductsFromShop(storeName);
        }

        public List<string> GetStoresNames()
        {
            return StoreLogic.GetStoresNames();
        }
        
    }
}
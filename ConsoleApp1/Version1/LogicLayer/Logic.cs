using System.Collections.Concurrent;
using System.Collections.Generic;
using Version1.DataAccessLayer;
using Version1.domainLayer;

namespace Version1.LogicLayer
{
    public class Logic
    {
        // null = not connected
        private Person currentUser = null;
        private readonly DataHandler dataHandler = DataHandler.Instance;
        private readonly UserSystemHandler userSystemHandler = new UserSystemHandler();
        private readonly StoreAdministration storeAdministration = new StoreAdministration();

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

        public bool GuestLogin()
        {
            if (currentUser != null)
                return false;

            var result = UserLogic.GuestLogin();
            if (result)
                currentUser = Guest.Instance;
            return result;
        }
        
        // 2.2) Exit as a guest

        public bool GuestLogout()
        {
            if (currentUser == null || !IsGuest())
                return false;
            var result = UserLogic.GuestLogout();
            if (result)
                currentUser = null;
            return result;
        }
        
        // 2.3) Register

        public bool Register(string userName, string userPassword)
        {
            if (currentUser != null)
                return false;
            var result = UserLogic.Register(userName, userPassword);
            return result;
        }
        
        // 2.4) Login as a user

        public bool UserLogin(string name, string password)
        {
            if (currentUser != null)
                return false;
            var result = UserLogic.UserLogin(name, password);
            if (result != null)
                currentUser = result;
            return result != null;
        }
        
        // 2.5) Get store info
        
        // 2.6) Search

        public List<string> SearchFilter(string sortOption, List<string> filters)
        {
            if (currentUser == null)
                return null;
            return InventoryLogic.SearchFilter(sortOption, filters);
        }
        
        // 2.7) Add a product to a shopping basket

        public bool AddProductToBasket(string userName, string storeName, string productCode)
        {
            if (currentUser == null)
                return false;
            
            return CartLogic.AddProductToBasket(userName, storeName, productCode);
        }
        
        // 2.8) Get info and edit shopping cart
        
        // 2.9) Purchase
        
        // 3.1) Logout

        public bool UserLogout(string userName)
        {
            if (currentUser == null || IsGuest())
                return false;
            var result = UserLogic.UserLogout();
            if (result)
                currentUser = null;
            return result;
        }
        
        // 3.2) Open a store
        public bool OpenStore(string username , string storeName, string policy)
        {
            if (currentUser == null || IsGuest() || !((User)currentUser).UserName.Equals(username))
                return false;
            return StoreLogic.OpenStore(username, storeName, policy);
        }

        public List<Store> GetAllStores()
        {
            return StoreLogic.GetAllStores();
        }

//-------------------------------------- Other ---------------------------------//

        public List<Product> GetUserBaskets(string userName)
        {
            return CartLogic.GetUserBaskets(userName);

        }

        public bool AddOwner(string apointerid, string storeName, string apointeeid)
        {
            return StoreLogic.AddOwner(storeName, apointeeid);
        }

        public bool AddManager(string apointerid, string storeName, string apointeeid, List<int> permissions)
        {
            return StoreLogic.AddManager(storeName, apointeeid);
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
        
        public string LoggedInUserName()
        {
            // guest
            if (currentUser == null || IsGuest())
            {
                return null;
            }

            return ((User)currentUser).UserName;
        }

        private bool IsGuest()
        {
            return (currentUser is Guest);
        }
        
    }
}
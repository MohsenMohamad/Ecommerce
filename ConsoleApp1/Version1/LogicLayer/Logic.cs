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

        public bool AddProductToCart(string storeName, string productCode)
        {
            if (currentUser == null)
                return false;
            var userName = IsGuest() ? null : ((User) currentUser).UserName;
            return CartLogic.AddProductToCart(userName, storeName, productCode);
        }
        
        // 2.8) Get info and edit shopping cart
        
        // 2.9) Purchase
        
        // 3.1) Logout

        public bool UserLogout()
        {
            if (currentUser == null || IsGuest())
                return false;
            var result = UserLogic.UserLogout();
            if (result)
                currentUser = null;
            return result;
        }
        
        // 3.2) Open a store
        public bool OpenStore(string managerName , string storeName, string policy)
        {
            if (currentUser == null || IsGuest() || !((User)currentUser).UserName.Equals(managerName))
                return false;
            return StoreLogic.OpenStore(managerName, storeName, policy);
        }
        
//-------------------------------------- Other ---------------------------------//


        public bool IsManger(string storeName, string mangerName)
        {
            return StoreLogic.IsManger(storeName, mangerName);
        }        

        public List<Product> GetCartByStore(string userName, string storeName)
        {
            return CartLogic.GetCartByStore(userName, storeName);
        }

        public ConcurrentDictionary<Product, int> getProductsFromShop(User owner, string storeName)
        {
            return InventoryLogic.getProductsFromShop(owner, storeName);
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
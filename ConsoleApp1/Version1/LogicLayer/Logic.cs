using System.Collections.Concurrent;
using System.Collections.Generic;
using Version1.domainLayer.CompositeDP;
using Version1.domainLayer.DataStructures;
using Version1.domainLayer.StorePolicies;

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

        public bool AddProductToBasket(string userName, string storeName, string productCode, int amount,double priceofone)
        {
            return CartLogic.AddProductToBasket(userName, storeName, productCode, amount,priceofone);
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
        public bool OpenStore(string username, string storeName, string policy)
        {
            return StoreLogic.OpenStore(username, storeName, policy);
        }

        public List<Store> GetAllStores()
        {
            return StoreLogic.GetAllStores();
        }

//-------------------------------------- Other ---------------------------------//

        public void DeleteStore(string storeName)
        {
        }


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

        public List<string> GetUserBaskets(string userName)
        {
            return CartLogic.GetUserBaskets(userName);
        }

        public Dictionary<string, int> GetCartByStore(string userName, string storeName)
        {
            return CartLogic.GetCartByStore(userName, storeName);
        }

        public bool Purchase(string userName, string creditCard)
        {
            return CartLogic.Purchase(userName, creditCard);
        }

        public bool UpdateCart(string userName, string storeName, string productBarcode, int newAmount)
        {
            return CartLogic.UpdateCart(userName, storeName, productBarcode, newAmount);
        }

        public bool AddOwner(string storeName, string apointerid, string apointeeid)
        {
            return StoreLogic.AddOwner(storeName, apointerid, apointeeid);
        }

        public bool AddManager(string storeName, string apointerid, string apointeeid, int permissions)
        {
            return StoreLogic.AddManager(storeName, apointerid, apointeeid, permissions);
        }

        public bool RemoveOwner(string apointerid, string storeName, string apointeeid)
        {
            return StoreLogic.RemoveOwner(storeName, apointerid,apointeeid);
        }

        public bool RemoveManager(string apointerid, string storeName, string apointeeid)
        {
            return StoreLogic.RemoveManager(storeName, apointeeid);
        }

        public List<string> GetBasketProducts(string userName, string storeName)
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

        public List<string> GetUserNotificationsoffer(string userName)
        {
            return UserLogic.GetUserNotificationsoffer(userName);
        }

        public string GetStorePolicy(string storeName)
        {
            return StoreLogic.GetStorePolicy(storeName);
        }

        public bool UpdateStorePolicy(string storeName, Component newPolicy)
        {
            return StoreLogic.UpdateStorePolicy(storeName, newPolicy);
        }

        public Dictionary<string,List<string>> SearchByProductName(string productName)
        {
            return InventoryLogic.SearchByProductName(productName);
        }
        
        public Dictionary<string,List<string>> SearchByKeyWord(string keyWord)
        {
            return InventoryLogic.SearchByKeyWord(keyWord);
        }
        
        public Dictionary<string,List<string>> SearchByCategory(string category)
        {
            return InventoryLogic.SearchByCategory(category);
        }

        public bool AddProductToStore(string storeName, string barcode, string productName, string description, double price,
            List<string> categories, int amount)
        {
            return StoreLogic.AddProductToStore(storeName, barcode,productName,description,price,categories, amount);
        }

        public bool IsManger(string storeName, string mangerName)
        {
            return StoreLogic.IsManger(storeName, mangerName);
        }

        public ConcurrentDictionary<string, int> GetStoreInventory(string storeName)
        {
            return InventoryLogic.GetProductsFromShop(storeName);
        }

        public List<string> GetStoreProducts(string storeName)
        {
            return StoreLogic.GetStoreProducts(storeName);
        }

        public bool UpdateProductAmountInStore(string userName, string storeName, string productBarcode, int amount)
        {
            return StoreLogic.UpdateProductAmountInStore(userName, storeName, productBarcode, amount);
        }

        public bool RemoveProductFromStore(string userName, string storeName, string productBarcode)
        {
            return StoreLogic.RemoveProductFromStore(userName, storeName, productBarcode);
        }

        public List<string> GetStoresNames()
        {
            return StoreLogic.GetStoresNames();
        }

        public List<string> GetStorePurchaseHistory(string ownerUser, string storeName)
        {
            return StoreLogic.GetStorePurchaseHistory(ownerUser, storeName);
        }


        public string GetHash(string inputString)
        {
            return UserLogic.GetHash(inputString);
        }

        public string GetHashString(string inputString)
        {
            return UserLogic.GetHashString(inputString);
        }
        
        public bool AddMaxProductPolicy(string storeName, string productBarCode, int amount)
        {
            return StoreLogic.AddMaxProductPolicy(storeName, productBarCode, amount);
        }
        public bool AddCategoryPolicy(string storeName, string productCategory, int hour, int minute)
        {
            return StoreLogic.AddCategoryPolicy(storeName, productCategory, hour, minute);
        }
        public bool AddUserPolicy(string storeName, string productBarCode)
        {
            return StoreLogic.AddUserPolicy(storeName, productBarCode);
        }
        
        public bool AddCartPolicy(string storeName, int amount)
        {
            return StoreLogic.AddCartPolicy(storeName, amount);
        }

        public bool CloseStore(string storeName, string ownerName)
        {
            return StoreLogic.CloseStore(storeName, ownerName);
        }
        public int addPublicDiscount(string storeName, int percentage)
        {
            return StoreLogic.addPublicDiscount(storeName, percentage);
        }

        public int addPublicDiscount_toItem(string storeName, string barcode, int percentage)
        {
            return StoreLogic.addPublicDiscount_toItem(storeName, barcode, percentage);
        }

        //todo implement
        /*public int addConditionalDiscount(int shopid, int percentage, string condition)
        {
            Shop s = new Shop(shopid);
            return s.addConditionalDiscount(percentage, condition);
        }
        
        //todo implement
        public int addConditionalDiscount_toItem(int item_in_shop_id, int percentage, string condition)
        {
            ItemInShop iis = new ItemInShop(item_in_shop_id);
            return iis.addConditionalDiscount_toItem(percentage, condition);
        }*/
        public int addConditionalDiscount(string storeName, int percentage, string condition)
        {
            return StoreLogic.addConditionalDiscount(storeName, percentage,condition);
        }

        public double GetTotalCart(string userName)
        {
            return StoreLogic.GetTotalCart(userName);
        }

        public List<string> GetUserPurchaseHistory(string userName)
        {
            return UserLogic.GetUserPurchaseHistory(userName);
        }
        
        public List<string> GetStorePurchaseHistory(string storeName)
        {
            return StoreLogic.GetStorePurchaseHistory(storeName);
        }

        public bool UpdateUserPassword(string userName, string newPassword)
        {
            return UserLogic.UpdateUserPassword(userName, newPassword);
        }


    }
}
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Version1.DataAccessLayer;
using Version1.domainLayer;
using Version1.domainLayer.UserRoles;
using Version1.LogicLayer;

namespace Version1
{
    public class RealProject : GenInterface
    {
        private Logic logicInstance = new Logic();
        private SystemAdmin admin;
        private ShoppingHandler shoppingHandler = new ShoppingHandler();
        private StoreAdministration storeAdministration = new StoreAdministration();


        public bool AddProductToStore(string managerName, string storeName, string productCode, int amount)
        {
            return storeAdministration.AddToInventory(productCode, amount, storeName);
            
        }

        public bool CheckStoreInventory(string storeName, Hashtable products)
        {
            throw new System.NotImplementedException();
        }

        public Store GetStoreInfo(string userName, string storeName)
        {
            return DataHandler.Instance.GetStore(storeName);
        }

        public bool GuestLogin()
        {
            return logicInstance.GuestLogin();
        }

        public bool GuestLogout()
        {
            return logicInstance.GuestLogout();
        }

        public bool InitiateSystem()
        {
            return logicInstance.InitiateSystem();
        }

        public bool UserLogin(string name, string password)
        {
            return logicInstance.UserLogin(name, password);
        }

        public bool UserLogout(string userName)
        {
            return logicInstance.UserLogout();
        }

        public string LoggedInUserName()
        {
            return logicInstance.LoggedInUserName();
        }

        public bool OpenStore(string managerName, string storeName, string policy)
        {
            return logicInstance.OpenStore(managerName, storeName, policy);
        }

        public bool Register(string name, string password)
        {
            return logicInstance.Register(name, password);
        }

        public List<string> SearchFilter(string userName, string sortOption, List<string> filters)
        {
            return logicInstance.SearchFilter(sortOption, filters);
        }

        public bool AddProductToCart(string userName, string storeName, string productCode)
        {
            return true;
        }
        
        public bool AddProductToCart(string storeName, string productCode)
        {
            return logicInstance.AddProductToCart(storeName, productCode);
        }

        public List<Product> GetCartByStore(string userName, string storeName)
        {

            return logicInstance.GetCartByStore(userName, storeName);
        }

        public ConcurrentDictionary<Product, int> getProductsFromShop(User owner, string storeName)
        {
            return logicInstance.getProductsFromShop(owner, storeName);
        }

        public Store getUsersStore(string userName, string storeName)
        {
            var stores = DataHandler.Instance.Stores.Values;
            foreach (Store st in stores)
            {
                if (st.Name == storeName && (IsOwner(storeName, userName) || IsManger(storeName,userName) ))
                {
                    return st;
                }
            }

            return null;
        }

        public bool AddNewOwner(User user, Store store, string newOwnerName)
        {
            var stores = DataHandler.Instance.Stores.Values;
            foreach (Store st in stores)
            {
                if (st.Name == store.Name)
                {
                    return st.AddOwner(user);
                }
            }
            return false;
        }
        public bool AddNewOwner(string user, string store, string newOwnerName)
        {
            throw new System.NotImplementedException();
        }

        public bool IsOwner(Store store, string ownerName)
        {
            return IsOwner(store.Name, ownerName);
        }
        public bool IsOwner(string storeName, string ownerName)
        {
            var stores = DataHandler.Instance.Stores.Values;
            foreach (Store st in stores)
            {
                if (st.Name == storeName)
                {
                    foreach (User owner in st.co_owners)
                    {
                        if (owner.UserName == ownerName)
                        {
                            return true;
                        }
                    }
                    return true;
                }
            }
            return false;
        }

        public bool AddNewManger(User user, Store store, string newMangerName)
        {
            var stores = DataHandler.Instance.Stores.Values;
            foreach (Store st in stores)
            {
                if (st.Name == store.Name)
                {
                    return st.AddManager(user);
                }
            }

            return false;
        }
        public bool AddNewManger(string userName, string store, string newMangerName)
        {
            var stores = DataHandler.Instance.Stores.Values;
            User user = DataHandler.Instance.GetUser(userName);
            foreach (Store st in stores)
            {
                if (st.Name == store)
                {
                    return st.AddManager(user);
                }
            }

            return false;
        }
        
        public bool IsManger(string storeName, string mangerName)
        {
            return logicInstance.IsManger(storeName, mangerName);
        }
        public List<string> getMangerResponsibilities(User user, Store store, string newMangerName)
        {
            throw new System.NotImplementedException();
        }

        public List<string> getInfo(User user, Store store)
        {
            throw new System.NotImplementedException();
        }

        public bool updateMangerResponsibilities(User user, string storeName, List<string> responsibilities)
        {
            throw new System.NotImplementedException();
        }

        public bool deleteManger(User ownerUser, string storeName, string newMangerName)
        {
            throw new System.NotImplementedException();
        }

        public bool buyProduct(User buyer, Store store, Product product, int amount)
        {
            throw new System.NotImplementedException();
        }

        public List<string> getStorePurchaseHistory(User ownerUser, Store store)
        {
            throw new System.NotImplementedException();
        }
        
        public bool uc_4_1_addEditRemovePruduct(string storeOwnerName, string storeName, string productName, string desc, int amount,
            List<Category> categories)
        {
            throw new System.NotImplementedException();
        }

        public bool initSystem(SystemAdmin admin)
        {
            admin = new SystemAdmin();
            this.admin = admin;
            return true;
        }

        public bool addProductsToShop(User user, string shopName, Product product, int amount)
        {
            Store store = getUsersStore(user.UserName, shopName);
            if (store != null)
            {
                store.addProduct(product, amount);
                return true;
            }

            return false;
        }

        public bool removeProductsInShop(User user, string shopName, Product product)
        {
            Store store = getUsersStore(user.UserName, shopName);
            if (store != null)
            {
                store.RemoveProduct(product);
                return true;
            }

            return false;
        }

        public bool updateProductsInShop(User user, string shopName, Product product, int amount)
        {
            throw new System.NotImplementedException();
        }

        public List<string> getPaymentInfo(User owner, string storeName)
        {
            Store store = getUsersStore(owner.UserName, storeName);
            return store.paymentInfo;
        }

        public List<string> addPaymentInfo(User owner, string storeName, string info)
        {
            Store store = getUsersStore(owner.UserName, storeName);
            if (store != null)
            {
                
                List<string> newInfo = store.paymentInfo;
                newInfo.Add(info);
                store.paymentInfo = newInfo;
                return store.paymentInfo ;
            }
            return null;
        }

        public List<string> updatePaymentInfo(User owner, string storeName, List<string> allInfo)
        {
            Store store = getUsersStore(owner.UserName, storeName);
            if (store != null)
            {
                store.paymentInfo = allInfo;
                return store.paymentInfo ;
            }
            return null;
        }
    }
}
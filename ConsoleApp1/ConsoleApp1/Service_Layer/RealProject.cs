using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using ConsoleApp1.DataAccessLayer;
using ConsoleApp1.domainLayer;
using ConsoleApp1.domainLayer.UserRoles;

namespace ConsoleApp1
{
    public class RealProject : GenInterface
    {
        private SystemAdmin admin;
        private ShoppingHandler shoppingHandler = new ShoppingHandler();
        private StoreAdministration storeAdministration = new StoreAdministration();
        private UserSystemHandler userSystemHandler = new UserSystemHandler("","");



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
            Guest g1 = new Guest();
            g1.Login();
            return g1.signin;
        }

        public bool GuestLogout()
        {
            throw new System.NotImplementedException();
        }

        public bool InitiateSystem()
        {
            admin = new SystemAdmin();
            return true;
        }

        public bool UserLogin(string name, string password)
        {
            return DataHandler.Instance.Login(name, password);
        }

        public bool UserLogout(string name)
        {
            throw new System.NotImplementedException();
        }

        public string LoggedInUserName()
        {
            throw new System.NotImplementedException();
        }

        public bool OpenStore(string managerName, string policy, string storeName)
        {
            return userSystemHandler.OpenStore(storeName,policy);
        }

        public bool Register(string name, string password)
        {
            return DataHandler.Instance.AddUser(new User(name, password));
        }

        public List<string> SearchFilter(string userName, string sortOption, List<string> filters)
        {
            throw new System.NotImplementedException();
        }

        public bool AddProductToCart(string userName, string storeName, string productCode)
        {
            throw new System.NotImplementedException();
        }

        public List<Product> GetCartByStore(string userName, string storeName)
        {

            throw new System.NotImplementedException();
        }

        public ConcurrentDictionary<Product, int> getProductsFromShop(User owner, string storeName)
        {
            throw new System.NotImplementedException();
        }

        public Store getUsersStore(User user, string storeName)
        {
            var stores = DataHandler.Instance.Stores.Values;
            foreach (Store st in stores)
            {
                if (st.Name == storeName && (IsOwner(storeName, user.UserName) || IsManger(storeName,user.UserName) ))
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

        public User loginGuest(string name, string pass)
        {
            foreach (User user in DataHandler.Instance.Users.Values)
            {
                if (user.UserName == name && user.Password == pass)
                {
                    return user;
                }
            }
            return null;
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

        public bool IsManger(Store store, string mangerName)
        {
            return IsManger(store.Name, mangerName);
        }

        public bool IsManger(string storeName, string mangerName)
        {
            var stores = DataHandler.Instance.Stores.Values;
            foreach (Store st in stores)
            {
                if (st.Name == storeName)
                {
                    foreach (User manger in st.managers)
                    {
                        if (manger.UserName == mangerName)
                        {
                            return true;
                        }
                    }
                    return true;
                }
            }
            return false;
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

        public bool loginUser(string name, string pass)
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
            Store store = getUsersStore(user, shopName);
            if (store != null)
            {
                store.addProduct(product, amount);
                return true;
            }

            return false;
        }

        public bool removeProductsInShop(User user, string shopName, Product product)
        {
            Store store = getUsersStore(user, shopName);
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
            Store store = getUsersStore(owner, storeName);
            return store.paymentInfo;
        }

        public List<string> addPaymentInfo(User owner, string storeName, string info)
        {
            Store store = getUsersStore(owner, storeName);
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
            Store store = getUsersStore(owner, storeName);
            if (store != null)
            {
                store.paymentInfo = allInfo;
                return store.paymentInfo ;
            }
            return null;
        }
    }
}
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using ConsoleApp1.domainLayer;
using ConsoleApp1.domainLayer.Business_Layer;
using ConsoleApp1.presentationLayer;

namespace ConsoleApp1.Service_Layer
{
    public class RealProject : GenInterface
    {
        private SystemAdmin admin;
        public bool AddProductToStore(string managerName, string storeName, int productCode, int amount)
        {
            
            foreach (var store in DataHandler.Instance.Stores)
            {
                if (store.Name.Equals(storeName))
                {
                    foreach (var product in DataHandler.Instance.Products)
                    {
                        if (product.Barcode.Equals(productCode))
                        {
                            store.addProduct(product,amount);
                            return true;
                        }
                    }
                }
            }
            
            return false;
        }

        public bool CheckStoreInventory(string storeName, Hashtable products)
        {
            throw new System.NotImplementedException();
        }

        public Store GetStoreInfo(string userName, string storeName)
        {
            return DataHandler.Instance.GetStoreinfo(storeName);
        }

        public bool GuestLogin()
        {
            Guest g1 = new Guest();
            g1.login();
            return g1.signin;
        }

        public bool GuestLogout()
        {
            throw new System.NotImplementedException();
        }

        public bool InitiateSystem()
        {
            admin = new SystemAdmin();
            this.admin = admin;
            return true;
        }

        public bool UserLogin(string name, string password)
        {
            return DataHandler.Instance.loginuser(name, password)!=null;
        }

        public bool UserLogout(string name)
        {
            throw new System.NotImplementedException();
        }

        public bool OpenStore(string managerName, string policy, string storeName)
        {
            foreach (var user in DataHandler.Instance.Users)
            {
                if (user.UserName.Equals(managerName))
                    return user.OpenStore(policy, storeName) != null;
            }
            return false;
        }

        public bool Register(string name, string password)
        {
            if (DataHandler.Instance.exist(name))
            {
                return false;
            }
            DataHandler.Instance.register(name, password);
            return true;
        }

        public List<string> SearchFilter(string userName, string sortOption, List<string> filters)
        {
            throw new System.NotImplementedException();
        }

        public bool AddProductToCart(string userName, string storeName, int productCode)
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

        public bool signUpGuest(string name, string pass)
        {
            if (!DataHandler.Instance.exist(name))
            {
                DataHandler.Instance.register(name,pass);
                return true;
            }

            return false;
        }

        public Store getUsersStore(User user, string storeName)
        {
            List<Store> stores = DataHandler.Instance.Stores;
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
            List<Store> stores = DataHandler.Instance.Stores;
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
            List<Store> stores = DataHandler.Instance.Stores;
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
            foreach (User user in DataHandler.Instance.Users)
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
            List<Store> stores = DataHandler.Instance.Stores;
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
            List<Store> stores = DataHandler.Instance.Stores;
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
            Store s = getUsersStore(ownerUser, store.Name);
            if (s != null)
            {
                List<string> list = new List<string>();
                list.Add(s.history.ToString());
                return list; 
            }

            return null;
        }

        public bool loginUser(string name, string pass)
        {
            return DataHandler.Instance.loginuser(name, pass) != null;
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

        /*public bool initSystem(SystemAdmin admin)
        {
            admin = new SystemAdmin();
            this.admin = admin;
            return true;
        }*/

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
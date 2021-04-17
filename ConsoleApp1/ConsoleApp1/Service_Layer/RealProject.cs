using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using ConsoleApp1.domainLayer.Business_Layer;
using ConsoleApp1.domainLayer.DataAccessLayer;

namespace ConsoleApp1
{
    public class RealProject : GenInterface
    {
        public bool AddProductToStore(User manager, Store store, Product product, int amount)
        {
            store.addProduct(product, amount);
            return true;
        }

        public bool CheckStoreInventory(Store store, Hashtable products)
        {
            throw new System.NotImplementedException();
        }

        public Store GetStoreInfo(User user, string name)
        {
            return DataHandler.Instance.GetStoreinfo(name);
        }

        public bool GuestLogin()
        {
            Guest g1 = new Guest();
            g1.login();
            return g1.signin;
        }

        public bool GuestLogout(User guest)
        {
            throw new System.NotImplementedException();
        }

        public bool InitiateSystem()
        {
            throw new System.NotImplementedException();
        }

        public User MemberLogin(string name, string pass)
        {
            return DataHandler.Instance.loginuser(name, pass);
        }

        public bool MemberLogout(User member)
        {
            throw new System.NotImplementedException();
        }

        public Store OpenStore(User manager, string policy, string name)
        {
            return manager.OpenStore(policy, name);
        }

        public bool Register(string userName, string password)
        {
            if (DataHandler.Instance.exist(userName))
            {
                return false;
            }
            DataHandler.Instance.register(userName, password);
            return true;
        }

        public List<Product> SearchFilter(User user, string sortOption, List<string> filters)
        {
            throw new System.NotImplementedException();
        }

        public bool AddProductToCart(User user, Store store, Product product)
        {
            throw new System.NotImplementedException();
        }

        public List<Product> GetCartByStore(User user, Store store)
        {
            throw new System.NotImplementedException();
        }

        public ConcurrentDictionary<Product, int> getProductsFromShop(User owner, string storeName)
        {
            throw new System.NotImplementedException();
        }

        public bool signUpGuest(string name, string pass)
        {
            throw new System.NotImplementedException();
        }

        public Store getUsersStore(User user, string storeName)
        {
            throw new System.NotImplementedException();
        }

        public bool AddNewOwner(User user, Store store, string newOwnerName)
        {
            throw new System.NotImplementedException();
        }

        public bool IsOwner(Store store, string ownerName)
        {
            throw new System.NotImplementedException();
        }

        public User loginGuest(string name, string pass)
        {
            throw new System.NotImplementedException();
        }

        public bool AddNewManger(User user, Store store, string newMangerName)
        {
            throw new System.NotImplementedException();
        }

        public bool IsManger(Store store, string mangerName)
        {
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
        }

        public bool addProductsToShop(User user, string shopName, Product product, int amount)
        {
            throw new System.NotImplementedException();
        }

        public bool removeProductsInShop(User user, string shopName, Product product)
        {
            throw new System.NotImplementedException();
        }

        public bool updateProductsInShop(User user, string shopName, Product product, int amount)
        {
            throw new System.NotImplementedException();
        }

        public List<string> getPaymentInfo(User owner, string storeName)
        {
            throw new System.NotImplementedException();
        }

        public List<string> addPaymentInfo(User owner, string storeName, string info)
        {
            throw new System.NotImplementedException();
        }

        public List<string> updatePaymentInfo(User owner, string storeName, List<string> allInfo)
        {
            throw new System.NotImplementedException();
        }
    }
}
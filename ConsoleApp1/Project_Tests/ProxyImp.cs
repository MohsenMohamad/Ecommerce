using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using ConsoleApp1;
using ConsoleApp1.domainLayer.Business_Layer;
using ConsoleApp1.domainLayer.DataAccessLayer;
using ConsoleApp1.presentationLayer;
using ConsoleApp1.Service_Layer;


namespace Project_tests
{
    public class ProxyImp : GenInterface
    {   
        private GenInterface real;

        public void SetReal(GenInterface realInstance)
        {
            real = realInstance;
        }

        public bool InitiateSystem()
        {
            if (real == null) 
                return true;    
            
            return real.InitiateSystem();
        }

        public bool GuestLogin()
        {
            if (real == null)
                return false;
            return real.GuestLogin();
        }

        public bool GuestLogout(User guest)
        {
            if (real == null)
                return true;
            return real.GuestLogout(guest);
        }


        public bool Register(string userName, string password)
        {
            if (real == null)
                return true;
            return real.Register(userName, password);
        }

        public User MemberLogin(string name, string pass)
        {
            if (real == null)
            {
                return null;    
            }
            return real.MemberLogin(name,pass);
        }

        public bool MemberLogout(User member)
        {
            if (real == null)
                return true;
            return real.MemberLogout(member);
        }


        public Store OpenStore(User manager,string policy,string name)
        {
            if (real == null)
                return null;
            return real.OpenStore(manager,policy,name);
        }

        public Store GetStoreInfo(User user, string name)
        {
            if (real == null)
                return null;
            return real.GetStoreInfo(user, name);
        }

        public bool CheckStoreInventory(Store store, Hashtable products)
        {
            if (real == null)
                return true;
            return real.CheckStoreInventory(store, products);
        }

        public bool AddProductToStore(User manager, Store store, Product product, int amount)
        {
            if (real == null)
                return true;
            return real.AddProductToStore(manager, store, product, amount);
        }

        public List<Product> SearchFilter(User user, string sortOption, List<string> filters)
        {
            if (real == null)
                return null;
            return real.SearchFilter(user, sortOption, filters);
        }

        public bool AddProductToCart(User user, Store store, Product product)
        {
            if (real == null)
                return true;
            return real.AddProductToCart(user, store, product);
        }

        public List<Product> GetCartByStore(User user, Store store)
        {
            if (real == null)
                return null;
            return real.GetCartByStore(user, store);
        }

        public bool initSystem(SystemAdmin admin)
        {
            if (real == null)
                return false;
            return real.initSystem(admin);
        }

        public bool addProductsToShop(User user,string shopName, Product product, int amount)
        {
            if (real == null)
            {
                return false;    
            }
            return real.addProductsToShop(user,shopName,product,amount);
        }

        public bool removeProductsInShop(User user,string shopName, Product product)
        {
            if (real == null)
            {
                return false;    
            }
            return real.removeProductsInShop( user,shopName,product);
        }

        public bool updateProductsInShop(User user,string shopName, Product product, int amount)
        {
            if (real == null)
            {
                return false;    
            }
            return real.updateProductsInShop( user,shopName,product,amount);
        }
        
        public List<string> getPaymentInfo(User owner,string storeName)
        {
            if (real == null)
            {
                return null;    
            }

            return real.getPaymentInfo(owner, storeName);
        }

        public List<string> addPaymentInfo(User owner,string storeName,string info)
        {
            if (real == null)
            {
                return null;    
            }

            return real.addPaymentInfo(owner, storeName,info);
        }

        public List<string> updatePaymentInfo(User owner,string storeName, List<string> allInfo)
        {
            if (real == null)
            {
                return null;    
            }

            return real.updatePaymentInfo(owner, storeName ,allInfo);
        }

        public ConcurrentDictionary<Product, int> getProductsFromShop(User owner, string storeName)
        {
            if (real == null)
            {
                return null;    
            }

            return real.getProductsFromShop(owner, storeName);
        }

        public bool signUpGuest(string name, string pass)
        {
            if (real == null)
            {
                return false;    
            }

            return real.signUpGuest(name, pass);
        }

        public Store getUsersStore(User user, string storeName)
        {
            if (real == null)
            {
                return null;    
            }

            return real.getUsersStore(user, storeName);
        }

        public bool AddNewOwner(User user, Store store, string newOwnerName)
        {
            if (real == null)
            {
                return false;    
            }

            return real.AddNewOwner(user, store,newOwnerName);
        }

        public bool IsOwner(Store store, string ownerName)
        {
            if (real == null)
            {
                return false;    
            }

            return real.IsOwner(store, ownerName);
        }

        public User loginGuest(string name, string pass)
        {
            if (real == null)
            {
                return null;    
            }

            return real.loginGuest(name, pass);
        }

        public bool AddNewManger(User user, Store store, string newMangerName)
        {
            if (real == null)
            {
                return false;    
            }

            return real.AddNewManger(user, store,newMangerName);
        }

        public bool IsManger(Store store, string mangerName)
        {
            if (real == null)
            {
                return false;    
            }

            return real.IsManger(store, mangerName);
        }

        public List<string> getMangerResponsibilities(User user, Store store, string newMangerName)
        {
            if (real == null)
            {
                return null;    
            }

            return real.getMangerResponsibilities(user,store,newMangerName);
        }

        public bool updateMangerResponsibilities(User user, string storeName, List<string> responsibilities)
        {
            if (real == null)
            {
                return false;    
            }

            return real.updateMangerResponsibilities(user, storeName, responsibilities);
        }

        public bool deleteManger(User ownerUser, string storeName, string newMangerName)
        {
            if (real == null)
            {
                return false;    
            }

            return real.deleteManger(ownerUser, storeName, newMangerName);
        }

        public bool buyProduct(User buyer, Store store, Product product, int amount)
        {
            if (real == null)
            {
                return false;    
            }

            return real.buyProduct(buyer, store, product, amount);
        }

        public List<string> getStorePurchaseHistory(User ownerUser, Store store)
        {
            if (real == null)
            {
                return null;    
            }

            return real.getStorePurchaseHistory(ownerUser, store);
        }

        public bool loginUser(string name, string pass)
        {
            if (real == null)
                return false;
            return real.loginUser(name, pass);
        }

        public bool uc_4_1_addEditRemovePruduct(string storeOwnerName, string storeName, string productName, string desc, int amount,
            List<Category> categories)
        {
            if (real == null)
                return false;
            return real.uc_4_1_addEditRemovePruduct(storeOwnerName, storeName, productName, desc, amount, categories);
        }

        public List<string> getInfo(User ownerUser, Store store)
        {
            if (real == null)
            {
                return null;    
            }

            return real.getInfo(ownerUser, store);
        }
    }
}
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Version1;
using Version1.domainLayer;
using Version1.domainLayer.UserRoles;
using Version1.presentationLayer;


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

        public bool GuestLogout()
        {
            if (real == null)
                return true;
            return real.GuestLogout();
        }


        public bool Register(string name, string password)
        {
            if (real == null)
                return true;
            return real.Register(name, password);
        }

        public bool UserLogin(string name, string password)
        {
            if (real == null)
            {
                return true;    
            }
            return real.UserLogin(name,password);
        }

        public bool UserLogout(string name)
        {
            if (real == null)
                return true;
            return real.UserLogout(name);
        }

        public string LoggedInUserName()
        {
            if (real == null)
                return null;
            return real.LoggedInUserName();
        }


        public bool OpenStore(string managerName,string policy,string storeName)
        {
            if (real == null)
                return true;
            return real.OpenStore(managerName,policy,storeName);
        }

        public Store GetStoreInfo(string userName, string storeName)
        {
            if (real == null)
                return null;
            return real.GetStoreInfo(userName, storeName);
        }

        public bool CheckStoreInventory(string storeName, Hashtable products)
        {
            if (real == null)
                return true;
            return real.CheckStoreInventory(storeName, products);
        }

        public bool AddProductToStore(string managerName, string storeName, string productCode, int amount)
        {
            if (real == null)
                return true;
            return real.AddProductToStore(managerName, storeName, productCode, amount);
        }

        public List<string> SearchFilter(string userName, string sortOption, List<string> filters)
        {
            if (real == null)
                return null;
            return real.SearchFilter(userName, sortOption, filters);
        }

        public bool AddProductToCart(string userName, string storeName, string productCode)
        {
            if (real == null)
                return true;
            return real.AddProductToCart(userName, storeName, productCode);
        }

        public List<Product> GetCartByStore(string userName, string storeName)
        {
            if (real == null)
                return null;
            return real.GetCartByStore(userName, storeName);
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
        
        public Store getUsersStore(string userName, string storeName)
        {
            if (real == null)
            {
                return null;    
            }

            return real.getUsersStore(userName, storeName);
        }

        public bool AddNewOwner(User user, Store store, string newOwnerName)
        {
            if (real == null)
            {
                return false;    
            }

            return real.AddNewOwner(user, store,newOwnerName);
        }

        public bool IsOwner(string storeName, string ownerName)
        {
            if (real == null)
            {
                return false;    
            }

            return real.IsOwner(storeName, ownerName);
        }
        
        public bool AddNewManger(User user, Store store, string newMangerName)
        {
            if (real == null)
            {
                return false;    
            }

            return real.AddNewManger(user, store,newMangerName);
        }

        public bool IsManger(string storeName, string mangerName)
        {
            if (real == null)
            {
                return false;    
            }

            return real.IsManger(storeName, mangerName);
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
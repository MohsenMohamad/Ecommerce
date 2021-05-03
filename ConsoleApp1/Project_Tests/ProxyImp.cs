using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Version1;
using Version1.domainLayer;
using Version1.domainLayer.DataStructures;
using Version1.domainLayer.UserRoles;
using Version1.Service_Layer;


namespace Project_tests
{
    public class ProxyImp : GenInterface
    {   
        private GenInterface real;

        public void SetReal(Facade realInstance)
        {
            real = realInstance;
        }

        public bool AdminInitSystem()
        {
            if (real == null) 
                return true;    
            
            return real.AdminInitSystem();
        }

        public bool Purchase(string userName, string creditCard)
        {
            if (real == null)
                return true;
            return real.Purchase(userName, creditCard);
        }

        public long GuestLogin()
        {
            if (real == null)
                return -1;
            return real.GuestLogin();
        }

        public bool GuestLogout(long id)
        {
            if (real == null)
                return true;
            return real.GuestLogout(id);
        }


        public bool Register(string name, string password)
        {
            if (real == null)
                return true;
            return real.Register(name, password);
        }

        public bool Login(string name, string password)
        {
            if (real == null)
            {
                return true;    
            }
            return real.Login(name,password);
        }

        public bool Logout(string name)
        {
            if (real == null)
                return true;
            return real.Logout(name);
        }

        public string[]  GetAllLoggedInUsers()
        {
            if (real == null)
                return null;
            return real.GetAllLoggedInUsers();
        }


        public bool OpenShop(string managerName,string policy,string storeName)
        {
            if (real == null)
                return true;
            return real.OpenShop(managerName,policy,storeName);
        }

        public string GetStoreInfo(string userName, string storeName)
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

        public bool AddProductToBasket(string userName, string storeName, string productCode,int amount)
        {
            if (real == null)
                return true;
            return real.AddProductToBasket(userName, storeName, productCode,amount);
        }

        public Dictionary<string,int> GetCartByStore(string userName, string storeName)
        {
            if (real == null)
                return null;
            return real.GetCartByStore(userName, storeName);
        }

        public bool initSystem(string admin)
        {
            if (real == null)
                return false;
            return real.initSystem(admin);
        }

        public bool addProductsToShop(string user,string shopName, string product, int amount)
        {
            if (real == null)
            {
                return false;    
            }
            return real.addProductsToShop(user,shopName,product,amount);
        }

        public bool removeProductsInShop(string user,string shopName, string product)
        {
            if (real == null)
            {
                return false;    
            }
            return real.removeProductsInShop( user,shopName,product);
        }

        public bool updateProductsInShop(string user,string shopName, string product, int amount)
        {
            if (real == null)
            {
                return false;    
            }
            return real.updateProductsInShop( user,shopName,product,amount);
        }
        
        public List<string> getPaymentInfo(string owner,string storeName)
        {
            if (real == null)
            {
                return null;    
            }

            return real.getPaymentInfo(owner, storeName);
        }

        public List<string> addPaymentInfo(string owner,string storeName,string info)
        {
            if (real == null)
            {
                return null;    
            }

            return real.addPaymentInfo(owner, storeName,info);
        }

        public List<string> updatePaymentInfo(string owner,string storeName, List<string> allInfo)
        {
            if (real == null)
            {
                return null;    
            }

            return real.updatePaymentInfo(owner, storeName ,allInfo);
        }

        public bool addNewProductToTheSystemAndAddItToShop(string shopName, string barcode, int amount, double price,
            string productName, string descreption, string[] categories)
        {
            if (real == null)
            {
                return false;    
            }

            return real.addNewProductToTheSystemAndAddItToShop(shopName, barcode, amount, price, productName,
                descreption, categories);
        }

        public string[][] get_items_in_shop(string owner, string storeName)
        {
            if (real == null)
            {
                return null;    
            }

            return real.get_items_in_shop(owner, storeName);
        }
        
        public string[] getUsersStore(string userName, string storeName)
        {
            if (real == null)
            {
                return null;    
            }

            return real.getUsersStore(userName, storeName);
        }

        public bool MakeNewOwner(string user, string store, string newOwnerName)
        {
            if (real == null)
            {
                return false;    
            }

            return real.MakeNewOwner(user, store,newOwnerName);
        }

        public bool IsOwner(string storeName, string ownerName)
        {
            if (real == null)
            {
                return false;    
            }

            return real.IsOwner(storeName, ownerName);
        }
        
        public bool AddNewManger(string user, string store, string newMangerName)
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

        public List<string> getMangerResponsibilities(string user, string store, string newMangerName)
        {
            if (real == null)
            {
                return null;    
            }

            return real.getMangerResponsibilities(user,store,newMangerName);
        }

        public bool updateMangerResponsibilities(string user, string storeName, List<string> responsibilities)
        {
            if (real == null)
            {
                return false;    
            }

            return real.updateMangerResponsibilities(user, storeName, responsibilities);
        }

        public bool deleteManger(string ownerUser, string storeName, string newMangerName)
        {
            if (real == null)
            {
                return false;    
            }

            return real.deleteManger(ownerUser, storeName, newMangerName);
        }

        public bool buyProduct(string buyer, string store, string product, int amount)
        {
            if (real == null)
            {
                return false;    
            }

            return real.buyProduct(buyer, store, product, amount);
        }

        public List<string> getStorePurchaseHistory(string ownerUser, string store)
        {
            if (real == null)
            {
                return null;    
            }

            return real.getStorePurchaseHistory(ownerUser, store);
        }
        
        
        public bool uc_4_1_addEditRemovePruduct(string storeOwnerName, string storeName, string productName, string desc, int amount,
            List<string> categories)
        {
            if (real == null)
                return false;
            return real.uc_4_1_addEditRemovePruduct(storeOwnerName, storeName, productName, desc, amount, categories);
        }

        public string getInfo(string ownerUser, string store)
        {
            if (real == null)
            {
                return null;    
            }

            return real.getInfo(ownerUser, store);
        }
    }
}
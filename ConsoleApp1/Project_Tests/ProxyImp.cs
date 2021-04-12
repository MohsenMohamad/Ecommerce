using System.Collections.Concurrent;
using System.Collections.Generic;
using ConsoleApp1;
using ConsoleApp1.domainLayer.Business_Layer;
using ConsoleApp1.domainLayer.DataAccessLayer;
using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine.Client;

namespace Tests
{
    public class ProxyImp : GenInterface
    {   //222222
        private GenInterface real;

        public void setReal(GenInterface real )
        {
            this.real = real;
        }
        public bool loginUser(string name, string pass)
        {
            if (real == null)
            {
                return false;    
            }
            return real.loginUser(name,pass);
        }

        public bool uc_4_1_addEditRemovePruduct(string storeOwnerName, string storeName, string productName, string desc, int amount,
            List<Category> categories)
        {
            if (real == null)
            {
                return false;    
            }
            return real.uc_4_1_addEditRemovePruduct(storeOwnerName,storeName,productName,desc,amount,categories);
        }

        public bool initSystem(SystemAdmin admin)
        {
            if (real == null)
            {
                return false;    
            }
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

        public bool OpenStore(User user, string sellpol, string storeName)
        {
            if (real == null)
            {
                return false;    
            }
            return real.OpenStore( user,sellpol,storeName);
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
    }
}
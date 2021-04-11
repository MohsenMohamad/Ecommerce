using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using ConsoleApp1;
using ConsoleApp1.domainLayer.Business_Layer;
using ConsoleApp1.domainLayer.DataAccessLayer;

namespace Tests
{
    public class ATProject
    {
        //333333
        //444444 add the unit test
        private GenInterface service;

        public ATProject()
        {
            service = Driver.getInstance();
        }

        public bool loginUser(string name, string pass)
        {
            return service.loginUser(name, pass);
        }

        public bool initSystem(SystemAdmin admin)
        {
            return service.initSystem(admin);
        }

        public bool addProductsToShop(User user, string shopName, Product product, int amount)
        {
            return service.addProductsToShop(user, shopName, product, amount);
        }

        public bool removeProductsInShop(User user, string shopName, Product product)
        {
            return service.removeProductsInShop(user, shopName, product);
        }

        public bool updateProductsInShop(User user, string shopName, Product product, int amount)
        {
            return service.updateProductsInShop(user, shopName, product, amount);
        }

        public bool OpenStore(User user, string sellpol, string storeName)
        {
            return service.OpenStore(user, sellpol, storeName);
        }

        public List<string> getPaymentInfo(User owner, string storeName)
        {
            return service.getPaymentInfo(owner, storeName);
        }
        public List<string> updatePaymentInfo(User owner, string storeName ,List<string> allInfo)
        {
            return service.updatePaymentInfo(owner, storeName,allInfo);
        }
        public List<string> addPaymentInfo(User owner, string storeName ,string info)
        {
            return service.addPaymentInfo(owner, storeName,info);
        }
        public ConcurrentDictionary<Product,int> getProductsFromShop(User owner,string storeName)
        {
            return service.getProductsFromShop(owner, storeName);
        }
        
    }
}
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using ConsoleApp1;
using ConsoleApp1.domainLayer.Business_Layer;
using ConsoleApp1.domainLayer.DataAccessLayer;
using NUnit.Framework;

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

        public bool signUpGuest(string name, string pass)
        {
            return service.signUpGuest(name, pass);
        }
        public User loginGuest(string name, string pass)
        {
            return service.loginGuest(name, pass);
        }

        public Store getUsersStore(User user,string  storeName)
        {
            return service.getUsersStore(user, storeName);
        }

        public bool AddNewOwner(User user,Store store,string  newOwnerName)
        {
            return service.AddNewOwner(user, store, newOwnerName);
        }
        
        public bool AddNewManger(User user,Store store,string  newMangerName)
        {
            return service.AddNewOwner(user, store, newMangerName);
        }

        public bool IsOwner(Store store, string ownerName)
        {
            return service.IsOwner(store, ownerName);
        }
        public bool IsManger(Store store, string mangerName)
        {
            return service.IsOwner(store, mangerName);
        }

        public List<string> getMangerResponsibilities(User user,Store store, string newMangerName)
        {
            return service.getMangerResponsibilities(user, store, newMangerName);
        }
        public bool updateMangerResponsibilities(User user,string storeName,List<string> responsibilities)
        {
            return service.updateMangerResponsibilities(user, storeName, responsibilities);
        }

    }
}
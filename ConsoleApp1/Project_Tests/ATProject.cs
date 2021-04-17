using System.Collections;
using System.Collections.Generic;
using System.Collections.Generic;
using ConsoleApp1;
using ConsoleApp1.domainLayer.Business_Layer;
using ConsoleApp1.domainLayer.DataAccessLayer;
using NUnit.Framework;

namespace Project_tests
{
    public class ATProject
    {
        private readonly GenInterface service;

        protected ATProject()
        {
            service = Driver.getInstance();
        }

        protected bool InitiateSystem()
        {
            return service.InitiateSystem();
        }

        protected bool Register(string userName, string password)
        {
            return service.Register(userName, password);
        }

        protected bool GuestLogin()
        {
            return service.GuestLogin();
        }

        protected User MemberLogin(string name, string pass)
        {
            return service.MemberLogin(name, pass);
        }

        protected Store OpenStore(User manager, string policy, string name)
        {
            return service.OpenStore(manager, policy, name);
        }

        protected bool AddProductToStore(User manager, Store store, Product product, int amount)
        {
            return service.AddProductToStore(manager, store, product, amount);
        }

        protected Store GetStoreInfo(User user, string name)
        {
            return service.GetStoreInfo(user, name);
        }

        protected bool CheckStoreInventory(Store store, Hashtable products)
        {
            return service.CheckStoreInventory(store, products);
        }

        protected List<Product> SearchFilter(User user, string sortOption, List<string> filters)
        {
            return service.SearchFilter(user, sortOption, filters);
        }

        protected bool AddProductToCart(User user, Store store, Product product)
        {
            return service.AddProductToCart(user, store, product);
        }

        protected List<Product> GetCartByStore(User user, Store store)
        {
            return service.GetCartByStore(user, store);
        }

        protected bool initSystem(SystemAdmin admin)
        {
            return service.initSystem(admin);
        }

        protected bool addProductsToShop(User user, string shopName, Product product, int amount)
        {
            return service.addProductsToShop(user, shopName, product, amount);
        }

        protected bool removeProductsInShop(User user, string shopName, Product product)
        {
            return service.removeProductsInShop(user, shopName, product);
        }

        protected bool updateProductsInShop(User user, string shopName, Product product, int amount)
        {
            return service.updateProductsInShop(user, shopName, product, amount);
        }

        protected bool OpenStore(User user, string sellpol, string storeName)
        {
            return service.OpenStore(user, sellpol, storeName);
        }

        protected List<string> getPaymentInfo(User owner, string storeName)
        {
            return service.getPaymentInfo(owner, storeName);
        }
        protected List<string> updatePaymentInfo(User owner, string storeName ,List<string> allInfo)
        {
            return service.updatePaymentInfo(owner, storeName,allInfo);
        }
        protected List<string> addPaymentInfo(User owner, string storeName ,string info)
        {
            return service.addPaymentInfo(owner, storeName,info);
        }
        protected ConcurrentDictionary<Product,int> getProductsFromShop(User owner,string storeName)
        {
            return service.getProductsFromShop(owner, storeName);
        }

        protected bool signUpGuest(string name, string pass)
        {
            return service.signUpGuest(name, pass);
        }
        protected User loginGuest(string name, string pass)
        {
            return service.loginGuest(name, pass);
        }

        protected Store getUsersStore(User user,string  storeName)
        {
            return service.getUsersStore(user, storeName);
        }

        protected bool AddNewOwner(User user,Store store,string  newOwnerName)
        {
            return service.AddNewOwner(user, store, newOwnerName);
        }
        
        protected bool AddNewManger(User user,Store store,string  newMangerName)
        {
            return service.AddNewOwner(user, store, newMangerName);
        }

        protected bool IsOwner(Store store, string ownerName)
        {
            return service.IsOwner(store, ownerName);
        }
        protected bool IsManger(Store store, string mangerName)
        {
            return service.IsOwner(store, mangerName);
        }

        protected List<string> getMangerResponsibilities(User user,Store store, string newMangerName)
        {
            return service.getMangerResponsibilities(user, store, newMangerName);
        }

        protected bool updateMangerResponsibilities(User user,string storeName,List<string> responsibilities)
        {
            return service.updateMangerResponsibilities(user, storeName, responsibilities);
        }

        protected bool deleteManger(User ownerUser, string storeName,string newMangerName)
        {
            return service.deleteManger(ownerUser, storeName, newMangerName);
        }
        protected List<string> getInfo(User ownerUser, Store store)
        {
            return service.getInfo(ownerUser, store);
        }
        protected List<string> getStorePurchaseHistory(User ownerUser,Store store)
        {
            return service.getStorePurchaseHistory(ownerUser, store);
        }
        protected bool buyProduct(User buyer,Store store,Product product, int amount)
        {
            return service.buyProduct(buyer, store,product,amount);
        }
        

    }
}
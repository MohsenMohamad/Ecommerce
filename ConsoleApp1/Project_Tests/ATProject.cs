using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using ConsoleApp1.domainLayer;
using ConsoleApp1.presentationLayer;
using ConsoleApp1.domainLayer.UserRoles;
using ConsoleApp1.Service_Layer;

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

        protected bool Register(string name, string password)
        {
            return service.Register(name, password);
        }

        protected bool GuestLogin()
        {
            return service.GuestLogin();
        }
        
        protected bool GuestLogout()
        {
            return service.GuestLogout();
        }

        protected bool UserLogin(string name, string password)
        {
            return service.UserLogin(name, password);
        }

        protected bool UserLogout(string name)
        {
            return service.UserLogout(name);
        }

        protected string LoggedInUserName()
        {
            return service.LoggedInUserName();
        }
        
        protected bool OpenStore(string managerName, string policy, string storeName)
        {
            return service.OpenStore(managerName, policy, storeName);
        }
        
        protected Store GetStoreInfo(string userName, string storeName)
        {
            return service.GetStoreInfo(userName, storeName);
        }

        protected bool AddProductToStore(string managerName, string storeName, string productCode, int amount)
        {
            return service.AddProductToStore(managerName, storeName, productCode, amount);
        }

        protected bool CheckStoreInventory(string storeName, Hashtable products)
        {
            return service.CheckStoreInventory(storeName, products);
        }

        protected List<string> SearchFilter(string userName, string sortOption, List<string> filters)
        {
            return service.SearchFilter(userName, sortOption, filters);
        }

        protected bool AddProductToCart(string userName, string storeName, string productCode)
        {
            return service.AddProductToCart(userName, storeName, productCode);
        }

        protected List<Product> GetCartByStore(string userName, string storeName)
        {
            return service.GetCartByStore(userName, storeName);
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
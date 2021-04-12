using System.Collections.Concurrent;
using System.Collections.Generic;
using ConsoleApp1.domainLayer.Business_Layer;
using ConsoleApp1.domainLayer.DataAccessLayer;

namespace ConsoleApp1
{
    public interface GenInterface
    {
        //111111
        //here are the funtions that we have to implement in ServiceLayer
        bool loginUser(string name, string pass);
        bool uc_4_1_addEditRemovePruduct(string storeOwnerName, string storeName ,string productName,string desc,int amount, List<Category> categories);
        bool initSystem(SystemAdmin admin);
        bool addProductsToShop(User user,string shopName, Product product, int amount);
        bool removeProductsInShop(User user,string shopName, Product product);
        bool updateProductsInShop(User user,string shopName, Product product, int amount);

        bool OpenStore(User user, string sellpol, string storeName);
        List<string> getPaymentInfo(User owner, string storeName);
        List<string> addPaymentInfo(User owner,string storeName,string info);
        List<string> updatePaymentInfo(User owner,string storeName,List<string> allInfo);
        ConcurrentDictionary<Product,int>  getProductsFromShop(User owner, string storeName);
        bool signUpGuest(string name, string pass);
        Store getUsersStore(User user, string storeName);
        bool AddNewOwner(User user, Store store, string newOwnerName);
        bool IsOwner(Store store, string ownerName); 
        User loginGuest(string name, string pass);
        bool AddNewManger(User user, Store store, string newMangerName);
        bool IsManger(Store store, string mangerName);
        List<string> getMangerResponsibilities(User user, Store store, string newMangerName);
        bool updateMangerResponsibilities(User user, string storeName, List<string> responsibilities);

    }
}
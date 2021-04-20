using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using ConsoleApp1.domainLayer.Business_Layer;
using ConsoleApp1.presentationLayer;

namespace ConsoleApp1.Service_Layer
{
    public interface GenInterface
    {
        bool InitiateSystem();
        bool GuestLogin();
        bool GuestLogout(User guest);
        bool Register(string userName, string password);
        User MemberLogin(string name, string pass);
        bool MemberLogout(User member);
        Store OpenStore(User manager, string policy, string name);
        Store GetStoreInfo(User user, string name);
        bool CheckStoreInventory(Store store, Hashtable products);
        bool AddProductToStore(User manager, Store store, Product product, int amount);
        List<Product> SearchFilter(User user, string sortOption, List<string> filters);
        bool AddProductToCart(User user, Store store, Product product);
        List<Product> GetCartByStore(User user, Store store);
        ConcurrentDictionary<Product,int>  getProductsFromShop(User owner, string storeName);
        bool signUpGuest(string name, string pass);
        Store getUsersStore(User user, string storeName);
        bool AddNewOwner(User user, Store store, string newOwnerName);
        bool IsOwner(Store store, string ownerName); 
        User loginGuest(string name, string pass);
        bool AddNewManger(User user, Store store, string newMangerName);
        bool IsManger(Store store, string mangerName);
        List<string> getMangerResponsibilities(User user, Store store, string newMangerName);
        List<string> getInfo(User user, Store store);
        bool updateMangerResponsibilities(User user, string storeName, List<string> responsibilities);
        bool deleteManger(User ownerUser, string storeName, string newMangerName);
        bool buyProduct(User buyer, Store store, Product product, int amount);
        List<string> getStorePurchaseHistory(User ownerUser, Store store);
        bool loginUser(string name, string pass);
        bool uc_4_1_addEditRemovePruduct(string storeOwnerName, string storeName ,string productName,string desc,int amount, List<Category> categories);
        bool initSystem(SystemAdmin admin);
        bool addProductsToShop(User user,string shopName, Product product, int amount);
        bool removeProductsInShop(User user,string shopName, Product product);
        bool updateProductsInShop(User user,string shopName, Product product, int amount);
        List<string> getPaymentInfo(User owner, string storeName);
        List<string> addPaymentInfo(User owner,string storeName,string info);
        List<string> updatePaymentInfo(User owner,string storeName,List<string> allInfo);


    }
    
}
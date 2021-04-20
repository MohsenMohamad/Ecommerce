using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using ConsoleApp1.domainLayer.Business_Layer;
using ConsoleApp1.presentationLayer;

namespace ConsoleApp1.Service_Layer
{
    public interface GenInterface
    {
        bool InitiateSystem(); //
        bool GuestLogin();  //
        bool GuestLogout(); //
        bool Register(string name, string password);    //
        bool UserLogin(string name, string password);   //
        bool UserLogout(string name);   //
        string LoggedInUserName(); // return the logged in user username , return null if he is a guest
        bool OpenStore(string managerName, string policy, string storeName);    //
        Store GetStoreInfo(string userName, string storeName);  // userName = null if user is a guest
        bool CheckStoreInventory(string storeName, Hashtable products); //
        bool AddProductToStore(string managerName, string storeName, string productCode, int amount);  //
        List<string> SearchFilter(string userName, string sortOption, List<string> filters);    //
        bool AddProductToCart(string userName, string storeName, string productCode);  //
        List<Product> GetCartByStore(string userName, string storeName);
        
        
        ConcurrentDictionary<Product,int>  getProductsFromShop(User owner, string storeName);
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
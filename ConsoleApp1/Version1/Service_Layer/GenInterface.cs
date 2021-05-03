using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Version1.domainLayer;
using Version1.domainLayer.DataStructures;
using Version1.domainLayer.UserRoles;

namespace Version1
{
    public interface GenInterface
    {
        bool AdminInitSystem(); //
        bool guestLogin();  //
        bool GuestLogout(); //
        bool Register(string name, string password);    //
        bool Login(string name, string password);   //
        bool Logout(string name);   //
        string[] GetAllLoggedInUsers(); // return the logged in user username , return null if he is a guest
        bool OpenShop(string managerName, string storeName, string policy);    //
        string GetStoreInfo(string userName, string storeName);  // userName = null if user is a guest
        bool CheckStoreInventory(string storeName, Hashtable products); //
        bool AddProductToStore(string managerName, string storeName, string productCode, int amount);  //
        List<string> SearchFilter(string userName, string sortOption, List<string> filters);    //
        bool AddProductToBasket(string userName, string storeName, string productCode,int amount);  //
        Dictionary<string,int> GetCartByStore(string userName, string storeName);
        
        
        string[][] get_items_in_shop(string ownerName, string storeName);
        string[] getUsersStore(string userName, string storeName);
        bool MakeNewOwner(string storeName, string apointerid, string apointeeid);
        bool IsOwner(string storeName, string ownerName); 
        bool AddNewManger(string user, string store, string newMangerName);
        bool IsManger(string storeName, string mangerName);
        List<string> getMangerResponsibilities(string user, string store, string newMangerName);
        string getInfo(string user, string store);
        bool updateMangerResponsibilities(string user, string storeName, List<string> responsibilities);
        bool deleteManger(string ownerUser, string storeName, string newMangerName);
        bool buyProduct(string buyer, string store, string product, int amount);
        List<string> getStorePurchaseHistory(string ownerUser, string store);
        bool uc_4_1_addEditRemovePruduct(string storeOwnerName, string storeName ,string productName,string shopName,int amount, List<string> categories);
        bool initSystem(string admin);
        bool addProductsToShop(string user,string shopName, string product, int amount);
        bool removeProductsInShop(string user,string shopName, string product);
        bool updateProductsInShop(string user,string shopName, string product, int amount);
        List<string> getPaymentInfo(string owner, string storeName);
        List<string> addPaymentInfo(string owner,string storeName,string info);
        List<string> updatePaymentInfo(string owner,string storeName,List<string> allInfo);

        bool addNewProductToTheSystemAndAddItToShop(string shopName, string barcode, int amount, double price,
            string productName, string descreption, string[] categories);


    }
    
}
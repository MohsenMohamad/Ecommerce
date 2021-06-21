using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using ServiceLogic.DataAccessLayer.DataStructures;
using ServiceLogic.DomainLayer.StoreFeatures.StorePolicies.CompositeDP;

namespace ServiceLogic.Service_Layer
{
    public interface GenInterface
    {
        bool AdminInitSystem(); //

        bool Purchase(string userName, string cardNumber, int expMonth, int expYear, string cardHolder, int cardCcv,
            int holderId, string nameF, string address, string city, string country, int zip);
        long GuestLogin();  //
        bool GuestLogout(long id); //
        bool Register(string name, string password);    //
        bool Login(string name, string password);   //
        bool Logout(string name);   //
        string[] GetAllLoggedInUsers(); // return the logged in user username , return null if he is a guest
        bool OpenStore(string managerName, string storeName, string policy);    //
        string GetStoreInfo(string userName, string storeName);  // userName = null if user is a guest
        bool CheckStoreInventory(string storeName, Hashtable products); //
        bool ValidateBasketPolicies(string userName, string storeName);
        List<Purchase> GetUserPurchaseHistoryList(string userName);
        Dictionary<string,List<string>> SearchByProductNameDictionary(string productName);
        Dictionary<string,List<string>> SearchByKeywordDictionary(string keyword);
        Dictionary<string,List<string>> SearchByCategoryDictionary(string category);
        bool MakeNewManger(string storeName, string apointerid, string apointeeid, int permissions);
        bool IsManger(string storeName, string mangerName);


        bool AddProductToStore(string managerName , string storeName, string barcode, string productName, string description, double price,
            string categories1, int amount); //
        bool AddProductToBasket(string userName, string storeName, string productCode,int amount,double priceofone);  //
        Dictionary<string,int> GetCartByStore(string userName, string storeName);
        bool UpdatePurchasePolicy(string storeName, Component policy);

         void Recieve_purchase_offer(string username, string storename, string price, string barcode, int amount);
        void acceptoffer(string barcode, string price, string username, string storename, int amount, string by_username);
        void rejectoffer(string barcode, string price, string username, string storename, int amount, string by_username);
        void CounterOffer(string barcode, string price, string username, string storename, int amount, string owner, string oldprice);


        ConcurrentDictionary<string,int> GetStoreInventory(string ownerName, string storeName);
        string[] getUsersStore(string userName, string storeName);
        bool MakeNewOwner(string storeName, string apointerid, string apointeeid);
        bool IsOwner(string storeName, string ownerName); 
        List<string> getMangerResponsibilities(string user, string store, string newMangerName);
        string getInfo(string user, string store);
        bool updateMangerResponsibilities(string user, string storeName, List<string> responsibilities);
        bool deleteManger(string ownerUser, string storeName, string newMangerName);
        bool buyProduct(string buyer, string store, string product, int amount);
        List<string> getStorePurchaseHistory(string ownerUser, string store);
        bool uc_4_1_addEditRemovePruduct(string storeOwnerName, string storeName ,string productName,string shopName,int amount, List<string> categories);
        bool RemoveProductFromStore(string userName, string storeName, string productBarcode);
        bool UpdateProductAmountInStore(string userName,string storeName, string productBarcode, int amount);
        List<string> getPaymentInfo(string owner, string storeName);
        List<string> addPaymentInfo(string owner,string storeName,string info);
        List<string> updatePaymentInfo(string owner,string storeName,List<string> allInfo);
        bool remove_item_from_cart(string userName, string storeName, string productBarcode, int amount);

        string GetHash(string inputString);
        string GetHashString(string inputString);
        
        int addPublicStoreDiscount(string storeName, int percentage);
        double GetTotalCart(string UserName);
        int addPublicDiscountToItem(string storeName, string barcode, int percentage);
        int addConditionalDiscount(string shopName, int percentage, string condition);
    }
    
}
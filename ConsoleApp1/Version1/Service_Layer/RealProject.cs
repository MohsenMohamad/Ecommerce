using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Version1.DataAccessLayer;
using Version1.domainLayer.CompositeDP;
using Version1.domainLayer.DataStructures;
using Version1.LogicLayer;
using System.Configuration;

namespace Version1.Service_Layer
{
    public class RealProject : GenInterface
    {
        private readonly Facade facade = new Facade("true");
        
        public RealProject()
        {
            string sAttr = ConfigurationManager.AppSettings.Get("mock");
            facade = new Facade(sAttr);
        }

        public void DeleteStore(string storeName)
        {
            TestsLogic.DeleteStore(storeName);
        }

        public void DeleteUser(string userName)
        {
            TestsLogic.DeleteUser(userName);
        }

        public void DeleteProduct(string productBarcode, string storeName)
        {
            TestsLogic.DeleteProduct(productBarcode, storeName);
        }

        public void ResetStorePolicies(string storeName)
        {
            TestsLogic.ResetStorePolicies(storeName);
        }

        public bool AdminInitSystem()
        {
            try
            {
                return facade.AdminInitSystem();
            }
            catch
            {
                return false;
            }
        }

        public bool Purchase(string userName, string cardNumber, int expMonth, int expYear, string cardHolder,
            int cardCcv,
            int holderId, string nameF, string address, string city, string country, int zip)
        {
            try
            {
                return facade.Purchase(userName, cardNumber, expMonth, expYear, cardHolder, cardCcv, holderId, nameF,
                    address, city, country, zip);
            }
            catch
            {
                return false;
            }
        }
        
        public long GuestLogin()
        {
            try
            {
                return facade.GuestLogin();
            }
            catch
            {
                return -1;
            }
        }

        public bool GuestLogout(long id)
        {
            try
            {
                return facade.GuestLogout(id);
            }
            catch
            {
                return false;
            }
        }

        public bool Register(string name, string password)
        {
            try
            {
                return facade.Register(name, password);
            }
            catch
            {
                return false;
            }
        }

        public bool Login(string name, string password)
        {
            try
            {
                return facade.Login(name, password);
            }
            catch
            {
                return false;
            }
        }

        public bool Logout(string name)
        {
            try
            {
                return facade.Logout(name);
            }
            catch
            {
                return false;
            }
        }

        public string[] GetAllLoggedInUsers()
        {
            try
            {
                return facade.GetAllLoggedInUsers();
            }
            catch
            {
                return null;
            }
        }

        public bool OpenStore(string managerName, string storeName, string policy)
        {
            try
            {
                return facade.OpenStore(managerName, storeName, policy);
            }
            catch
            {
                return false;
            }
        }

        public string GetStoreInfo(string userName, string storeName)
        {
            try
            {
                return facade.GetStoreInfo(userName, storeName);
            }
            catch
            {
                return null;
            }
        }

        public bool CheckStoreInventory(string storeName, Hashtable products)
        {
            try
            {
                return CheckStoreInventory(storeName, products);
            }
            catch
            {
                return false;
            }
        }

        public bool ValidateBasketPolicies(string userName, string storeName)
        {
            try
            {
                return facade.ValidateBasketPolicies(userName, storeName);
            }
            catch
            {
                return false;
            }
        }

        public List<Purchase> GetUserPurchaseHistoryList(string userName)
        {
            try
            {
                return facade.GetUserPurchaseHistoryList(userName);
            }
            catch
            {
                return null;
            }
        }

        public bool AddProductToStore(string managerName, string storeName, string barcode, string productName,
            string description,
            double price, string categories1, int amount)
        {
            try
            {
                return facade.AddProductToStore(managerName, storeName, barcode, productName, description, price,
                    categories1, amount);
            }
            catch
            {
                return false;
            }
        }

        public List<string> SearchFilter(string userName, string sortOption, List<string> filters)
        {
            try
            {
                return facade.SearchFilter(userName, sortOption, filters);
            }
            catch
            {
                return null;
            }
        }

        public bool AddProductToBasket(string userName, string storeName, string productCode, int amount,
            double priceofone)
        {
            try
            {
                return facade.AddProductToBasket(userName, storeName, productCode, amount, priceofone);
            }
            catch
            {
                return false;
            }
        }

        public Dictionary<string, int> GetCartByStore(string userName, string storeName)
        {
            try
            {
                return facade.GetCartByStore(userName, storeName);
            }
            catch
            {
                return null;
            }
        }

        public bool UpdatePurchasePolicy(string storeName, Component policy)
        {
            try
            {
                return facade.UpdatePurchasePolicy(storeName, policy);
            }
            catch
            {
                return false;
            }
        }

        public ConcurrentDictionary<string, int> GetStoreInventory(string ownerName, string storeName)
        {
            try
            {
                return facade.GetStoreInventory(ownerName, storeName);
            }
            catch
            {
                return null;
            }
        }

        public string[] getUsersStore(string userName, string storeName)
        {
            try
            {
                return facade.getUsersStore(userName, storeName);
            }
            catch
            {
                return null;
            }
        }

        public bool MakeNewOwner(string storeName, string apointerid, string apointeeid)
        {
            try
            {
                return facade.MakeNewOwner(storeName, apointerid, apointeeid);
            }
            catch
            {
                return false;
            }
        }

        public bool IsOwner(string storeName, string ownerName)
        {
            try
            {
                return facade.IsOwner(storeName, ownerName);
            }
            catch
            {
                return false;
            }
        }

        public bool AddNewManger(string user, string store, string newMangerName)
        {
            try
            {
                return facade.AddNewManger(user, store, newMangerName);
            }
            catch
            {
                return false;
            }
        }

        public bool IsManger(string storeName, string mangerName)
        {
            try
            {
                return facade.IsManger(storeName, mangerName);
            }
            catch
            {
                return false;
            }
        }

        public List<string> getMangerResponsibilities(string user, string store, string newMangerName)
        {
            try
            {
                return facade.getMangerResponsibilities(user, store, newMangerName);
            }
            catch
            {
                return null;
            }
        }

        public string getInfo(string user, string store)
        {
            try
            {
                return facade.getInfo(user, store);
            }
            catch
            {
                return null;
            }
        }

        public bool updateMangerResponsibilities(string user, string storeName, List<string> responsibilities)
        {
            try
            {
                return facade.updateMangerResponsibilities(user, storeName, responsibilities);
            }
            catch
            {
                return false;
            }
        }

        public bool deleteManger(string ownerUser, string storeName, string newMangerName)
        {
            try
            {
                return facade.deleteManger(ownerUser, storeName, newMangerName);
            }
            catch
            {
                return false;
            }
        }

        public bool buyProduct(string buyer, string store, string product, int amount)
        {
            try
            {
                return facade.buyProduct(buyer, store, product, amount);
            }
            catch
            {
                return false;
            }
        }

        public List<string> getStorePurchaseHistory(string ownerUser, string store)
        {
            try
            {
                return facade.getStorePurchaseHistory(ownerUser, store);
            }
            catch
            {
                return new List<string>();
            }
        }

        public bool uc_4_1_addEditRemovePruduct(string storeOwnerName, string storeName, string productName,
            string shopName,
            int amount, List<string> categories)
        {
            try
            {
                return facade.uc_4_1_addEditRemovePruduct(storeOwnerName, storeName, productName, shopName, amount,
                    categories);
            }
            catch
            {
                return false;
            }
        }

        public bool initSystem(string admin)
        {
            try
            {
                return facade.initSystem(admin);
            }
            catch
            {
                return false;
            }
        }

        public bool RemoveProductFromStore(string userName, string storeName, string productBarcode)
        {
            try
            {
                return facade.RemoveProductFromStore(userName, storeName, productBarcode);
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateProductAmountInStore(string userName, string storeName, string productBarcode, int amount)
        {
            try
            {
                return facade.UpdateProductAmountInStore(userName, storeName, productBarcode, amount);
            }
            catch
            {
                return false;
            }
        }

        public List<string> getPaymentInfo(string owner, string storeName)
        {
            try
            {
                return facade.getPaymentInfo(owner, storeName);
            }
            catch
            {
                return new List<string>();
            }
        }

        public List<string> addPaymentInfo(string owner, string storeName, string info)
        {
            try
            {
                return facade.addPaymentInfo(owner, storeName, info);
            }
            catch
            {
                return new List<string>();
            }
        }

        public List<string> updatePaymentInfo(string owner, string storeName, List<string> allInfo)
        {
            try
            {
                return facade.updatePaymentInfo(owner, storeName, allInfo);
            }
            catch
            {
                return new List<string>();
            }
        }

        public bool remove_item_from_cart(string userName, string storeName, string productBarcode, int amount)
        {
            try
            {
                return facade.remove_item_from_cart(userName,storeName,productBarcode,amount);
            }
            catch
            {
                return false;
            }
        }

        public string GetHash(string inputString)
        {
            try
            {
                return facade.GetHash(inputString);
            }
            catch
            {
                return "";
            }
        }

        public string GetHashString(string inputString)
        {
            try
            {
                return facade.GetHashString(inputString);
            }
            catch
            {
                return "";
            }
        }

        public int addPublicStoreDiscount(string storeName, int percentage)
        {
            try
            {
                return facade.addPublicStoreDiscount(storeName, percentage);
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public double GetTotalCart(string UserName)
        {
            try
            {
                return facade.GetTotalCart(UserName);
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public void ResetMemory()
        {
            DataHandler.Instance.Reset();
        }

        public void Recieve_purchase_offer(string username, string storename, string price, string barcode, int amount)
        {
            try
            {
                facade.Recieve_purchase_offer(username, storename, price, barcode, amount);
            }
            catch
            {
                return;
            }
        }

        public void acceptoffer(string barcode, string price, string username, string storename, int amount,
            string by_username)
        {
            try
            {
                facade.acceptoffer(barcode, price, username, storename, amount, by_username);
            }
            catch
            {
                return;
            }
        }

        public void rejectoffer(string barcode, string price, string username, string storename, int amount,
            string by_username)
        {
            try
            {
                facade.rejectoffer(barcode, price, username, storename, amount, by_username);
            }
            catch
            {
                return;
            }
        }

        public void CounterOffer(string barcode, string price, string username, string storename, int amount,
            string owner, string oldprice)
        {
            try
            {
                facade.CounterOffer(barcode, price, username, storename, amount, owner, oldprice);
            }
            catch
            {
                return;
            }
        }

        public int addPublicDiscountToItem(string storeName, string barcode, int percentage)
        {
            try
            {
                return facade.addPublicDiscountToItem(storeName, barcode, percentage);
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public int addConditionalDiscount(string shopName, int percentage, string condition)
        {
            try
            {
                return facade.addConditionalDiscount(shopName, percentage, condition);
            }
            catch (Exception e)
            {
                return -1;
            }
        }
    }
}
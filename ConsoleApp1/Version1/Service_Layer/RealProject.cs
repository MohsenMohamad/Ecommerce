using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Version1.DataAccessLayer;
using Version1.domainLayer.CompositeDP;
using Version1.LogicLayer;

namespace Version1.Service_Layer
{
    public class RealProject : GenInterface
    {
        private readonly Facade facade = new Facade();
        
        public void DeleteStore(string storeName)
        {
            TestsLogic.DeleteStore(storeName);
        }

        public void DeleteUser(string userName)
        {
            TestsLogic.DeleteUser(userName);
        }

        public void DeleteProduct(string productBarcode,string storeName)
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
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Purchase(string userName, string creditCard)
        {
            try
            {
                return facade.Purchase(userName, creditCard);
            }
            catch (Exception e)
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
            catch (Exception e)
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
            catch (Exception e)
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
            catch (Exception e)
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
            catch (Exception e)
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
            catch (Exception e)
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
            catch (Exception e)
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
            catch (Exception e)
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
            catch (Exception e)
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
            catch (Exception e)
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
            catch (Exception e)
            {
                return false;
            }
        }

        public bool AddProductToStore(string managerName, string storeName, string barcode, string productName, string description,
            double price, string categories1, int amount)
        {
            try
            {
                return facade.AddProductToStore(managerName, storeName, barcode, productName, description, price,
                    categories1, amount);
            }
            catch (Exception e)
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
            catch (Exception e)
            {
                return null;
            }
        }

        public bool AddProductToBasket(string userName, string storeName, string productCode, int amount,double priceofone)
        {
            try
            {
                return facade.AddProductToBasket(userName, storeName, productCode, amount, priceofone);
            }
            catch (Exception e)
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
            catch (Exception e)
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
            catch (Exception e)
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
            catch (Exception e)
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
            catch (Exception e)
            {
                return null;
            }
        }

        public bool MakeNewOwner(string storeName, string apointerid, string apointeeid)
        {
            try
            {
                return facade.MakeNewOwner(storeName,apointerid,apointeeid);
            }
            catch (Exception e)
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
            catch (Exception e)
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
            catch (Exception e)
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
            catch (Exception e)
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
            catch (Exception e)
            {
                return null;
            }
        }

        public string getInfo(string user, string store)
        {
            try
            {
                return facade.getInfo(user,store);
            }
            catch (Exception e)
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
            catch (Exception e)
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
            catch (Exception e)
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
            catch (Exception e)
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
            catch (Exception e)
            {
                return new List<string>();
            }
        }

        public bool uc_4_1_addEditRemovePruduct(string storeOwnerName, string storeName, string productName, string shopName,
            int amount, List<string> categories)
        {
            try
            {
                return facade.uc_4_1_addEditRemovePruduct(storeOwnerName, storeName, productName, shopName, amount,
                    categories);
            }
            catch (Exception e)
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
            catch (Exception e)
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
            catch (Exception e)
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
            catch (Exception e)
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
            catch (Exception e)
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
            catch (Exception e)
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
            catch (Exception e)
            {
                return new List<string>();
            }
        }

        public string GetHash(string inputString)
        {
            try
            {
                return facade.GetHash(inputString);
            }
            catch (Exception e)
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
            catch (Exception e)
            {
                return "";
            }
        }

        public void ResetMemory()
        {
            DataHandler.Instance.Reset();
        }
    }
}
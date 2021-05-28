using System;
using System.Collections.Generic;
using System.Linq;
using Version1.DataAccessLayer;
using Version1.domainLayer;
using Version1.domainLayer.DataStructures;
using Version1.domainLayer.StorePolicies;

namespace Version1.LogicLayer
{
    public static class StoreLogic
    {
        public static bool OpenStore(string managerName, string storeName, string policy)
        {
            if (!DataHandler.Instance.Exists(managerName)) throw new Exception(Errors.UserNotFound);
            var store = new Store(managerName, storeName);
            var result = DataHandler.Instance.AddStore(store);
            if (!result)
                throw new Exception(Errors.StoreNameNotAvailable);
            return true;
        }

        public static bool AddProductToStore(string storeName, string barcode, string productName, string description,
            double price,
            List<string> categories, int amount)
        {
            var store = DataHandler.Instance.GetStore(storeName);
            if (store == null) throw new Exception(Errors.StoreNotFound);
            var exists = DataHandler.Instance.GetProduct(barcode, storeName) != null;
            if (exists) throw new Exception(Errors.ProductBarcodeNotAvailable);

            /*  foreach (var category in categories)
              {
                  if (!DataHandler.Instance.Categories.ContainsKey(category))
                      return false;
              }*/

            var product = new Product(barcode, productName, description, price, categories);

            return store.GetInventory().TryAdd(product, amount);
        }

        public static bool IsManger(string storeName, string mangerName)
        {
            if (!DataHandler.Instance.Stores.ContainsKey(storeName) ||
                !DataHandler.Instance.Stores[storeName].GetManagers().Keys.Contains(mangerName))
                return false;
            return true;
        }

        public static bool IsOwner(string storeName, string ownerName)
        {
            if (!DataHandler.Instance.Stores.ContainsKey(storeName) ||
                !DataHandler.Instance.Stores[storeName].GetOwners().Keys.Contains(ownerName))
                return false;
            return true;
        }

        public static bool UpdateProductAmountInStore(string userName, string storeName, string productBarcode,
            int amount)
        {
            lock (DataHandler.Instance.InefficientLock)
            {
                var user = DataHandler.Instance.GetUser(userName);
                if (user == null) throw new Exception(Errors.UserNotFound);
                var store = DataHandler.Instance.GetStore(storeName);
                if (store == null) throw new Exception(Errors.StoreNotFound);
                var product = DataHandler.Instance.GetProduct(productBarcode, storeName);
                if (product == null) throw new Exception(Errors.ProductNotFound);

                var inventory = store.GetInventory();
                if (!inventory.ContainsKey(product)) return false;
                inventory[product] = amount;
                return true;
            }
        }


        public static bool RemoveProductFromStore(string userName, string storeName, string productBarcode)
        {
            lock (DataHandler.Instance.InefficientLock)
            {
                var user = DataHandler.Instance.GetUser(userName);
                if (user == null) throw new Exception(Errors.UserNotFound);
                var store = DataHandler.Instance.GetStore(storeName);
                if (store == null) throw new Exception(Errors.StoreNotFound);
                var product = DataHandler.Instance.GetProduct(productBarcode, storeName);
                if (product == null) throw new Exception(Errors.ProductNotFound);

                var inventory = store.GetInventory();
                return inventory.ContainsKey(product) && inventory.TryRemove(product, out _);
            }
        }

        public static List<string> GetStoreOwners(string storeName)
        {
            var store = DataHandler.Instance.GetStore(storeName);
            return store?.GetOwners().Keys.ToList();
        }

        public static List<string> GetStoreManagers(string storeName)
        {
            var store = DataHandler.Instance.GetStore(storeName);
            return store?.GetManagers().Keys.ToList();
        }


        public static bool AddOwner(string storeName, string apointerid, string apointeeid)
        {
            var appointerUser = DataHandler.Instance.GetUser(apointerid);
            if (appointerUser == null) throw new Exception(Errors.UserNotFound);
            var newOwner = DataHandler.Instance.GetUser(apointeeid);
            if (newOwner == null) throw new Exception(Errors.UserNotFound);
            var store = DataHandler.Instance.GetStore(storeName);
            if (store == null) throw new Exception(Errors.StoreNotFound);

            if (!IsOwner(storeName, apointerid)) throw new Exception(Errors.PermissionError);
            if (IsOwner(storeName, apointeeid)) throw new Exception(Errors.AlreadyOwner);

            store.GetOwners().Add(apointeeid, new List<string>());
            store.GetOwners()[apointerid].Add(apointeeid);
            return true;
        }

        public static bool AddManager(string storeName, string apointerid, string apointeeid, int permissions)
        {
            var appointerUser = DataHandler.Instance.GetUser(apointerid);
            if (appointerUser == null) throw new Exception(Errors.UserNotFound);
            var newManager = DataHandler.Instance.GetUser(apointeeid);
            if (newManager == null) throw new Exception(Errors.UserNotFound);
            var store = DataHandler.Instance.GetStore(storeName);
            if (store == null) throw new Exception(Errors.StoreNotFound);

            if (!IsOwner(storeName, apointerid)) throw new Exception(Errors.PermissionError);
            if (IsManger(storeName, apointeeid)) throw new Exception(Errors.AlreadyManager);

            store.GetManagers().Add(apointeeid, permissions);
            return true;
        }

        public static bool RemoveOwner(string storeName, string username)
        {
            var owner = DataHandler.Instance.GetUser(username);
            if (owner == null) throw new Exception(Errors.UserNotFound);
            var store = DataHandler.Instance.GetStore(storeName);
            if (store == null) throw new Exception(Errors.StoreNotFound);

            var result = store.GetOwners().Remove(username); // returns false if the owner was not found
            if (!result) throw new Exception(Errors.NotAnOwner);
            return true;
        }

        public static bool RemoveManager(string storeName, string username)
        {
            var manager = DataHandler.Instance.GetUser(username);
            if (manager == null) throw new Exception(Errors.UserNotFound);
            var store = DataHandler.Instance.GetStore(storeName);
            if (store == null) throw new Exception(Errors.StoreNotFound);
            
            var result = store.GetManagers().Remove(username); // returns false if the manager was not found
            if(!result)  throw new Exception(Errors.NotAManager);

            return true;
        }

        private static bool IsValidPermission(int permissions)
        {
            return Permissions.IsValidPermission(permissions);
        }


//---------------------------------------- Getters ----------------------------------------//   

        public static List<Store> GetAllStores()
        {
            return DataHandler.Instance.Stores.Values.ToList();
        }

        public static List<Store> GetUserStores(string userName)
        {
            var stores = new List<Store>();
            if (DataHandler.Instance.GetUser(userName) == null)
                return null;

            foreach (var store in GetAllStores())
            {
                if (IsOwner(store.GetName(), userName) || IsManger(store.GetName(), userName))
                    stores.Add(store);
            }

            return stores;
        }


        public static string GetStorePolicy(string storeName)
        {
            var store = DataHandler.Instance.GetStore(storeName);
            return store?.GetPurchasePolicies().ToString();
        }

        public static List<string> GetStoresNames()
        {
            return DataHandler.Instance.Stores.Keys.ToList();
        }

        public static List<string> GetStorePurchaseHistory(string ownerUser, string storeName)
        {
            var store = DataHandler.Instance.GetStore(storeName);
            if (store == null) return null;
            var history = new List<string>();

            foreach (var purchase in store.GetHistory())
            {
                history.Add(purchase.ToString());
            }

            return history;
        }

        public static bool UpdateStorePolicy(string storeName, IPurchasePolicy newPolicy)
        {
            var store = DataHandler.Instance.GetStore(storeName);
            if (store == null) return false;

            store.GetPurchasePolicies().Add(newPolicy);

            return true;
        }

        public static List<string> GetStoreProducts(string storeName)
        {
            var store = DataHandler.Instance.GetStore(storeName);

            return store?.GetInventory().Keys.Select(p => p.Barcode).ToList();
        }
    }
}
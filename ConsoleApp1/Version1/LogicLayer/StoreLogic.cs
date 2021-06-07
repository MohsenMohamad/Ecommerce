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
            if (!DataHandler.Instance.Exists(managerName)) return false;
            var store = new Store(managerName, storeName);
            return DataHandler.Instance.AddStore(store);
        }

        public static  bool AddProductToStore(string storeName, string barcode, string productName, string description, double price,
            List<string> categories, int amount)
        {

            var store = DataHandler.Instance.GetStore(storeName);
            if (store == null || DataHandler.Instance.GetProduct(barcode,storeName) != null) return false;

            /*  foreach (var category in categories)
              {
                  if (!DataHandler.Instance.Categories.ContainsKey(category))
                      return false;
              }*/

            var product = new Product(barcode,productName, description, price, categories);
        
            if( store.GetInventory().TryAdd(product, amount))
            {
                database db = database.GetInstance();

                return db.UpdateStore(store);
            }

            return false;
        }

        public static bool IsManger(string storeName, string mangerName)
        {
            if (!DataHandler.Instance.Stores.ContainsKey(storeName) ||
                !DataHandler.Instance.Stores[storeName].GetManagers().Contains(mangerName))
                return false;
            return true;
        }
        
        public static bool IsOwner(string storeName, string ownerName)
        {
            if (!DataHandler.Instance.Stores.ContainsKey(storeName) ||
                !DataHandler.Instance.Stores[storeName].GetOwners().Contains(ownerName))
                return false;
            return true;
        }

        public static bool UpdateProductAmountInStore(string userName, string storeName, string productBarcode, int amount)
        {
            lock (DataHandler.Instance.InefficientLock)
            {
                var user = DataHandler.Instance.GetUser(userName);
                var store = DataHandler.Instance.GetStore(storeName);
                var product = DataHandler.Instance.GetProduct(productBarcode,storeName);

                if (user == null || store == null || product == null) return false;
                
                var inventory = store.GetInventory();
                if (!inventory.ContainsKey(product)) return false;
                inventory[product]= amount;
                return true;
            }
        }


        public static bool RemoveProductFromStore(string userName, string storeName, string productBarcode)
        {
            lock (DataHandler.Instance.InefficientLock)
            {
                var user = DataHandler.Instance.GetUser(userName);
                var store = DataHandler.Instance.GetStore(storeName);
                var product = DataHandler.Instance.GetProduct(productBarcode,storeName);

                if (user == null || store == null || product == null) return false;

                var inventory = store.GetInventory();
                return inventory.ContainsKey(product) && inventory.TryRemove(product, out _);
            }
        }

        public static List<string> GetStoreOwners(string storeName)
        {
            var store = DataHandler.Instance.GetStore(storeName);
            return store?.GetOwners();
        }
        
        public static List<string> GetStoreManagers(string storeName)
        {
            var store = DataHandler.Instance.GetStore(storeName);
            return store?.GetManagers();
        }

        
        
        public static bool AddOwner(string storeName, string apointerid, string apointeeid)
        {
            var appointerUser = DataHandler.Instance.GetUser(apointerid); 
            var newOwner = DataHandler.Instance.GetUser(apointeeid);
            var store = DataHandler.Instance.GetStore(storeName);
            if (appointerUser == null || newOwner == null || store == null ) return false;
            if (!IsOwner(storeName,apointerid) || IsOwner(storeName, apointeeid)) return false;
            
            store.GetStaffTree().GetNode(apointerid).AddNode(apointeeid,-1);
            return true;
        }
        
        public static bool AddManager(string storeName, string apointerid, string apointeeid, int permissions)
        {
            var appointerUser = DataHandler.Instance.GetUser(apointerid);
            var newManager = DataHandler.Instance.GetUser(apointeeid);
            var store = DataHandler.Instance.GetStore(storeName);
            if (appointerUser == null || newManager == null || store == null) return false;
            if (IsManger(storeName, apointeeid) || !IsValidPermission(permissions)) return false;
            store.GetStaffTree().GetNode(apointerid).AddNode(apointeeid,permissions);
            return true;
        }
        
        public static bool RemoveOwner(string storeName, string username)
        {
            var owner = DataHandler.Instance.GetUser(username);
            var store = DataHandler.Instance.GetStore(storeName);
            if (owner == null || store == null) return false;

            return store.GetStaffTree().DeleteNode(username); // returns false if the owner was not found
        }
        
        public static bool RemoveManager(string storeName, string username)
        {
            var manager = DataHandler.Instance.GetUser(username);
            var store = DataHandler.Instance.GetStore(storeName);
            if (manager == null || store == null) return false;
           
            return store.GetStaffTree().DeleteNode(username);
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
                if(IsOwner(store.GetName(),userName) || IsManger(store.GetName(),userName))
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

            return store?.GetInventory().Keys.Select(p=> p.Barcode).ToList();
        }
        

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using Version1.DataAccessLayer;
using Version1.domainLayer;
using Version1.domainLayer.DataStructures;

namespace Version1.LogicLayer
{
    public static class StoreLogic
    {
        private static readonly DataHandler DataHandler = DataHandler.Instance;

        
        public static bool OpenStore(string managerName, string storeName, string policy)
        {
            if (!DataHandler.Exists(managerName)) return false;
            var store = new Store(managerName, storeName);
            return DataHandler.AddStore(store);
        }

        public static  bool AddProductToStore(string storeName, string barcode, int amount)
        {
            var product = DataHandler.GetProduct(barcode);
            var store = DataHandler.GetStore(storeName);
            if (product == null || store == null) return false;
            
            store.addProduct(barcode, amount);
            
            // add to data access
            
            return true;

        }

        public static bool IsManger(string storeName, string mangerName)
        {
            if (!DataHandler.Stores.ContainsKey(storeName) ||
                !DataHandler.Stores[storeName].GetManagers().Keys.Contains(mangerName))
                return false;
            return true;
        }
        
        public static bool IsOwner(string storeName, string ownerName)
        {
            if (!DataHandler.Stores.ContainsKey(storeName) ||
                !DataHandler.Stores[storeName].GetOwners().Keys.Contains(ownerName))
                return false;
            return true;
        }

        public static List<string> GetStoreOwners(string storeName)
        {
            var store = DataHandler.GetStore(storeName);
            return store?.GetOwners().Keys.ToList();
        }
        
        public static List<string> GetStoreManagers(string storeName)
        {
            var store = DataHandler.GetStore(storeName);
            return store?.GetManagers().Keys.ToList();
        }

        
        
        public static bool AddOwner(string storeName, string apointerid, string apointeeid)
        {
            var appointerUser = DataHandler.GetUser(apointerid); 
            var newOwner = DataHandler.GetUser(apointeeid);
            var store = DataHandler.GetStore(storeName);
            if (appointerUser == null || newOwner == null || store == null ) return false;
            if (IsOwner(storeName, apointeeid)) return false;
            store.GetOwners().Add(apointeeid, new List<string>());
            store.GetOwners()[apointerid].Add(apointeeid);
            return true;
        }
        
        public static bool AddManager(string storeName, string apointerid, string apointeeid, int permissions)
        {
            var appointerUser = DataHandler.GetUser(apointerid);
            var newManager = DataHandler.GetUser(apointeeid);
            var store = DataHandler.GetStore(storeName);
            if (appointerUser == null || newManager == null || store == null) return false;
            if (IsManger(storeName, apointeeid) || !IsValidPermission(permissions)) return false;
            store.GetManagers().Add(apointeeid , permissions);
            return true;
        }
        
        public static bool RemoveOwner(string storeName, string username)
        {
            var owner = DataHandler.GetUser(username);
            var store = DataHandler.GetStore(storeName);
            if (owner == null || store == null) return false;
            
            return store.GetOwners().Remove(username); // returns false if the owner was not found
        }
        
        public static bool RemoveManager(string storeName, string username)
        {
            var manager = DataHandler.GetUser(username);
            var store = DataHandler.GetStore(storeName);
            if (manager == null || store == null) return false;
            
            return store.GetManagers().Remove(username); // returns false if the manager was not found
        }

        private static bool IsValidPermission(int permissions)
        {
            return Permissions.IsValidPermission(permissions);
        }
        
        
//---------------------------------------- Getters ----------------------------------------//   

        public static List<Store> GetAllStores()
        {
            return DataHandler.Stores.Values.ToList();
        }

        public static List<Store> GetUserStores(string userName)
        {
            var stores = new List<Store>();
            if (DataHandler.GetUser(userName) == null)
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
            var store = DataHandler.GetStore(storeName);
            return store?.GetPurchasePolicies().ToString();
        }

        public static List<string> GetStoresNames()
        {
            return DataHandler.Stores.Keys.ToList();
        }

        public static bool UpdateStorePolicy(string storeName, string newPolicy)
        {
            var store = DataHandler.GetStore(storeName);
            if (store == null) return false;
        //    store.SetPurchasePolicies(newPolicy);
            
            // update DataAccess

            return true;

        }
        
    }
}
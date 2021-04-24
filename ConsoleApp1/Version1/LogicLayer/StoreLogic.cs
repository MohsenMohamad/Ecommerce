using System.Collections.Generic;
using System.Linq;
using Version1.DataAccessLayer;
using Version1.domainLayer;

namespace Version1.LogicLayer
{
    public static class StoreLogic
    {
        private static readonly DataHandler DataHandler = DataHandler.Instance;

        
        public static bool OpenStore(string managerName, string storeName, string policy)
        {
            var store = new Store(DataHandler.GetUser(managerName), policy, storeName);
            return DataHandler.AddStore(store);
        }

        public static  bool AddItemToStore(string storeName, string barcode, int amount)
        {
            var product = DataHandler.GetProduct(barcode);
            var store = DataHandler.GetStore(storeName);
            if (product == null || store == null) return false;
            
            store.addProduct(product, amount);
            
            // add to data access
            
            return true;

        }

        public static bool IsManger(string storeName, string mangerName)
        {
            if (!DataHandler.Stores.ContainsKey(storeName) ||
                !DataHandler.Stores[storeName].GetManagers().Contains(DataHandler.GetUser(mangerName)))
                return false;
            return true;
        }
        
//---------------------------------------- Getters ----------------------------------------//   

        public static List<Store> GetAllStores()
        {
            return DataHandler.Stores.Values.ToList();
        }

        public static string GetStorePolicy(string storeName)
        {
            var store = DataHandler.GetStore(storeName);
            return store?.GetSellingPolicy();
        }

        public static bool UpdateStorePolicy(string storeName, string newPolicy)
        {
            var store = DataHandler.GetStore(storeName);
            if (store == null) return false;
            store.SetSellingPolicy(newPolicy);
            
            // update DataAccess

            return true;

        }
        
    }
}
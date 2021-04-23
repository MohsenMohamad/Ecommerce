using System.Collections.Concurrent;
using System.Collections.Generic;
using Version1.DataAccessLayer;
using Version1.domainLayer;

namespace Version1.LogicLayer
{
    public static class InventoryLogic
    {
        private static readonly DataHandler DataHandler = DataHandler.Instance;

        public static List<string> SearchFilter(string sortOption, List<string> filters)
        {
            return new List<string>();
        }

        public static ConcurrentDictionary<Product, int> getProductsFromShop(User owner, string storeName)
        {
            var store = DataHandler.GetStore(storeName);
            if (store == null)
                return null;
            return store.inventory;
        }
    }
}
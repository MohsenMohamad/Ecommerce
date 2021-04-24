using System.Collections.Concurrent;
using System.Collections.Generic;
using Version1.DataAccessLayer;
using Version1.domainLayer;

namespace Version1.LogicLayer
{
    public static class InventoryLogic
    {
        private static readonly DataHandler DataHandler = DataHandler.Instance;

        public static Dictionary<string, Product> GetInventory()
        {
            return DataHandler.Products;
        }
        
        public static List<string> SearchFilter(string sortOption, List<string> filters)
        {
            return new List<string>();
        }

        public static ConcurrentDictionary<Product, int> GetProductsFromShop(string storeName)
        {
            var store = DataHandler.GetStore(storeName);
            if (store == null)
                return null;
            return store.inventory;
        }

        public static List<Product> SearchByKeyWord(string keyWord)
        {
            var searchResult = new List<Product>();
            var allProducts = DataHandler.Products.Values;
            foreach (var product in allProducts)
            {
                if(product.Name.Contains(keyWord) || product.Description.Contains(keyWord))
                    searchResult.Add(product);
            }

            return searchResult;
        }
    }
}
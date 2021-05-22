using System.Collections.Concurrent;
using System.Collections.Generic;
using Version1.DataAccessLayer;

namespace Version1.LogicLayer
{
    public static class InventoryLogic
    {
        
        public static List<string> SearchFilter(string sortOption, List<string> filters)
        {
            return new List<string>();
        }

        public static ConcurrentDictionary<string, int> GetProductsFromShop(string storeName)
        {
            var products = new ConcurrentDictionary<string, int>();
            var store = DataHandler.Instance.GetStore(storeName);
            if (store == null)
                return null;
            var inventory = store.GetInventory();
            foreach (var product in inventory.Keys)
            {
                products.TryAdd(product.Barcode, inventory[product]);
            }

            return products;
        }

        public static Dictionary<string,List<string>> SearchByKeyWord(string keyWord)
        {
            var searchResult = new Dictionary<string, List<string>>();
            var allProducts = DataHandler.Instance.GetAllProducts();
            
            foreach (var products in allProducts)
            {
                var storeName = products.Key;
                foreach (var product in products.Value)
                {
                    if (!product.Name.Contains(keyWord) && !product.Description.Contains(keyWord)) continue;
                    
                    if(!searchResult.ContainsKey(storeName))
                        searchResult.Add(storeName,new List<string>());
                    searchResult[storeName].Add(product.Barcode);
                }
                
            }

            return searchResult;
        }
    }
}
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Version1.DataAccessLayer;
using Version1.domainLayer;
using Version1.domainLayer.DataStructures;

namespace Version1.LogicLayer
{
    public static class InventoryLogic
    {

        public static Dictionary<string, Product> GetInventory()
        {
            return new Dictionary<string,Product> (DataHandler.Instance.Products);
        }

        public static bool AddNewProduct(string barcode, string productName, string description, double price,
            List<string> categories)
        {
            if (DataHandler.Instance.Products.ContainsKey(barcode))
                return false;

          /*  foreach (var category in categories)
            {
                if (!DataHandler.Instance.Categories.ContainsKey(category))
                    return false;
            }*/
            
            var product = new Product(productName, description, barcode, price, categories);
            return DataHandler.Instance.AddProduct(product);
        }


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
            foreach (var barcode in inventory.Keys)
            {
                products.TryAdd(barcode, inventory[barcode]);
            }
            return products;
        }

        public static List<string> SearchByKeyWord(string keyWord)
        {
            var searchResult = new List<string>();
            var allProducts = DataHandler.Instance.Products.Values;
            foreach (var product in allProducts)
            {
                if (product.Name.Contains(keyWord) || product.Description.Contains(keyWord))
                    searchResult.Add(product.Barcode);
            }

            return searchResult;
        }
        
    }
}
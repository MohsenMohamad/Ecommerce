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

        public static bool AddNewProduct(string barcode, string productName, string description, double price,
            List<string> categories)
        {
            if (DataHandler.Products.ContainsKey(barcode))
                return false;
            var categoriesList = new List<Category>();

            foreach (var category in categories)
            {
                if (!DataHandler.Categories.ContainsKey(category))
                    return false;
            }
            
            var product = new Product(productName, description, barcode, price, categories);
            return DataHandler.AddProduct(product);
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
            return store.GetInventory();
        }

        public static List<Product> SearchByKeyWord(string keyWord)
        {
            var searchResult = new List<Product>();
            var allProducts = DataHandler.Products.Values;
            foreach (var product in allProducts)
            {
                if (product.Name.Contains(keyWord) || product.Description.Contains(keyWord))
                    searchResult.Add(product);
            }

            return searchResult;
        }
        
    }
}
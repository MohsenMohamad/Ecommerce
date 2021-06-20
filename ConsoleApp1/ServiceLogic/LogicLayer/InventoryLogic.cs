using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using ServiceLogic.DataAccessLayer;
using ServiceLogic.DataAccessLayer.DataStructures;
using ServiceLogic.domainLayer;

namespace ServiceLogic.LogicLayer
{
    public static class InventoryLogic
    {

        public static bool TakeFromStoreInventory(ShoppingBasket basket)
        {
            var storeInventory = DataHandler.Instance.GetStore(basket.StoreName).GetInventory();
            bool updated = true;
            foreach (var productBarcode in basket.Products.Keys.ToList())
            {
                var product = DataHandler.Instance.GetProduct(productBarcode, basket.StoreName);
                var amount = basket.Products[productBarcode];

                if (product == null || !storeInventory.ContainsKey(product) || storeInventory[product] < amount)
                    return false;

                storeInventory[product] -= amount;
            }

            return true;
        }

        public static ConcurrentDictionary<string, int> GetProductsFromShop(string storeName)
        {
            var products = new ConcurrentDictionary<string, int>();
            var store = DataHandler.Instance.GetStore(storeName);
            if (store == null) throw new Exception(Errors.StoreNotFound);

            var inventory = store.GetInventory();

            foreach (var product in inventory.Keys)
            {
                products.TryAdd(product.Barcode, inventory[product]);
            }

            return products;
        }

        public static Dictionary<string, List<string>> SearchByKeyWord(string keyWord)
        {
            var searchResult = new Dictionary<string, List<string>>();
            var allProducts = DataHandler.Instance.GetAllProducts();

            foreach (var products in allProducts)
            {
                var storeName = products.Key;
                foreach (var product in products.Value)
                {
                    if (!product.Name.Contains(keyWord) && !product.Description.Contains(keyWord)) continue;

                    if (!searchResult.ContainsKey(storeName))
                        searchResult.Add(storeName, new List<string>());
                    searchResult[storeName].Add(product.Barcode);
                }
            }

            return searchResult;
        }

        public static Dictionary<string, List<string>> SearchByProductName(string productName)
        {
            var searchResult = new Dictionary<string, List<string>>();
            var allProducts = DataHandler.Instance.GetAllProducts();

            foreach (var products in allProducts)
            {
                var storeName = products.Key;
                foreach (var product in products.Value)
                {
                    if (!product.Name.Contains(productName)) continue;

                    if (!searchResult.ContainsKey(storeName))
                        searchResult.Add(storeName, new List<string>());
                    searchResult[storeName].Add(product.Barcode);
                }
            }

            return searchResult;
        }

        public static Dictionary<string, List<string>> SearchByCategory(string category)
        {
            var searchResult = new Dictionary<string, List<string>>();
            var allProducts = DataHandler.Instance.GetAllProducts();

            foreach (var products in allProducts)
            {
                var storeName = products.Key;
                foreach (var product in products.Value)
                {
                    if (!product.Categories.Contains(category)) continue;

                    if (!searchResult.ContainsKey(storeName))
                        searchResult.Add(storeName, new List<string>());
                    searchResult[storeName].Add(product.Barcode);
                }
            }

            return searchResult;
        }

        public static Dictionary<string, List<string>> FilterByPrice(double minimumPrice, double maximumPrice,
            Dictionary<string, List<string>> products)
        {
            var result = new Dictionary<string, List<string>>();
            foreach (var storeProducts in products)
            {
                foreach (var barcode in storeProducts.Value.Where(barcode =>
                    DataHandler.Instance.GetProduct(barcode, storeProducts.Key).Price >= minimumPrice &&
                    DataHandler.Instance.GetProduct(barcode, storeProducts.Key).Price <= maximumPrice))
                {
                    if (!result.ContainsKey(storeProducts.Key)) result.Add(storeProducts.Key, new List<string>());
                    result[storeProducts.Key].Add(barcode);
                }
            }

            return result;
        }
    }
}
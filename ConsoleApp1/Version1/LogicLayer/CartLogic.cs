using System.Collections.Generic;
using System.Linq;
using Version1.DataAccessLayer;
using Version1.domainLayer;

namespace Version1.LogicLayer
{
    public static class CartLogic
    {
        private static readonly DataHandler DataHandler = DataHandler.Instance;

        public static bool AddProductToBasket(string userName ,string storeName, string productCode)
        {
            var product = DataHandler.GetProduct(productCode);
            var store = DataHandler.GetStore(storeName);
            
            if (product == null || store == null)
                return false;
            
            if (userName == null)
                return Guest.Instance.AddItemToBasket(storeName,product , 0);

            return DataHandler.GetUser(userName).AddItemToBasket(storeName,product,0);
        }

        public static bool RemoveProductFromBasket(string userName, string storeName, string productBarcode, int amount)
        {
            var user = DataHandler.GetUser(userName);
            var store = DataHandler.GetStore(storeName);
            var product = DataHandler.GetProduct(productBarcode);

            if (user == null || store == null || product == null)
                return false;
            
            var cart = user.GetShoppingCart();
            if (!cart.shoppingBaskets.ContainsKey(storeName))
                return false;
            var result = cart.shoppingBaskets[storeName].RemoveProduct(product, amount);
            return result;
        }
        
        public static bool RemoveProductFromBasket(string userName, string storeName, string productBarcode)
        {
            var user = DataHandler.GetUser(userName);
            var store = DataHandler.GetStore(storeName);
            var product = DataHandler.GetProduct(productBarcode);
            
            if (user == null || store == null || product == null)
                return false;
            var cart = user.GetShoppingCart();
            
            if (!cart.shoppingBaskets.ContainsKey(storeName))
                return false;
            var result = cart.shoppingBaskets[storeName].RemoveProduct(product);
            return result;
        }


        public static List<Product> GetBasketProducts(string userName, string storeName)
        {
            if (userName == null)
            {
                if (Guest.Instance.shoppingCart.shoppingBaskets.ContainsKey(storeName))
                    return Guest.Instance.shoppingCart.shoppingBaskets[storeName].Products.Keys.ToList();
                return null;
            }

            var userBaskets = DataHandler.GetUser(userName).shoppingCart.shoppingBaskets;
            if(userBaskets.ContainsKey(storeName))
                return userBaskets[storeName].Products.Keys.ToList();
            return null;
        }

        public static List<Product> GetUserBaskets(string userName)
        {
            var user = DataHandler.GetUser(userName);
            if (user == null)
                return null;
            var products = new List<Product>();

            foreach (var store in user.GetShoppingCart().shoppingBaskets.Keys)
            {
                var basketProducts = GetBasketProducts(userName, store);
                products.AddRange(basketProducts);
            }

            return products;
        }

    }
}
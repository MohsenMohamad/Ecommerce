using System.Collections.Generic;
using System.Linq;
using Version1.DataAccessLayer;
using Version1.domainLayer;

namespace Version1.LogicLayer
{
    public static class CartLogic
    {
        private static readonly DataHandler DataHandler = DataHandler.Instance;

        public static bool AddProductToCart(string userName ,string storeName, string productCode)
        {
            var product = DataHandler.GetProduct(productCode);
            var store = DataHandler.GetStore(storeName);
            
            if (product == null || store == null)
                return false;
            
            if (userName == null)
                return Guest.Instance.AddItemToBasket(storeName,product , 0);

            return DataHandler.GetUser(userName).AddItemToBasket(storeName,product,0);
        }

        public static List<Product> GetCartByStore(string userName, string storeName)
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
    }
}
using System.Collections.Generic;

namespace ServiceLogic.DataAccessLayer.DataStructures
{
    public class ShoppingCart
    {
        
        
        public Dictionary<string, ShoppingBasket> shoppingBaskets { get; set; }

        public ShoppingCart()
        {
            shoppingBaskets = new Dictionary<string, ShoppingBasket>();
        }

        public ShoppingBasket GetBasket(string storeName)
        {
            if (!shoppingBaskets.ContainsKey(storeName))
                return null;
            return shoppingBaskets[storeName];
        }
    }
}

using System.Collections.Generic;

namespace Version1.domainLayer.DataStructures
{
    public class ShoppingCart
    {
        
        // todo mohsen
        public int id;
        internal Dictionary<string, ShoppingBasket> shoppingBaskets { get; set; }

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

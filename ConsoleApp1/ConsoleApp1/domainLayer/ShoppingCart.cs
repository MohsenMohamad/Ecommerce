using System.Collections.Generic;


namespace ConsoleApp1.domainLayer.Business_Layer
{
    public class ShoppingCart
    {
        // <storeName,ShoppingBasket>
        internal Dictionary<string, ShoppingBasket> shoppingBaskets { get; set; }

        public ShoppingCart()
        {
            shoppingBaskets = new Dictionary<string, ShoppingBasket>();
        }


        public bool AddBasket(ShoppingBasket shoppingBasket)
        {
            if (shoppingBaskets.ContainsKey(shoppingBasket.StoreName))
                return false;
            shoppingBaskets.Add(shoppingBasket.StoreName,shoppingBasket);
            return true;
        }
        public bool RemoveBasket(ShoppingBasket shoppingBasket)
        {
            return shoppingBaskets.Remove(shoppingBasket.StoreName);
        }

        public bool AddProductToBasket(string storeName, Product product, int amount)
        {
            if (!shoppingBaskets.ContainsKey(storeName))
                AddBasket(new ShoppingBasket(storeName));
            return shoppingBaskets[storeName].AddProduct(product, amount);
        }
        
        public bool RemoveProductFromBasket(string storeName, Product product)
        {
            if (!shoppingBaskets.ContainsKey(storeName))
                return false;
            return shoppingBaskets[storeName].RemoveProduct(product);
        }
    }
}

using System.Collections.Generic;

namespace Version1.domainLayer
{
    public class ShoppingBasket
    {
        internal string StoreName { get; }
        internal Dictionary<Product, int> Products { get; }
        
        public ShoppingBasket(string storeName)
        {
            this.Products = new Dictionary<Product, int>();
            this.StoreName = StoreName;
        }
        public bool AddProduct(Product product, int amount)
        {
            if (amount < 0)
                return false;
            if (Products.ContainsKey(product))
                Products[product] += amount;
            else
                Products.Add(product,amount);
            return true;
        }

        public bool RemoveProduct(Product product)
        {
            return Products.Remove(product);
        }
        
        public bool RemoveProduct(Product product, int amount)
        {
            if (!Products.ContainsKey(product) || Products[product] < amount)
                return false;
            Products[product] -= amount;
            // remove it if new amount = 0 ?
            return true;
        }
        
        public override string ToString()
        {
            var output= "basket for "+StoreName;
            foreach (var entry in Products)
            {
                var productName = entry.Key;
                var productAmount = entry.Value;
                output += "\n"+productName+" with the amount of "+productAmount;
            }
            return output;
        }
    }
}

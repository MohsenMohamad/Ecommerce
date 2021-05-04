using System.Collections.Generic;
using Version1.DataAccessLayer;

namespace Version1.domainLayer.DataStructures
{
    public class ShoppingBasket
    {
        internal string StoreName { get; }
        internal Dictionary<string, int> Products { get; }
        
        public ShoppingBasket(string storeName)
        {
            Products = new Dictionary<string, int>();
            StoreName = storeName;
        }
        public bool AddProduct(string product, int amount)
        {
            if (amount < 0)
                return false;
            var storeProducts = DataHandler.Instance.GetStore(StoreName).GetInventory();
            
            if (storeProducts.ContainsKey(product) && storeProducts[product] >= amount)
            {
                if (Products.ContainsKey(product))
                    Products[product] += amount;
                else Products.Add(product, amount);
                return true;
            }
            return false;
        }

        public bool RemoveProduct(string product)
        {
            return Products.Remove(product);
        }
        
        public bool RemoveProduct(string product, int amount)
        {
            if (!Products.ContainsKey(product) || Products[product] < amount)
                return false;
            Products[product] -= amount;
            if (Products[product] == 0)
            {
                Products.Remove(product);
            }
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

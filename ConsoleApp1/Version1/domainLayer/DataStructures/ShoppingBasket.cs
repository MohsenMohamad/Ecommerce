using System.Collections.Generic;

namespace Version1.domainLayer.DataStructures
{
    public class ShoppingBasket
    {
        //todo mohsen
        public int id;
        internal string StoreName { get; }
        internal Dictionary<string, int> Products { get; }
        
        public ShoppingBasket(string storeName)
        {
            Products = new Dictionary<string, int>();
            StoreName = storeName;
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

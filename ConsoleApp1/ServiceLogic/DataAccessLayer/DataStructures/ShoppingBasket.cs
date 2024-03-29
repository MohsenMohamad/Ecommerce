﻿using System.Collections.Generic;

namespace ServiceLogic.DataAccessLayer.DataStructures
{
    public class ShoppingBasket
    {
        
        public long id { get; set; }
        public string StoreName { get; set; }

        public Dictionary<string, int> Products { get; set; }
        public Dictionary<string, double> priceperproduct { get; set; }

        public ShoppingBasket(string storeName)
        {
            priceperproduct = new Dictionary<string, double>();
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

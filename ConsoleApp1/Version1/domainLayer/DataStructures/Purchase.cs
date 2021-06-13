using System;
using System.Collections.Generic;

namespace Version1.domainLayer.DataStructures
{
    public class Purchase
    {
        public long purchaseId { get; set; }
        public string store { get; set; }
        public string user { get; set; }
        public List<KeyValuePair<Product, int>> items { get; set; }
        public PurchaseType purchaseType { get; set; }
        public DateTime date { get; set; }

        public Purchase()
        {
            items = new List<KeyValuePair<Product, int>>();
        }
        
        public override string ToString()
        {
            string output = DateTime.Now + "purchased:";
            for (int i = 0; i < items.Count; i++)
            {
                output += items[i].Key.name + " with the amount of " + items[i].Value;
            }

            return output;
        }


        public enum PurchaseType
        {
            DirectPurchase
        }
    }
}
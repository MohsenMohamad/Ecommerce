using System;
using System.Collections.Generic;

namespace Version1.domainLayer
{
    public class Purchase
    {
        private long purchaseId;
        private string store;
        private string user;
        public List<KeyValuePair<Product, int>> items { get; }
        private PurchaseType purchaseType;
        public DateTime date { get; set; }

        public Purchase()
        {
            items = new List<KeyValuePair<Product, int>>();
        }
        
        public override string ToString()
        {
            string output = DateTime.Now + "purchased:/n";
            for (int i = 0; i < items.Count; i++)
            {
                output += items[i].Key.Name + " with the amount of " + items[i].Value;
            }

            return output;
        }


        private enum PurchaseType
        {
            DirectPurchase
        }
    }
}
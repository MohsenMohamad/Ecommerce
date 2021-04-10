using System;
using System.Collections.Generic;

namespace ConsoleApp1.domainLayer.Business_Layer
{
    public class Purchase
    {
        public List<KeyValuePair<Product, int>> items { get; }
        public DateTime date { get; set; }

        public Purchase()
        {
            this.items = new List<KeyValuePair<Product, int>>();
            
        }
        public void addProduct(Product pr,int amount)
        {
            int flag = 0,tmp;
            for (int i = 0; i < items.Count&&flag==0; i++)
            {
                if (items[i].Key.Equals(pr))
                {
                    tmp = items[i].Value;
                    items.RemoveAt(i);
                    items.Add(new KeyValuePair<Product, int>(pr, tmp + amount));
                    flag = 1;
                }
            }
            if (flag == 0)
            {
                items.Add(new KeyValuePair<Product, int>(pr,  amount));
            }
        }

        internal void removeProduct(Product pr, int amount)
        {
            int  tmp;
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Key.Equals(pr))
                {
                    tmp = items[i].Value;
                    items.RemoveAt(i);
                    if(tmp-amount>=0)
                    items.Add(new KeyValuePair<Product, int>(pr, tmp - amount));
                    else items.Add(new KeyValuePair<Product, int>(pr, 0));


                }
            }
        }

        internal void removeProduct(Product pr)
        {
            
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Key.Equals(pr))
                {
                    items.RemoveAt(i);
                }
            }
        }
    }
}
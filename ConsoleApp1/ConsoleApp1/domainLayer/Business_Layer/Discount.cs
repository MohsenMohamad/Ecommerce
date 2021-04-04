using System.Collections.Generic;

namespace ConsoleApp1.domainLayer.Business_Layer
{
    internal class Discount
    {
        private List<KeyValuePair<Product, double>> items;
        
        public Discount()
        {
            items = new List<KeyValuePair<Product, double>>();
        }

        public void ModifyItem(Product pr, double dis)
        {
            KeyValuePair<Product, double> pair = new KeyValuePair<Product, double>(pr, dis);
            for (int i = 0; i <items.Count; i++)
            {
                if(items[i].Key.Equals(pr))
                {
                    items.RemoveAt(i);
                   
                   
                }
            }
            items.Add(pair);


        }
    }
}
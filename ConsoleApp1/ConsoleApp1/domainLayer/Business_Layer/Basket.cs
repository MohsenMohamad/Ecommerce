using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.domainLayer.Business_Layer
{
    class Basket
    {
        public string Storename { get; }
        public List<KeyValuePair<Product, int>> Products { get; }
        public Basket(string storename)
        {
            this.Products = new List<KeyValuePair<Product, int>>();
            this.Storename = storename;
        }
        public void addproduct(Product pr, int amount)
        {
            int tmp;
            for (int i = 0; i < Products.Count; i++)
            {
                if (Products[i].Key.Equals(pr))
                {
                    tmp = Products[i].Value;
                    Products.RemoveAt(i);
                    Products.Add(new KeyValuePair<Product, int>(pr, amount + tmp));
                    return;
                }
                     
            }
            Products.Add(new KeyValuePair<Product, int>(pr, amount));
        }

        public void Removeproduct(Product pr)
        {
            
            for (int i = 0; i < Products.Count; i++)
            {
                if (Products[i].Key.Equals(pr))
                {
                    
                    Products.RemoveAt(i);
                 
                    return;
                }

            }
        }
        public override string ToString()
        {
            string output= "basket for "+Storename;
            for (int i = 0; i < Products.Count; i++)
            {
                output += "\n"+Products[i].Key.Name+" with the amount of "+Products[i].Value;
            }
            return output;
        }
    }
}

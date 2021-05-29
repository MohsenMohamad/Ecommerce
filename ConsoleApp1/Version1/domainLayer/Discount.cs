using System.Collections.Generic;
using Version1.domainLayer.DataStructures;

namespace Version1.domainLayer
{
    public class Discount
    {
        //todo mohsen
        public int id;
        public KeyValuePair<Product, double> items { get; set; }
        
        public Discount(Product pr, double dis)
        {
            items =new  KeyValuePair<Product, double>(pr,dis);
        }

        

        public void ModifyItem(Product pr, double dis)
        {
            KeyValuePair<Product, double> pair = new KeyValuePair<Product, double>(pr, dis);
            this.items = pair;


        }
    }
}
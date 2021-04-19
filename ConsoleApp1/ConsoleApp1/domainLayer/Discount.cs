﻿using System.Collections.Generic;

namespace ConsoleApp1.domainLayer.Business_Layer
{
    public class Discount
    {
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
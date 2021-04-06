using System;
using System.Collections.Generic;

namespace ConsoleApp1.domainLayer.Business_Layer
{
    internal class Purchase
    {
        private List<KeyValuePair<Product, int>> items;
        private DateTime date;

        public Purchase(List<KeyValuePair<Product, int>> items)
        {
            this.items = items;
            date = DateTime.Now;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.domainLayer.Business_Layer
{
    public class ShoppingCart
    {
        public String username { get; }
        public List<Basket> baskets { get; }


        public ShoppingCart(String username)
        {
            this.username = username;
            baskets = new List<Basket>();
        }


        public bool AddBasket(Basket bs)
        {
            if(!baskets.Contains(bs))
            {
                baskets.Add(bs);
                return true;
            }
            return false;
        }
        public bool RemoveBasket(Basket bs)
        {
            if (baskets.Contains(bs))
            {
                baskets.Remove(bs);
                return true;
            }
            return false;
        }
    }
}

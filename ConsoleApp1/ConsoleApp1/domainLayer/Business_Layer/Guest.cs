using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.domainLayer.Business_Layer
{
    public class Guest :Person
    {
        private ShoppingCart cart;
        public Guest()
        {
            cart = new ShoppingCart("guest");
        }

        /*public Guest(ShoppingCart cart)
        {
            this.cart = cart;
        }*/

        public void setShoppingCart(ShoppingCart cart)
        {
            this.cart = cart;
        }



        public void AddItemToBasket(string store_name, Product pr, int amount)
        {
            for (int i = 0; i < cart.baskets.Count; i++)
            {
                if (cart.baskets[i].Storename.CompareTo(store_name) == 0)
                {
                    cart.baskets[i].addproduct(pr, amount);
                }
            }
        }

        public string GetBasketInfo()
        {
            string output = "--------------------------";
            for (int i = 0; i < cart.baskets.Count; i++)
            {
                
                    output+= cart.baskets[i].ToString()+"/n---------------------/n";
                
            }
            return output;
        }

        public void RemoveItemFromBasket(string store_name, Product pr)
        {
            for (int i = 0; i < cart.baskets.Count; i++)
            {
                if (cart.baskets[i].Storename.CompareTo(store_name) == 0)
                {
                    cart.baskets[i].Removeproduct(pr);
                }
            }
        }
    }
}

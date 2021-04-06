using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.domainLayer.Business_Layer
{
    class Guest :Person
    {
        private ShoppingCart cart;
        public Guest()
        {
            cart = new ShoppingCart("guest");
        }
        public void Register() {
            throw new NotImplementedException();
        }

        public void Login()
        {
            throw new NotImplementedException();
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

        public string GetBasketInfo(string store_name)
        {
            for (int i = 0; i < cart.baskets.Count; i++)
            {
                if (cart.baskets[i].Storename.CompareTo(store_name) == 0)
                {
                    return cart.baskets[i].ToString();
                }
            }
            return "didnt find a basket for this store";
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

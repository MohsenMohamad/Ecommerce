using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.domainLayer.Business_Layer
{
    public interface Person
    {
         

        void AddItemToBasket(string store_name, Product pr, int amount);
        string GetBasketInfo();
        void RemoveItemFromBasket(string store_name, Product pr);
       
    }
}

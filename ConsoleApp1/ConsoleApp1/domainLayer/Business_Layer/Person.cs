using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.domainLayer.Business_Layer
{
    interface Person
    {
         void Login();

        void AddItemToBasket(string store_name, Product pr, int amount);
        string GetBasketInfo(string store_name);
        void RemoveItemFromBasket(string store_name, Product pr);
       
    }
}

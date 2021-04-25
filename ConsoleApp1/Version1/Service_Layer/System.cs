using System;
using System.Collections.Generic;
using System.Configuration;
using Version1.DataAccessLayer;
using Version1.domainLayer;
using Version1.LogicLayer;
using Version1.Service_Layer;

namespace Version1.Service_Layer
{
    class Program
    {
        public static void Main(string[] args)
        {
            
            var facade = new Facade();
            
            Console.WriteLine(facade.Register("zzz", "123"));
            Console.WriteLine(facade.Login("zzz", "123"));
            
            Console.WriteLine(facade.OpenShop("zzz","store1","ss"));

            facade.AddNewProductToSystem("111", "product1", "descreption1", 2.5, new []{"cat1"});
            facade.AddItemToStore("store1", "111", 11);
            var stores = facade.GetStoresProducts();

            foreach (var store in stores)
            {
                foreach (var storeData in store)
                {
                    Console.WriteLine(storeData);
                }
                Console.WriteLine();
            }
        }
        
    }
}
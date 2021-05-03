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
            /*    
            facade.Register("zzz", "123");
           facade.Login("zzz", "123");

            facade.OpenShop("zzz","store1","ss");

            facade.AddNewProductToSystem("111", "product1", "descreption1", 2.5, new []{"cat1"});
            facade.AddItemToStore("store1", "111", 11);
            facade.AddProductToBasket("zzz", "store1", "111",12);
            var basket = facade.GetUserBaskets("zzz");
            Console.WriteLine("this is basket "+basket[0][6]);

            Console.ReadLine();


        var x = new Permissions();
        var result = x.GetPermissions2(27);
        foreach (var permission in result)
        {
            Console.WriteLine(permission);
        }

        Console.WriteLine(result.Count);*/

            facade.InitSystem();
            string [] a =facade.GetStoreManagers("AdnanStore");

            for (int i = 0; i < a.Length; i++) {
                Console.WriteLine(a[i]);
            }
            Console.WriteLine(a.Length);

            facade.Purchase("mohameda", "111");

            string[] ab = facade.GetStoreOwners("AdnanStore");

            for (int i = 0; i < ab.Length; i++)
            {
                Console.WriteLine(ab[i]);
            }
            Console.WriteLine(ab.Length);
            Console.ReadLine();

        }   


    }
}
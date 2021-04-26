using Microsoft.Owin.Hosting;
using Fleck;
using System;
using System.Threading;
using ServerApi.DataObserver;
using System.Collections.Generic;
using System.Linq;
using ServerApi;
using Version1.Service_Layer;

namespace ServiceApi
{
    class Program
    {

        /*use this website to test server :
        http://websocket.org/echo.html
        make sure that location is :
            ws://localhost:8088*/
        static void Main(string[] args)
        {
            Logger logger = Logger.GetInstance();
            try
            {
                throw new Exception("This is Logger");
            }
            catch (Exception e)
            {
                logger.Event(e.Message);  
                logger.Error(e.Message);    
            }
            
            var facade = new Facade();

            facade.Register("zzz", "123");
            facade.Login("zzz", "123");

            facade.OpenShop("zzz", "store1", "ss");
            facade.OpenShop("zzz", "store2", "ss");

            facade.AddNewProductToSystem("111", "product1", "descreption1", 2.5, new[] { "cat1" });
            facade.AddNewProductToSystem("333", "product2", "descreption1", 2.5, new[] { "cat1" });
            facade.AddNewProductToSystem("44", "product4", "descreption1", 2.5, new[] { "dog" });
            facade.AddItemToStore("store1", "111", 11);
            facade.AddItemToStore("store2", "333", 11);
            facade.AddItemToStore("store2", "44", 11);
          //  facade.AddProductToBasket("zzz", "store1", "111");

            string domainAddress = "https://localhost:44300/";
                using (WebApp.Start(url:domainAddress))
                {
                    Console.WriteLine("Service Hosted " + domainAddress);
                    System.Threading.Thread.Sleep(-1);
                }
        }
    }
}



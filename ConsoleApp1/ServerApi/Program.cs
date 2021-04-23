using Microsoft.Owin.Hosting;
using Fleck;
using System;
using System.Threading;
using ServerApi.DataObserver;
using System.Collections.Generic;
using System.Linq;
using ServerApi;

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
                string domainAddress = "https://localhost:44300/";
                using (WebApp.Start(url:domainAddress))
                {
                    Console.WriteLine("Service Hosted " + domainAddress);
                    System.Threading.Thread.Sleep(-1);
                }
        }
    }
}



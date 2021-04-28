using Microsoft.Owin.Hosting;
using Fleck;
using System;
using System.Threading;
using ServerApi.DataObserver;
using System.Collections.Generic;
using System.Linq;
using ServerApi;
using Version1.domainLayer.UserRoles;
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
            Thread thread1 = new Thread(delegate ()
            {
                try
                {
                    var facade = new Facade();
                    SystemAdmin sysadmin = new SystemAdmin();
                    sysadmin.InitSystem();
                    facade.InitSystem();
            
                    string domainAddress = "https://localhost:44300/";
                    using (WebApp.Start(url:domainAddress))
                    {
                        Console.WriteLine("Service Hosted " + domainAddress);
                        //infinite waiting period
                        System.Threading.Thread.Sleep(-1);
                    }
                   
                }
                catch (Exception xxx)
                {
                 Logger.GetInstance().Error("fatal error exeption in server program start exited infinite waiting period");   
                }
            });
            
            Thread thread2 = new Thread(delegate ()
            {
                try
                {
                    List<ObserverUser> observerUsers = new List<ObserverUser>();
                    var server = new WebSocketServer("ws://0.0.0.0:8181");
                    server.Start(socket =>
                    {
                        socket.OnOpen = () =>
                        {
                            if (socket.ConnectionInfo.Path.ToString().Contains("user"))
                            {
                                string userName = socket.ConnectionInfo.Path.ToString().Replace("/?user=", "");
                                
                                List<ObserverUser> res = observerUsers.Where(x => x.userName == userName).ToList();
                                foreach (var t in res)
                                {
                                    try
                                    {
                                        t.socket.Close();
                                    }
                                    catch
                                    {
                                        // ignored
                                    }
                                }
                                observerUsers.RemoveAll(x => x.userName == userName);
                                observerUsers.Add(new ObserverUser(userName, socket));
                                if (userName == "") socket.Close();
                                Console.WriteLine("Open socket for - " + userName);
                            }
                            else
                            {
                                Console.WriteLine("Open! - " + "server");
                            }
                        };
                        socket.OnClose = () =>
                        {
                            if (socket.ConnectionInfo.Path.ToString().Contains("user"))
                            {
                                string userName = socket.ConnectionInfo.Path.ToString().Replace("/?user=", "");
                                
                                observerUsers.RemoveAll(x => x.userName == userName);
                                Console.WriteLine("Close! - " + userName);
                            }
                            else
                            {
                                Console.WriteLine("Open! - " + "server");
                            }
                        };
                        socket.OnMessage = message =>
                        {
                            //userid#msg
                            string[] cmd = message.Split('#');
                            string userName = cmd[0];
                            List<ObserverUser> res = observerUsers.Where(x => x.userName == userName).ToList();
                            if (res.Count > 0) res[0].notify(cmd[1]);

                            Console.WriteLine(message + " " + res.Count);
                        };
                    });

                }
                catch (Exception ex)
                {
                    Logger.GetInstance().Error(ex.ToString());
                }
            });
            thread1.Start();
            thread2.Start();
            /*thread1.Join();
            thread2.Join();*/
            Console.ReadLine();
            /*Logger logger = Logger.GetInstance();
            try
            {
                throw new Exception("This is Logger");
            }
            catch (Exception e)
            {
                logger.Event(e.Message);  
                logger.Error(e.Message);    
            }*/
            
            
            /*facade.Register("zzz", "123");
            facade.Login("zzz", "123");

            facade.OpenShop("zzz", "store1", "ss");
            facade.OpenShop("zzz", "store2", "ss");

            facade.AddNewProductToSystem("111", "product1", "descreption1", 2.5, new[] { "cat1" });
            facade.AddNewProductToSystem("333", "product2", "descreption1", 2.5, new[] { "cat1" });
            facade.AddNewProductToSystem("44", "product4", "descreption1", 2.5, new[] { "dog" });
            facade.AddItemToStore("store1", "111", 11);
            facade.AddItemToStore("store2", "333", 11);
            facade.AddItemToStore("store2", "44", 11);*/
            //  facade.AddProductToBasket("zzz", "store1", "111");

            
        }
    }
}



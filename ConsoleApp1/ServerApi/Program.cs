﻿using Microsoft.Owin.Hosting;
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
                 Logger.GetInstance().Error("fatal error exception in server program start exited infinite waiting period");   
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
                                
                                var res = observerUsers.Where(x => x.userName == userName).ToList();
                                foreach (var t in res)
                                {
                                    try
                                    {
                                        //disconnect sockets for users that have been logged in in second
                                        //time to make sure the are no duplicated sockets fo each user
                                        t.socket.Close();
                                    }
                                    catch
                                    {
                                        // socket has been disconnected before we disconnect his socket
                                    }
                                }
                                observerUsers.RemoveAll(x => x.userName == userName);
                                observerUsers.Add(new ObserverUser(userName, socket));
                                if (userName == "") socket.Close();
                                Console.WriteLine("connected to socket userName : " + userName);
                            }
                            else
                            {
                                Console.WriteLine("Open " + "server");
                            }
                        };
                        socket.OnClose = () =>
                        {
                            if (socket.ConnectionInfo.Path.ToString().Contains("user"))
                            {
                                string userName = socket.ConnectionInfo.Path.ToString().Replace("/?user=", "");
                                //disconnect user when logging out from socket
                                observerUsers.RemoveAll(x => x.userName == userName);
                                Console.WriteLine("disConnected from socket userName : " + userName);
                            }
                            else
                            {
                                Console.WriteLine("Open " + "server");
                            }
                        };
                        socket.OnMessage = message =>
                        {
                            Logger.GetInstance().Event(message);
                            //userid # msg
                            string[] cmd = message.Split('#');
                            string userName = cmd[0];
                            
                            //get userNameList to notify
                            List<ObserverUser> res = observerUsers.Where(x => x.userName == userName).ToList();
                            
                            //send notification for the user that the message has been arrived ???
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
            thread1.Join();
            thread2.Join();
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
            

            
        }
    }
}



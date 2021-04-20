using Microsoft.Owin.Hosting;
using Fleck;
using System;
using System.Threading;
using ServerApi.DataObserver;
using System.Collections.Generic;
using System.Linq;

namespace ServiceApi
{
    class Program
    {
        private static WebSocketServer wsServer;


        static void Main(string[] args)
        {
            int port = 8088;
            var server = new WebSocketServer("ws://0.0.0.0:8088");
            Console.WriteLine("Server is running on port " + port + ". Press ENTER to exit....");
            
            List<ObserverUser> ls = new List<ObserverUser>();
            server.Start(socket =>
            {
                socket.OnOpen = () =>
                {
                    if (socket.ConnectionInfo.Path.ToString().Contains("user"))
                    {
                        string info = socket.ConnectionInfo.Path.ToString().Replace("/?user=", "");
                        int id = int.Parse(info);
                        List<ObserverUser> res = ls.Where(x => x.user_id == id).ToList();
                        for (int i = 0; i < res.Count; i++)
                        {
                            try
                            {
                                res[i].socket.Close();
                            }
                            catch { }
                        }
                        ls.RemoveAll(x => x.user_id == id);
                        ls.Add(new ObserverUser(id, socket));
                        if (id == -1) socket.Close();
                        Console.WriteLine("Open! - " + id);
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
                        string info = socket.ConnectionInfo.Path.ToString().Replace("/?user=", "");
                        int id = int.Parse(info);
                        ls.RemoveAll(x => x.user_id == id);
                        Console.WriteLine("Close! - " + id);
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
                    int id = int.Parse(cmd[0]);
                    List<ObserverUser> res = ls.Where(x => x.user_id == id).ToList();
                    if (res.Count > 0) res[0].notify(cmd[1]);

                    Console.WriteLine(message + " " + res.Count);
                };
            });
            Console.ReadKey();

        }


    }
}



using SuperWebSocket;
using System;
using System.Threading;

namespace ServiceApi
{
    class Program
    {
        private static WebSocketServer wsServer;
        static void Run()
        {
            Thread th1 = new Thread(delegate ()
            {
                try
                {

                    string domainAddress = "https://localhost:8088/";
                    using (WebApp.Start(url: domainAddress))
                    {
                        Console.WriteLine("Service Hosted " + domainAddress);
                        System.Threading.Thread.Sleep(-1);
                    }
                }
                catch (Exception xxx)
                {
                    ServiceLayer.Log.Error(xxx.Message.ToString());
                    Console.WriteLine(xxx.Message.ToString());
                    Environment.Exit(-1);
                }

            });

        }

            static void Main(string[] args)
        {
            /* wsServer = new WebSocketServer();
             int port = 8088;
             wsServer.Setup(port);
             wsServer.NewSessionConnected += WsServer_NewSessionConnected;
             wsServer.NewMessageReceived += WsServer_NewMessageReceived;
             wsServer.NewDataReceived += WsServer_NewDataReceived;
             wsServer.SessionClosed += WsServer_SessionClosed;
             wsServer.Start();
             Console.WriteLine("Server is running on port " + port + ". Press ENTER to exit....");
             Console.ReadKey();*/
            try
            {
                Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        private static void WsServer_SessionClosed(WebSocketSession session, SuperSocket.SocketBase.CloseReason value)
        {
            Console.WriteLine("SessionClosed");
        }

        private static void WsServer_NewDataReceived(WebSocketSession session, byte[] value)
        {
            Console.WriteLine("NewDataReceived");
        }

        private static void WsServer_NewMessageReceived(WebSocketSession session, string value)
        {
            Console.WriteLine("NewMessageReceived: " + value);
            if (value == "Hello server")
            {
                session.Send("Hello client");
            }
        }

        private static void WsServer_NewSessionConnected(WebSocketSession session)
        {
            Console.WriteLine("NewSessionConnected");
        }
    }
}
  

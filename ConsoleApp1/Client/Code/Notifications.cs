using WebSocketSharp;
namespace Client.Code
{
    public class Notifications
    {
        private static string url = "ws://localhost:8181";

        public Notifications() { }

        public static void SendMessage(string userName, string msg)
        {
            using (var ws = new WebSocket(url))
            {
                ws.Connect();
                //send message from client to server from webSocketConnection
                ws.Send(userName+"#"+msg);
                //close connection
                ws.Close();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fleck;

namespace ServerApi.DataObserver
{
    class ObserverUser
    {
        public IWebSocketConnection socket;
        public string userName;
        public ObserverUser(string userName, IWebSocketConnection socket)
        {
            this.userName = userName;
            this.socket = socket;
        }
        public void SetSocket(IWebSocketConnection socket)
        {
            this.socket = socket;
        }
        public bool notify(string msg)
        {
            if (socket.IsAvailable)
            {
                socket.Send(msg);
            }

            return true;
        }
    }
}

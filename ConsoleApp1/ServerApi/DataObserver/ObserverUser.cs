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
        public int user_id;
        public ObserverUser(int user_id, IWebSocketConnection socket)
        {
            this.user_id = user_id;
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

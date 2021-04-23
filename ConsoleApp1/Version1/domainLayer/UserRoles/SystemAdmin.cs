using Version1.DataAccessLayer;

namespace Version1.domainLayer.UserRoles
{
    public class SystemAdmin
    {
        private readonly DataHandler data;

        public SystemAdmin()
        {
            data = DataHandler.Instance;
        }

        public bool CloseStore(string storeName)
        {
            return data.RemoveStore(storeName);
        }

        public bool RemoveUser(string username)
        {
            return data.RemoveUser(username);
        }

        public string GetHistoryOfStore(string storeName)
        {
            var store = data.GetStore(storeName);
            if (store == null)
                return "no store was found";
            return store.history.ToString();
        }

        public string GetHistoryOfUser(string username)
        {
            var user = data.GetUser(username);
            if (user == null)
                return "no user was found";
            return user.GetPersonalPurchaseHistory();
        }

        public static void RecieveComplainToStore(string msg, string storeName)
        {
            var store = DataHandler.Instance.GetStore(storeName);
            if (store != null)
                store.ReceiveMsg(msg);
        }

        public static void RecieveComplainToUser(string msg, string userName)
        {
            var user = DataHandler.Instance.GetUser(userName);
            if (user != null)
                user.ReceiveMsg(msg);
        }

        internal Store GetStore(string storeName)
        {
            return data.GetStore(storeName);
        }
    }
}
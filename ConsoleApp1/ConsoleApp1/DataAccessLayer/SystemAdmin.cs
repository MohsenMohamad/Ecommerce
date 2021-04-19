using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.domainLayer.DataAccessLayer
{
    public class SystemAdmin
    {
        private DataHandler data;

        public SystemAdmin()
        {
            data = DataHandler.Instance;
        }

        public bool closeStore(string store_name)
        {
            for (int i = 0; i < data.Stores.Count; i++)
            {
                if (data.Stores[i].Name.CompareTo(store_name) == 0)
                {
                    data.Stores.RemoveAt(i);
                    return true;

                }
            }
            return false;
            
        }

        public bool removeUser(string username)
        {
            for (int i = 0; i < data.Users.Count; i++)
            {
                if (((Business_Layer.User)data.Users[i]).UserName.CompareTo(username) == 0)
                {
                    data.Users.RemoveAt(i);
                    return true;

                }
            }
            return false;

        }

        public string GetHistoryOfStore(string store_name)
        {
            for (int i = 0; i < data.Stores.Count; i++)
            {
                if (data.Stores[i].Name.CompareTo(store_name) == 0)
                {
                    return data.Stores[i].history.ToString();

                }
            }
            return "no store was found";
            
        }
        public string GetHistoryOfUser(string username)
        {
            for (int i = 0; i < data.Users.Count; i++)
            {
                if (((Business_Layer.User)data.Users[i]).UserName.CompareTo(username) == 0)
                {
                    return ((Business_Layer.User)data.Users[i]).GetPersonalPurchaseHistory();

        }
            }
            return "no user was found";

        }

        public static void RecieveComplainToStore(string msg,string storename)
        {
            for (int i = 0; i < DataHandler.Instance.Stores.Count; i++)
            {
                if (DataHandler.Instance.Stores[i].Name.CompareTo(storename) == 0)
                    DataHandler.Instance.Stores[i].ReceiveMsg(msg);
            }
        }

        public static void RecieveComplainToUser(string msg, string username)
        {
            for (int i = 0; i < DataHandler.Instance.Users.Count; i++)
            {
                if (((Business_Layer.User)DataHandler.Instance.Users[i]).UserName.CompareTo(username) == 0)
                    ((Business_Layer.User)DataHandler.Instance.Users[i]).ReceiveMsg(msg);
            }
        }

        internal Business_Layer.Store GetStore(string storename)
        {
            for (int i = 0; i < data.Stores.Count; i++)
            {
                if (data.Stores[i].Name.CompareTo(storename) == 0)
                    return data.Stores[i];
            }
            return null;
        }

    }
}

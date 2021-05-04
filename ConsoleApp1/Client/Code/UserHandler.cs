using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Linq;
using System.Web;

namespace Client.Code
{
    public class UserHandler
    {

        public  UserHandler(){}

        public bool Register(string username, string password)
        {
            try
            {
                string param = string.Format("username={0}&password={1}", username, password);
                return bool.Parse(System.SendApi("Register", param));
            }
            catch (Exception ex)
            {
                Console.WriteLine("illegal user or this user is already registered");
                return false;
            }
            /*string param = string.Format("username={0}&password={1}", username, password);
            string res = System.SendApi(System.Service_type.USER, "Register", param);
            if( res != null)
            {
                return int.Parse(res);
            }
            //failure case
            return -1;*/
        }
        public bool Login(string username, string password)
        {
            try
            {
                string param = string.Format("username={0}&password={1}", username, password);
                return bool.Parse(System.SendApi("Login", param));
            }
            catch (Exception ex)
            {
                Console.WriteLine("bad username or pass");
                return false;
            }
        }


        public long GuestLogin()
        {
            string param = "";
            return long.Parse(System.SendApi("GuestLogin", param));
        }
        public bool Logout(string userName)
        {
            string param = string.Format("username={0}", userName);
            return bool.Parse(System.SendApi("Logout", param));
        }
        public bool AddNewOwner(string mangerName, string storename, string newOwner)
        {
            string param = string.Format("mangerName={0}&storename={1}&newOwner={2}", mangerName, storename, newOwner);
            return bool.Parse(System.SendApi("AddNewOwner", param));
        }
        public bool MakeNewManger(string storeName, string apointerid, string apointeeid, int permissions)
        {
            string param = string.Format("storeName={0}&apointerid={1}&apointeeid={2}&permissions={3}", storeName, apointerid, apointeeid, permissions);
            return bool.Parse(System.SendApi("MakeNewManger", param));
        }

        public bool MakeNewOwner(string storeName, string apointerid, string apointeeid, int permissions)
        {
            string param = string.Format("storeName={0}&apointerid={1}&apointeeid={2}&permissions={3}", storeName, apointerid, apointeeid, permissions);
            return bool.Parse(System.SendApi("MakeNewOwner", param));
        }

        public bool removeOwner(string apointerid, string storeName, string apointeeid)
        {
            string param = string.Format("apointerid={0}&storeName={1}&apointeeid={2}", apointerid,  storeName,  apointeeid);
            return bool.Parse(System.SendApi("removeOwner", param));

        }
        public bool removeManager(string apointerid, string storeName, string apointeeid)
        {
            string param = string.Format("apointerid={0}&storeName={1}&apointeeid={2}", apointerid, storeName, apointeeid);
            return bool.Parse(System.SendApi("removeManager", param));

        }

        public DataSet GetAllNotifications(string userName)
        {
            string param = string.Format("userName={0}", userName);
            JArray arr = (JArray)JsonConvert.DeserializeObject(System.SendApi("GetAllNotifications", param).ToString());
            DataTable t1 = new DataTable("Notifications");
            t1.Columns.Add("id");
            t1.Columns.Add("msg");
            if (arr != null)
            {
                for (int i = 0; i < arr.Count && arr[i] != null; i++)
                {
                    try
                    {
                        t1.Rows.Add(i, arr[i]);
                    }
                    catch
                    { }
                }
            }
            DataSet set = new DataSet("Notification");
            set.Tables.Add(t1);
            return set;
        }
    }
}
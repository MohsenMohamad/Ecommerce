using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Code
{
    public class UserHandler
    {

        public  UserHandler(){}

        public int Register(string username, string password)
        {
            string param = string.Format("username={0}&password={1}", username, password);
            return int.Parse(System.SendApi(System.Service_type.USER, "Register", param));
        }
        public int Login(string username, string password)
        {
            string param = string.Format("username={0}&password={1}", username, password);
            return int.Parse(System.SendApi(System.Service_type.USER, "Login", param));
        }
        public int Logout(int userid)
        {
            string param = string.Format("userid={0}", userid);
            return int.Parse(System.SendApi(System.Service_type.USER, "Logout", param));
        }
        public int AddNewOwner(string mangerName, string storename, string newOwner)
        {
            string param = string.Format("mangerName={0}&storename={1}&newOwner={2}", mangerName, storename, newOwner);
            return int.Parse(System.SendApi(System.Service_type.USER, "AddNewOwner", param));
        }
        public int AddNewManger(string userName, string storeName, string NewOwnerName, string permissions)
        {
            string param = string.Format("userName={0}&storeName={1}&NewOwnerName={2}&permissions={3}", userName, storeName, permissions);
            return int.Parse(System.SendApi(System.Service_type.USER, "AddNewManger", param));
        }
    }
}
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
        public int login(string username, string password)
        {
            string param = string.Format("username={0}&password={1}", username, password);
            return int.Parse(System.SendApi(System.Service_type.USER, "login", param));
        }
    }
}
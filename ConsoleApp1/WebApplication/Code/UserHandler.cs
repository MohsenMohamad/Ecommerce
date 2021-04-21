using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Code
{
    public class UserHandler
    {
    }

    public int Register(string username, string password)
    {
        string param = string.Format("username={0}&password={1}", username, password);
        return int.Parse(SysTools.SendApi(SysTools.Service_type.USER, "Register", param));
    }

}
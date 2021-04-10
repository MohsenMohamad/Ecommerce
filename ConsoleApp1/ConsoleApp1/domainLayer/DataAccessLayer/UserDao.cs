using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.domainLayer.DataAccessLayer
{
    class UserDao
    {
        public string UserName { get; }
        public string Password { get; }

        public UserDao(string username, string password)
        {
            this.UserName = username;
            this.Password = password;
        }

 
    }
}

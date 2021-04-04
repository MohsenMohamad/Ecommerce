using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.domainLayer.DataAccessLayer
{
    class User
    {
        private string username,password;

        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public string UserName { get => this.username; set => this.username = value; }
        public string Password { get => this.password; set => this.password = value; }
    }
}

using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ServerApi
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserServiceController : ApiController
    {
        RealProject real = new RealProject();
        
        [HttpGet]
        public int Register(string username, string password)
        {
            return real.Register(username, password)  == true ? 1 : 0;
        }

        [HttpGet]
        public int Login(string username, string password)
        {
            return real.loginUser(username, password) == true ? 1 : 0;
        }
        [HttpGet]
        public int Logout(string username, string password)
        {
            return real.loginUser(username, password) == true ? 1 : 0;
        }
        [HttpGet]
        public int AddNewOwner(string mangerName, string storename, string newOwner)
        {
            return real.AddNewOwner(mangerName, storename, newOwner) == true ? 1 : 0;
        }


    }
}

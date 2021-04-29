
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Version1;
using Version1.Service_Layer;

namespace ServerApi
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserServiceController : ApiController
    {
        private Facade facade = new Facade();
        
        [HttpGet]
        public bool Register(string username, string password)
        {
            return facade.Register(username, password);
        }

        [HttpGet]
        public bool Login(string username, string password)
        {
            return facade.Login(username, password) ;
        }
        [HttpGet]
        public bool Logout(string username)
        {
            return facade.Logout(username);
        }
        [HttpGet]
        public string[] GetAllNotifications(string userName)
        {
            return facade.GetAllUserNotifications(userName);
        }

        [HttpGet]
        public long GuestLogin()
        {
            return facade.GuestLogin();
        }

    } 
}

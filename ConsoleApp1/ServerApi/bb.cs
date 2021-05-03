
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
    public class bb : ApiController
    {
        private Facade facade = new Facade();
        
        [HttpGet]
        public bool Register(string username, string password)
        {
            
                bool output = facade.Register(username, password);
                if (output)
                {
                    Logger.GetInstance().Event(username + "has Register succesfully ");
                }
                return output;
        }

        [HttpGet]
        public bool Login(string username, string password)
        {
            bool output = facade.Login(username, password) ;
            if (output)
            {
                Logger.GetInstance().Event(username + "has LoggedIn ");
            }
            return output;
        }
        [HttpGet]
        public bool Logout(string username)
        {
            bool output =facade.Logout(username);
            if (output)
            {
                Logger.GetInstance().Event(username + "has LoggedOut ");
            }
            return output;
        }
        [HttpGet]
        public string[] GetAllNotifications(string userName)
        {
            return facade.GetAllUserNotifications(userName);
        }

        [HttpGet]
        public long GuestLogin()
        {
            long output = facade.GuestLogin();
            Logger.GetInstance().Event( "Guest has connected with pid : " + output);
            return output;
        }

    } 
}

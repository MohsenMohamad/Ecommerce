
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Version1;
using Version1.presentationLayer;

namespace ServerApi
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserServiceController : ApiController
    {
        private Facade facade = new Facade();
        
        [HttpGet]
        public bool Register(string username, string password)
        {
            return facade.testbool() ;
            //return facade.Register(username, password) == true ? 1 : 0;
        }

        [HttpGet]
        public bool Login(string username, string password)
        {
            return facade.testbool();
            //return real.UserLogin(username, password) == true ? 1 : 2;
            
        }
        [HttpGet]
        public bool Logout(string username)
        {
            return facade.testbool() ;
            //return facade.Logout(username);
        }
        
        
        
        


    } 
}

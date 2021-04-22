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
        [HttpGet]
        public int Register(string username, string password)
        {
            return 2;
        }
    }
}

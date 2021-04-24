
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
        public string[][] getAllProducts()
        {
            //price
            string[] p1 = { "productName", "descerption", "barcode", "price", "catagory1#catagory2#catogory3#" };
            string[] p2 = { "shampoo", "fine", "55262623", "15", "hair#hands#" };
            string[] p3 = { "fairy", "good", "1595959", "15", "dish#" };
            string[] p4 = { "lab", "high", "1626256", "15", "" };
            string[][] productsDummy = { p1, p2, p3, p4 };
            return productsDummy;
            //return facade.getAllProducts();
        }

        [HttpGet]
        public int Register(string username, string password)
        {
            return facade.testbool() == true ? 1 : 0;
            //return facade.Register(username, password) == true ? 1 : 0;
        }

        [HttpGet]
        public int Login(string username, string password)
        {
            return facade.testbool() == true ? 1 : 0;
            //return real.UserLogin(username, password) == true ? 1 : 2;
            
        }
        [HttpGet]
        public int Logout(string username, string password)
        {
            return facade.testbool() == true ? 1 : 0;
            //return real.UserLogin(username, password) == true ? 1 : 0;
        }
        [HttpGet]
        public int AddNewOwner(string mangerName, string storename, string newOwner)
        {
            return facade.testbool() == true ? 1 : 0;
            //return real.AddNewOwner(mangerName, storename, newOwner) == true ? 1 : 0;
        }
        [HttpGet]
        public int AddNewManager(string userName, string storeName, string NewOwnerName, string permissions)
        {   return facade.testbool() == true ? 1 : 0;
            /*//todo split the permissions and make dataStructures that saves the permissions
              return real.AddNewManger(userName, storeName, NewOwnerName) == true ? 1 : 0;*/
        }


    } 
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.domainLayer.DataAccessLayer
{
    class ReviewDao
    {
        public string Username { get; }
        public string Reviews { get; set; }
        public ReviewDao(string user,string desc)
        {
            this.Username = user;
            this.Reviews = desc;
        }

    }
}

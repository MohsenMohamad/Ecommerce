using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.domainLayer.DataAccessLayer
{
    class StoreDao
    {
        private string name;
        public StoreDao(string name)
        {
            this.name = name;

        }
        public string Name { get; set; }


    }
}

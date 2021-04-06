using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.domainLayer.DataAccessLayer
{
    class Store
    {
        private string name;
        public Store(string name)
        {
            this.name = name;

        }
        public string Name { get; set; }


    }
}

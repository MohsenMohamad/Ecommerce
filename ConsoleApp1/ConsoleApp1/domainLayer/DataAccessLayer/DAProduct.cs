using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.domainLayer.DataAccessLayer
{
    class DAProduct
    {
        public int Barcode { get; }
        public string Name { get ; }
        public string Description { get ; }

        public DAProduct(string name, string desc, int barcode)
        {
            this.Description = desc;
            this.Barcode = barcode;
            this.Name = name;
           
        }
    }
}

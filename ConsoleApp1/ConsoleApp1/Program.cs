using ConsoleApp1.domainLayer.Business_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            database ModelDB1 = new database();
            Console.WriteLine("aaaa");
            Product pr = new Product("11", "aa", 12, new List<Category>());
            ModelDB1.Insertproduct(pr);
        }
        
    }
}

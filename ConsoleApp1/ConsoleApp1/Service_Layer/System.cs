using ConsoleApp1.domainLayer.Business_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.domainLayer.DataAccessLayer;

namespace ConsoleApp1
{
    public class Program
    {   UserSystemHandler usersysHan = new UserSystemHandler("mail","pass");

        static void Main(string[] args)
        {
            Console.WriteLine("aaaa");
            Console.ReadLine();
        }
        
        /*public Program()
        {
            UserSystemHandler userSystemHandler = new UserSystemHandler();
        }

        
        
        bool login(string str)
        {
            return false;
        }*/
        
        
        
    }
}

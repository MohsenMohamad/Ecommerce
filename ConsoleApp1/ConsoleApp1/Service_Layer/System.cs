using ConsoleApp1.domainLayer.Business_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using ConsoleApp1.domainLayer.DataAccessLayer;

namespace ConsoleApp1
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("1.login as guest");
            Console.WriteLine("1.login with username and password");
            int choice = int.Parse(Console.ReadLine());
            if(choice==1)
            RunGuest( new Guest());
            else
            {
                if (!login())
                {
                    Console.WriteLine("cant log in. loggin in as guest");
                    RunGuest(new Guest());
                }
            }



        }
        
        private static void GuestrmainMenu()
        {
            Console.WriteLine("currently logged in as guest, choose an action:");
            Console.WriteLine("1. register");
            Console.WriteLine("2. log in");
            Console.WriteLine("3. get stores info");
            Console.WriteLine("4. get products info");
            Console.WriteLine("5. search product");
            Console.WriteLine("6. view shopping cart");
            Console.WriteLine("7. buy product");
            Console.WriteLine("8. remove product");
            Console.WriteLine("9. exit");

        }
        public static void RunGuest(Guest guest)
        {
            
            GuestrmainMenu();
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                string username, password;
                Console.WriteLine("please enter a user name");
                username = Console.ReadLine();
                while (DataHandler.Instance.exist(username))
                {
                    Console.WriteLine("a user with the given name already exists. enter a new user name");
                    username = Console.ReadLine();
                }
                Console.WriteLine("please enter a password");
                password = Console.ReadLine();
                DataHandler.Instance.register(username, password);
                Console.WriteLine("resistered successfully");
                RunGuest(guest);

            }
            else if(choice==2)
            {
                if (!login())
                    RunGuest(guest);
                    
            }
            else if (choice == 3)
            {
                Console.WriteLine(DataHandler.Instance.GetStoresInfo());
                RunGuest(guest);

            }
            else if (choice == 4)
            {
                Console.WriteLine(DataHandler.Instance.GetProductsInfo());
                RunGuest(guest);


            }
            else if (choice == 5)
            {
                runsearch();
                RunGuest(guest);

            }
            else if (choice == 6)
            {
                guest.GetBasketInfo();
            }
            else if (choice == 7)
            {
                Console.WriteLine("enter product barcode");
                string barcode = Console.ReadLine();
                Console.WriteLine("enter store name to buy from");
                string store= Console.ReadLine();
                Console.WriteLine("enter amount of product");
                int amount = int.Parse(Console.ReadLine());
                guest.AddItemToBasket(store, DataHandler.Instance.GetProduct(barcode), amount);
                RunGuest(guest);
            }
            else if (choice == 8)
            {
                Console.WriteLine("enter product barcode");
                string barcode = Console.ReadLine();
                Console.WriteLine("enter store name to buy from");
                string store = Console.ReadLine();
                
                guest.RemoveItemFromBasket(store, DataHandler.Instance.GetProduct(barcode));
                RunGuest(guest);
            }
            else if (choice == 9)
            {
                return;
            }
            else
            {
                Console.WriteLine("enter a valid number");
                RunGuest(guest);
            }
        }

        private static void runsearch()
        {
            Console.WriteLine("please choose search type:");
            Console.WriteLine("1. search by name");
            Console.WriteLine("2. search by category");
            Console.WriteLine("3. search by key word");
            int tmp = int.Parse(Console.ReadLine());
            if (tmp == 1)
            {
                Console.WriteLine("enter product name");
                string input = Console.ReadLine();
                DAProduct pr = DataHandler.Instance.GetproductByName(input);
                if (pr != null)
                    Console.WriteLine("product name:" + pr.Name + " , product barcode:" + pr.Barcode + " , product description:" + pr.Description);
                else Console.WriteLine("didnt find product");
            }
            else if (tmp == 2)
            {
                Console.WriteLine("enter product category");
                string input = Console.ReadLine();
                List<DAProduct> lst = DataHandler.Instance.SearchProductByCategory(input);
                for (int i = 0; i < lst.Count; i++)
                {
                    DAProduct pr = lst[i];
                    Console.WriteLine("product name:" + pr.Name + " , product barcode:" + pr.Barcode + " , product description:" + pr.Description);
                    Console.WriteLine("-------------------------------");
                }
            }
            else if (tmp == 3)
            {
                Console.WriteLine("enter key word");
                string input = Console.ReadLine();
                List<DAProduct> lst = DataHandler.Instance.SearchProductByKeyWord(input);
                for (int i = 0; i < lst.Count; i++)
                {
                    DAProduct pr = lst[i];
                    Console.WriteLine("product name:" + pr.Name + " , product barcode:" + pr.Barcode + " , product description:" + pr.Description);
                    Console.WriteLine("-------------------------------");
                }
            }
            else
            {
                Console.WriteLine("enter a valid search type");
            }
        }
        private static bool login()
        {
            string username, password;
            Console.WriteLine("please enter a user name");
            username = Console.ReadLine();
            if (!DataHandler.Instance.exist(username))
            {
                Console.WriteLine("a user with the given name does not exist.");

            }
            else
            {
                Console.WriteLine("please enter a password");
                password = Console.ReadLine();
                if (DataHandler.Instance.login(username, password))
                {
                    UserSystemHandler us = new UserSystemHandler(username, password);
                    RunUser(us);
                    return true;
                }

            }
            return false;
        }
        private static void RunUser(UserSystemHandler us)
        {
            Console.WriteLine("logged in as "+us.logged_in_user.UserName);
            usermenu();
            int choice =int.Parse( Console.ReadLine());
            if (choice == 1)
            {
                Console.WriteLine(DataHandler.Instance.GetStoresInfo());
                RunUser(us);
            }
            else if (choice == 2)
            {
                Console.WriteLine(DataHandler.Instance.GetProductsInfo());
                RunUser(us);
            }
            else if (choice == 3)
            {
                runsearch();
                RunUser(us);
            }
            else if (choice == 4)
            {
                Console.WriteLine(us.getbasketinfo());
                RunUser(us);
            }
            else if (choice == 5)
            {
                Console.WriteLine("enter product barcode");
                string barcode = Console.ReadLine();
                Console.WriteLine("enter store name to buy from");
                string store = Console.ReadLine();
                Console.WriteLine("enter amount of product");
                int amount = int.Parse(Console.ReadLine());
                us.buyProduct(barcode, store, amount);
                RunUser(us);
            }
            else if (choice == 6)
            {
                Console.WriteLine("enter product barcode");
                string barcode = Console.ReadLine();
                Console.WriteLine("enter store name to buy from");
                string store = Console.ReadLine();
              
                us.removeItemfromBasket(store, barcode);
                RunUser(us);
            }
            else if (choice == 7)
            {
                Console.WriteLine("enter store name");
                string name = Console.ReadLine();
                Console.WriteLine("enter store selling policy or description");
                string policy = Console.ReadLine();
                us.openStore(name, policy);
                RunUser(us);
            }
            else if (choice == 8)
            {
                runManageStore(us);
            }
            else if (choice == 9)
            {
                RunGuest(new Guest());
            }
            else if (choice == 10)
            {
                return;
            }
            else
            {
                Console.WriteLine("enter a valid option");
                RunUser(us);
            }



        }

        private static void runManageStore(UserSystemHandler us)
        {
            Console.WriteLine("please choose name of store from list below :(list of stores that the user is a manager or owner of)");
            Console.WriteLine(DataHandler.Instance.GetStoresInfo(us.logged_in_user.UserName));
            string store_name = Console.ReadLine();
            Store store = DataHandler.Instance.GetBUSStore(store_name);

        }

        private static void usermenu()
        {
            Console.WriteLine("1. get stores info");
            Console.WriteLine("2. get products info");
            Console.WriteLine("3. search product");
            Console.WriteLine("4. view shopping cart");
            Console.WriteLine("5. buy product");
            Console.WriteLine("6. remove product");
            Console.WriteLine("7. open store");
            Console.WriteLine("8. manage store");
            Console.WriteLine("9. logout");
            Console.WriteLine("10. exit");

        }
    }
}

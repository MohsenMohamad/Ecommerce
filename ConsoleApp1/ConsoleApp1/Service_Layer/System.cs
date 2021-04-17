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
            Console.WriteLine("2.login with username and password");
            int choice = int.Parse(Console.ReadLine());
            if(choice==1)
            RunGuest( new Guest());
            else if(choice==2)
            {
                if (!login())
                {
                    Console.WriteLine("cant log in. loggin in as guest");
                    RunGuest(new Guest());
                }
            }
            else
            {
                Console.WriteLine("enter valid option");
            }
            Main(args);



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
                us.checkout();
                  
                
            }
            else if (choice == 10)
            {
                us.showhistory();


            }
            else if (choice == 11)
            {
                RunGuest(new Guest());
            }
            else if (choice == 12)
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
            StoreAdministration st = new StoreAdministration(store_name);
            Console.WriteLine("currently managing "+store.Name+" store");
            Console.WriteLine("choose an action:" +
                "1. add product to inventory" +
                "2. add a discount" +
                "3. remove discount" +
                "4. add a manager to the store (can be done only if the user is one of the store owners)" +
                "5. fire a manager (can be done only if the user is one of the store owners)" +
                "6. add co-owner" +
                "7. remove co-owner (can be done only by the original owner)" +
                "8. check if product is found in the inventory" +
                "9. exit");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                Console.WriteLine("enter product barcode");
                string barcode = Console.ReadLine();
                Console.WriteLine("enter amount to add");
                int amount = int.Parse(Console.ReadLine());
                if(!st.Add_inventory(barcode, amount))
                    Console.WriteLine("failed to add");
                runManageStore(us);
            }
            else if (choice == 2)
            {
                Discount ds = creatediscount();
                store.AddDiscount(ds);
                runManageStore(us);
            }
            else if (choice == 3)
            {
                Console.WriteLine("enter product barcode to remove the discount for");
                string barcode = Console.ReadLine();
                if(!st.RemoveDiscount(barcode))
                    Console.WriteLine("didnt find a discount for this product in the current store");
                runManageStore(us);
            }
            else if (choice == 4)
            {
                if(!isowner(store,us.logged_in_user.UserName))
                    Console.WriteLine("cant hire a manager if you are not an owner");
                else
                {
                    Console.WriteLine("enter username for the new manager");
                    string username = Console.ReadLine();
                    if (ismanager(store, username) || isowner(store, username))
                    {
                        Console.WriteLine("the user is already a manager or an owner");
                    }
                    else
                    {
                        
                        if(!st.addManager(username))
                        Console.WriteLine("failed");

                    }
                }
                runManageStore(us);
            }
            else if (choice == 5)
            {
                if (!isowner(store, us.logged_in_user.UserName))
                    Console.WriteLine("cant fire a manager if you are not an owner");
                else
                {
                    Console.WriteLine("enter username of the  manager");
                    string username = Console.ReadLine();
                    if (ismanager(store, username)  &&!isowner(store, username))
                    {
                        if (!st.RemoveManager(username))
                            Console.WriteLine("failed");
                    }
                    else
                    {
                        Console.WriteLine("the user is an owner or isnt a manager");
                        

                    }
                }
                runManageStore(us);
            }
            else if (choice == 6)
            {

                if (!isowner(store, us.logged_in_user.UserName))
                    Console.WriteLine("cant hire a co owner if you are not an owner");
                else
                {
                    Console.WriteLine("enter username for the new co owner");
                    string username = Console.ReadLine();
                    if ( isowner(store, username))
                    {
                        Console.WriteLine("the user is already  an owner of the store");
                    }
                    else
                    {
                        if (ismanager(store, username))
                            st.RemoveManager(username);
                        if (!st.addOwner(username))
                            Console.WriteLine("failed");

                    }
                }
                runManageStore(us);
            }
            else if (choice == 7)
            {
                if (!(store.Owner.UserName.CompareTo(us.logged_in_user.UserName)==0))
                    Console.WriteLine("cant fire a co owner if you are not teh original owner");
                else
                {
                    Console.WriteLine("enter username for the  co owner");
                    string username = Console.ReadLine();
                    if (isowner(store, username))
                    {
                        if (ismanager(store, username))
                            st.RemoveManager(username);
                        if (!st.removeOwner(username))
                            Console.WriteLine("failed");
                    }
                    else
                    {
                        Console.WriteLine("the user is already  an owner of the store");


                    }
                }
                runManageStore(us);
            }
            else if (choice == 8)
            {
                Console.WriteLine("enter product barcode");
                string barcode = Console.ReadLine();
                if (st.check_inventory(barcode))
                {
                    Console.WriteLine("found "+DataHandler.Instance.GetProduct(barcode).Name+" with the amount of"+st.getInventory(barcode));
                }
                else
                {
                    Console.WriteLine("didnt find product in the inventory of this store");
                }
                runManageStore(us);
            }
            else if (choice == 9)
            {
                return;
            }
            else
            {
                Console.WriteLine("enter a valid option");
                runManageStore(us);
            }
        }

        private static Discount creatediscount()
        {
            Console.WriteLine("enter the product barcode");
            string barcode = Console.ReadLine();
            Console.WriteLine("enter the discount percantage (number between 0 and 1)");
            double dis = double.Parse(Console.ReadLine());
            Discount discount = new Discount(DataHandler.Instance.GetProduct(barcode), dis);
            
            return discount;
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
            Console.WriteLine("9. checkout");
            Console.WriteLine("10. show purchase history");
            Console.WriteLine("11. logout");
            Console.WriteLine("12. exit");

        }
        private static bool isowner(Store st,string username)
        {
            if (st.Owner.UserName.CompareTo(username) == 0)
                return true;
            for (int i = 0; i < st.co_owners.Count; i++)
            {
                if (st.co_owners[i].UserName.CompareTo(username) == 0)
                    return true;
            }
            return false;
        }
        private static bool ismanager(Store st, string username)
        {
            
            for (int i = 0; i < st.co_owners.Count; i++)
            {
                if (st.managers[i].UserName.CompareTo(username) == 0)
                    return true;
            }
            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using Version1.DataAccessLayer;
using Version1.domainLayer;
using Version1.domainLayer.DataStructures;
using Version1.LogicLayer;
using Version1.Service_Layer;
using System.Data.Entity;
using System.Linq;


namespace Version1.Service_Layer
{
    class Program
    {
        public static void Main(string[] args)
        {

            Operation o = new Operation();
            o.insertData();
            var facade = new Facade();
            Console.ReadLine();
            /*    
            facade.Register("zzz", "123");
           facade.Login("zzz", "123");
            facade.OpenShop("zzz","store1","ss");
            facade.AddNewProductToSystem("111", "product1", "descreption1", 2.5, new []{"cat1"});
            facade.AddItemToStore("store1", "111", 11);
            facade.AddProductToBasket("zzz", "store1", "111",12);
            var basket = facade.GetUserBaskets("zzz");
            Console.WriteLine("this is basket "+basket[0][6]);
            Console.ReadLine();
        var x = new Permissions();
        var result = x.GetPermissions2(27);
        foreach (var permission in result)
        {
            Console.WriteLine(permission);
        }
        Console.WriteLine(result.Count);
            facade.AdminInitSystem();
            var product = DataHandler.Instance.GetProduct("2", "AdnanStore");
            var oldAmount = DataHandler.Instance.Stores["AdnanStore"].GetInventory()[product];
            var up = facade.UpdateProductAmountInStore("adnan", "AdnanStore", "2", 1000);
            var newAmount = DataHandler.Instance.Stores["AdnanStore"].GetInventory()[product];
            Console.ReadKey();
            */
        }

        public class Operation
        {
            public void insertData()
            {

                /*//Review
                Review c = new Review("333s433", "33333s333");
                ReviewContext cc = new ReviewContext();
                cc.ReviewsTable.Add(c);
                Console.WriteLine(cc.ReviewsTable.Count());
                cc.SaveChanges();*/

                //User
                /*User c = new User("username", "pass");
                UserContext cc = new UserContext();
                cc.UsersTable.Add(c);
                cc.SaveChanges();*/

                /*//Discount
                Discount dis = new Discount(new Product("5555", "pname", "pDes", 2.2, new List<string>()),3);
                dis.id = 1;
                DiscountContext dc = new DiscountContext();
                dc.DiscountsTable.Add(dis);
                dc.SaveChanges();*/

                /* //Purchase
                Purchase c = new Purchase();
                c.purchaseId = 1;
                PurchaseContext cc = new PurchaseContext();
                cc.PurchasesTable.Add(c);
                cc.SaveChanges();*/

                /*//DataHandler
                DataHandler dh = DataHandler.Instance;
                DataHandlerContext dc = new DataHandlerContext();
                dc.DataHandlerTable = dh;
                dc.SaveChanges();*/

                /*//Store
                Store s = new Store("shady", "shadystoreName");
                StoreContext sc = new StoreContext();
                sc.StoresTable.Add(s);
                sc.SaveChanges();*/

                /*User c = new User("user33", "de2sc3");
                UserContext cc = new UserContext();
                cc.SaveChanges();*/

                /*//ShoppingCart
                ShoppingCart sc = new ShoppingCart();
                sc.id = 1;
                ShoppingCartContext scc = new ShoppingCartContext();
                scc.ShoppingCartsTable.Add(sc);
                scc.SaveChanges();
                */
                /*try
                {
                    var databaseCreator = (Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator);
                    databaseCreator.CreateTables();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    //A SqlException will be thrown if tables already exist. So simply ignore it.
                }*/
                /*User sb = new User("shady","pass");
                //sb.id = 1;
                UserContext sbc = new UserContext();
                sbc.UsersTable.Add(sb);
                sbc.SaveChanges();*/


                /* List<string> catagories = new List<string>();
                 catagories.Add("cat12");
                 Product p = new Product("proc=ductba3rcode", "product name", "dessc", 0.0, catagories);
                 Store s = new Store("aa", "ad");
                 s.notifications = new List<string>();
                 s.notifications.Add("asdasf");*/

                //database d = database.GetInstance();

                //facade.OpenStore("zzz", "store1", "");

                /*
                                //d.InsertDiscount(new Discount(p,50));
                                //d.Insertproduct(p);
                                //d.InsertPurchase(new Purchase());
                                ShoppingBasket sp = new ShoppingBasket("shadyStore");
                                sp.Products.Add(p.barcode, 1);
                                ShoppingCart sc = new ShoppingCart();
                                sc.id = 5;
                                sc.shoppingBaskets = new Dictionary<string, ShoppingBasket>();
                                sc.shoppingBaskets.Add("shady", sp);
                                //d.Insertproduct(p);
                                //d.InsertStore(s);
                                //d.getProducts();
                                User c = new User("shady", "pass");
                                //List<Purchase> history = new List<Purchase>();
                                //Purchase pur = new Purchase();
                                //pur.purchaseId = 5;
                                //pur.store = "shadyStore";
                                //history.Add(pur);
                                //c.history = history;
                                List<string> nots = new List<string>();
                                nots.Add("not1");
                                nots.Add("not12");
                                c.notifications = nots;
                                ShoppingCart scc = new ShoppingCart();
                                scc.id = 5;
                                c.shoppingCart = scc;
                                //d.InsertUser(c);
                                //d.InsertShoppingBasketDB(sp);
                                //d.InsertStore(new Store("shady", "shady"));
                                DataHandler dh = DataHandler.Instance;
                                dh.AddUser(c);
                                //temp
                                Store store = new Store("shady", "shady");
                                //dh.AddStore(store);
                                //d.DeleteStore(store);
                                ModelDB eo = new ModelDB();
                                Console.WriteLine("after add");
                                foreach (UserDB u in eo.UsersTable)
                                {
                                    Console.WriteLine("user " + u.UserName + " notifications is " + u.notifications);
                                }
                                d.DeleteUser(c.UserName);
                                Console.WriteLine("after delete");
                                foreach (UserDB u in eo.UsersTable)
                                {
                                    Console.WriteLine("user " + u.UserName + " notifications is " + u.notifications);
                                }
                                */
                Console.WriteLine("starting init data base tables please wait it might take a severral secends...\n");
                Facade facade = new Facade();
                facade.Register("zzz", "123");
                database db = database.GetInstance();
                //upload users
                if (db != null && db.getAllUsers() != null)
                {
                    db.getAllUsers().ToList().ForEach((user) =>
                    {
                        if (user != null)
                            Console.WriteLine(user.UserName);

                    });
                }

                db.DeleteUser("zzz");
                if (db != null && db.getAllUsers() != null)
                {
                    db.getAllUsers().ToList().ForEach((user) =>
                    {
                        if (user != null)
                            Console.WriteLine(user.UserName);

                    });
                }


                Console.WriteLine("\nfinish init data base tables you can open server\n");

                facade.Register("admin", "admin");
            }
        }



    }
}
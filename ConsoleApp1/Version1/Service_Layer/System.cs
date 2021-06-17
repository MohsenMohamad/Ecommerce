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

            /********************************/


            /*Operation2 o2 = new Operation2();
            o2.insertData();*/
        }

        public class Operation2
        {
            public void insertData()
            {
                FileController.Test();
            }
            
        }
        public class Operation
        {
            public void insertData()
            {

                Console.WriteLine("starting init data base tables please wait it might take a severral secends...\n");
                
                Facade facade = new Facade();
                database db = database.GetInstance();
                try
                {
                    db.DeleteUser("zzz");
                }
                catch
                {

                }
                
                facade.Register("zzz", "zzz");
                facade.OpenStore("zzz", "zzzStore", "");
                facade.CloseStore( "zzzStore", "zzz");
                db.DeleteUser("zzz");

                /*if (db != null && db.getAllUsers() != null)
                {
                    db.getAllUsers().ToList().ForEach((user) =>
                    {
                        if (user != null)
                            Console.WriteLine(user.UserName);

                    });
                }*/


                Console.WriteLine("\nfinish init data base tables you can open server\n");

                
                Console.ReadLine();
            }
        }



    }
}
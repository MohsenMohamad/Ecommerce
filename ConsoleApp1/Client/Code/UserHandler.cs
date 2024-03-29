﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Linq;
using System.Web;

namespace Client.Code
{
    public class UserHandler
    {

        public UserHandler() { }

        public string Register(string username, string password)
        {

            string param = string.Format("username={0}&password={1}", username, password);
            return (System.SendApi("Register", param));

        }
        public double GetTotalCart(string userName)
        {
            string param = string.Format("userName={0}", userName);
            return double.Parse(System.SendApi("GetTotalCart", param));
        }
        public string Login(string username, string password)
        {
            string param = string.Format("username={0}&password={1}", username, password);
            return (System.SendApi("Login", param));
        }

        public string InitByStateFile(string path)
        {
            string param = string.Format("path={0}", path);
            return System.SendApi("InitByStateFile", param);
        }

        public DataSet GetUserPurchaseHistory(string userName)
        {
            string param = string.Format("userName={0}", userName);
            JArray arr = (JArray)JsonConvert.DeserializeObject(System.SendApi("GetUserPurchaseHistory", param));
            DataTable t1 = new DataTable("Historys");
            t1.Columns.Add("id");
            t1.Columns.Add("History");
            if (arr != null)
            {
                for (int i = 0; i < arr.Count && arr[i] != null; i++)
                {
                    try
                    {
                        t1.Rows.Add(i, arr[i]);
                    }
                    catch
                    { }
                }
            }
            DataSet set = new DataSet("Historys");
            set.Tables.Add(t1);
            return set;
        }

        public string Purchase(string userName, string cardNumber, int expMonth, int expYear, string cardHolder, int cardCcv, int holderId, string nameF, string address, string city, string country, int zip)
        {

            string param = string.Format("userName={0}&cardNumber={1}&expMonth={2}&expYear={3}&cardHolder={4}&cardCcv={5}&holderId={6}&nameF={7}&address={8}&city={9}&country={10}&zip={11}", userName, cardNumber, expMonth, expYear, cardHolder, cardCcv, holderId, nameF, address, city, country, zip);
            return (System.SendApi("Purchase", param));
        }

        public string UpdateUserPassword(string userName, string newPassword)
        {
            string param = string.Format("userName={0}&newPassword={1}", userName, newPassword);
            return System.SendApi("UpdateUserPassword", param);
        }


        public long GuestLogin()
        {
            string param = "";
            return long.Parse(System.SendApi("GuestLogin", param));
        }
        public bool Logout(string userName)
        {
            string param = string.Format("username={0}", userName);
            return bool.Parse(System.SendApi("Logout", param));
        }

        public bool IsOwner(string storeName, string ownerName)
        {
            string param = string.Format("storeName={0}&ownerName={1}", storeName, ownerName);
            return bool.Parse(System.SendApi("IsOwner", param));
        }

        /*    public string AddNewOwner(string mangerName, string storename, string newOwner)
            {
                string param = string.Format("mangerName={0}&storename={1}&newOwner={2}", mangerName, storename, newOwner);
                return (System.SendApi("AddNewOwner", param));
            }*/
        public string MakeNewManger(string storeName, string apointerid, string apointeeid, int permissions)
        {
            string param = string.Format("storeName={0}&apointerid={1}&apointeeid={2}&permissions={3}", storeName, apointerid, apointeeid, permissions);
            return (System.SendApi("MakeNewManger", param));
        }

        public string MakeNewOwner(string storeName, string apointerid, string apointeeid, int permissions)
        {
            string param = string.Format("storeName={0}&apointerid={1}&apointeeid={2}&permissions={3}", storeName, apointerid, apointeeid, permissions);
            return (System.SendApi("MakeNewOwner", param));
        }

        public string removeOwner(string apointerid, string storeName, string apointeeid)
        {
            string param = string.Format("apointerid={0}&storeName={1}&apointeeid={2}", apointerid, storeName, apointeeid);
            return (System.SendApi("removeOwner", param));

        }
        public string removeManager(string apointerid, string storeName, string apointeeid)
        {
            string param = string.Format("apointerid={0}&storeName={1}&apointeeid={2}", apointerid, storeName, apointeeid);
            return (System.SendApi("removeManager", param));

        }



        public DataSet GetAllNotifications(string userName)
        {
            string param = string.Format("userName={0}", userName);
            JArray arr = (JArray)JsonConvert.DeserializeObject(System.SendApi("GetAllNotifications", param).ToString());
            DataTable t1 = new DataTable("Notifications");
            t1.Columns.Add("id");
            t1.Columns.Add("msg");
            if (arr != null)
            {
                for (int i = 0; i < arr.Count && arr[i] != null; i++)
                {
                    try
                    {
                        t1.Rows.Add(i, arr[i]);
                    }
                    catch
                    { }
                }
            }
            DataSet set = new DataSet("Notification");
            set.Tables.Add(t1);
            return set;
        }

        public DataSet GetAllUserNotificationsoffer(string userName)
        {
            string param = string.Format("userName={0}", userName);
            JArray arr = (JArray)JsonConvert.DeserializeObject(System.SendApi("GetAllUserNotificationsoffer", param).ToString());
            DataTable t1 = new DataTable("Notifications");
            t1.Columns.Add("id");
            t1.Columns.Add("Offer");
            if (arr != null)
            {
                for (int i = 0; i < arr.Count && arr[i] != null; i++)
                {
                    try
                    {
                        t1.Rows.Add(i, arr[i]);
                    }
                    catch
                    { }
                }
            }
            DataSet set = new DataSet("Notification");
            set.Tables.Add(t1);
            return set;
        }
    }
}
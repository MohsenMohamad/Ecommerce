using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace WebApplication.Code
{


    public class system
    {
        private const string server_domain = "https://localhost:8088/api";
        public enum Service_type { USER, SHOP, TRANSACTION }

        public static string SendApi(Service_type type, string method_name, string Parameters)
        {
            string service = "";
            switch (type)
            {
                case Service_type.USER:
                    service = "UserService";
                    break;
                case Service_type.TRANSACTION:
                    service = "TransactionService";
                    break;
                case Service_type.SHOP:
                    service = "ShopService";
                    break;
                default:
                    return "Service not found";

            }

            string URI = string.Format("{0}/{1}/{2}?{3}", server_domain, service, method_name, Parameters);
            try
            {


                // if(URI.Contains("remove_item_from_cart")) throw new Exception(URI);

                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(URI);
                request.Method = "GET";
                String test = String.Empty;
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    Stream dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    test = reader.ReadToEnd();
                    reader.Close();
                    dataStream.Close();
                }
                return test;
            }
            catch (Exception xxx)
            {
                return null;
            }
        }

    }

    

}
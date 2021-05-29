using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Threading;

namespace Client.Code
{
    public class System
    {
        private const string server_domain = "https://localhost:44300/api";

        public static string SendApi(string method_name, string Parameters)
        {
            
            string service = "";
            service = "facade";

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
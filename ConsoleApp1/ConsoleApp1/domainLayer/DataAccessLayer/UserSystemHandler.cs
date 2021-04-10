using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.domainLayer.DataAccessLayer
{
    public class UserSystemHandler
    {
        public UserDao logged_in_user { get; }
        public ShoppingHandler shopping { get; }
        private DataHandler data;
        public UserSystemHandler(string username,string password)
        {
            this.logged_in_user = new UserDao(username, password);
            data = DataHandler.Instance;
            shopping = new ShoppingHandler(logged_in_user.UserName);
        }
        private Business_Layer.User get_Bussines_user()
        {
            return data.getUser(logged_in_user.UserName);
            //equals null if user isnt found
        }

        public string GetProductsInfo()
        {
            string output = "the list of products";
            for (int i = 0; i < data.Products.Count; i++)
            {
                output += "/n" + data.Products[i].ToString();
            }
            return output;
        }
        public string GetStoresInfo()
        {
            string output = "the list of stores:";
            for (int i = 0; i < data.Stores.Count; i++)
            {
                output += "/n" + data.Stores[i].ToString();
            }
            return output;
        }
        public DAProduct SearchProductByName(string name) {

            return data.GetproductByName(name);

        }

        public List<DAProduct> SearchProductsByCategory(string category_name)
        {
            List<DAProduct> output = data.SearchProductByCategory(category_name);

            return output;


        }
        public List<DAProduct> SearchProductByKeyWord(string key_word) {
            List<DAProduct> output = data.SearchProductByKeyWord(key_word);

            return output;

        }
        public void WriteReview(string desc)
        {
            data.AddReview(logged_in_user.UserName, desc);
        }

        public void RateProductAndStore()
        {
            throw new NotImplementedException();
        }

        public void SendMessageToStore(string msg,string storename)
        {
            SystemAdmin.RecieveComplainToStore(msg, storename);
        }

        public void SendMessageToUser(string msg, string username)
        {
            SystemAdmin.RecieveComplainToUser(msg, username);
        }


    }
}

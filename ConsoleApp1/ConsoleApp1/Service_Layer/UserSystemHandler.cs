using ConsoleApp1.domainLayer.DataAccessLayer;
using ConsoleApp1.domainLayer.Business_Layer;
using System;
using System.Collections.Generic;
using System.Text;
using User = ConsoleApp1.domainLayer.Business_Layer.User;

namespace ConsoleApp1.Service_Layer
{
     public class UserSystemHandler
    {
        private readonly DataHandler data;
        private User loggedinuser;

        public UserSystemHandler(User us)
        {
            this.loggedinuser = us;
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
        void SearchProductByName() { throw new NotImplementedException(); }
        void SearchProductByCategory() { throw new NotImplementedException(); }
        void SearchProductByKeyWord() { throw new NotImplementedException(); }
        public void WriteReview()
        {
            throw new NotImplementedException();
        }

        public void RateProductAndStore()
        {
            throw new NotImplementedException();
        }

        public void SendMessageToStore()
        {
            throw new NotImplementedException();
        }

        public void SendComplain()
        {
            throw new NotImplementedException();
        }

    }
}

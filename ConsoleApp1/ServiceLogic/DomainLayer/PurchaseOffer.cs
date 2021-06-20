using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLogic.DataAccessLayer.DataStructures;
using ServiceLogic.LogicLayer;
using ServiceLogic.Service_Layer;

namespace ServiceLogic.domainLayer
{
   public class PurchaseOffer
    {
        private Product product;
        private Store store;
        private User user;
        private double price;
        private int amount;
        public int number_of_owners { get; set; }
        private List<string> accepted; 
        
        public PurchaseOffer(Product pr,User us,Store st, double price,int amount)
        {
            this.store = st;
            this.product = pr;
            this.price = price;
            this.user = us;
            this.amount = amount;
            this.number_of_owners = 0;
            accepted = new List<string>();
        }

        public void makeOffer()
        {
            var owners = store.GetOwners();
            for (int i = 0; i < owners.Count; i++)
            {
                UserLogic.AddUserNotification(owners[i], "offer for:" + product.Barcode + ". the Amount:" + amount + ". the offered price is:" + price + ". from:" + user.UserName + ". from store:" + store.GetName());
                UserLogic.AddUserNotificationoffer(owners[i], "offer for:" + product.Barcode + ". the Amount:" + amount + ". the offered price is:" + price + ". from:" + user.UserName + ". from store:" + store.GetName());
            }
        }

        public bool acceptOffer()
        {
            var owners = store.GetOwners();
            
            UserLogic.AddUserNotification(user.UserName, "offer for: " + product.Barcode + " with the price: " + price + " was accepted");

                for (int i = 0; i < owners.Count; i++)
                {
                    UserLogic.AddUserNotification(owners[i], "offer for: " + product.Barcode + " with the price: " + price + " was accepted");
                    UserLogic.removeuserNotification(owners[i], "offer for:" + product.Barcode + ". the Amount:" + amount + ". the offered price is:" + price + ". from:" + user.UserName + ". from store:" + store.GetName());
                    UserLogic.removeuserNotification(user.UserName, "offer for:" + product.Barcode + ". the Amount:" + amount + ". the offered price is:" + price + ". from:" + owners[i] + ". from store:" + store.GetName());
/*                UserLogic.removeuserNotification(user.UserName, "offer for:" + product.Barcode + ". the Amount:" + amount + ". the offered price is:" + oldprice + ". from:" + owners[i] + ". from store:" + store.GetName());
*/            }
            
            return true;
        }
        public bool acceptOffernotfinal(string by)
        {
            var owners = store.GetOwners();
            if (!accepted.Contains(by))
            {
                UserLogic.removeuserNotification(by, "offer for:" + product.Barcode + ". the Amount:" + amount + ". the offered price is:" + price + ". from:" + user.UserName + ". from store:" + store.GetName());
                accepted.Add(by);
                number_of_owners+=1;
            }
            if (number_of_owners == owners.Count)
                return acceptOffer();
            return false;

        }

        public void rejectOffer()
        {
            UserLogic.AddUserNotification(user.UserName, "the offer for: " + product.Barcode + " with the price: " + price + " was rejected");
            var owners = store.GetOwners();
            for (int i = 0; i < owners.Count; i++)
            {
                UserLogic.AddUserNotification(owners[i], "the offer for: " + product.Barcode + " with the price: " + price + " was rejected");
                UserLogic.removeuserNotification(owners[i], "offer for:" + product.Barcode + ". the Amount:" + amount + ". the offered price is:" + price + ". from:" + user.UserName + ". from store:" + store.GetName());
                UserLogic.removeuserNotification(user.UserName, "offer for:" + product.Barcode + ". the Amount:" + amount + ". the offered price is:" + price + ". from:" + owners[i] + ". from store:" + store.GetName());

            }
        }
        //called if owner is an owner
        public void counteroffer(string owner, string oldprice)
        {
            
            UserLogic.AddUserNotification(user.UserName, "offer for:" + product.Barcode + ". the Amount:" + amount + ". the offered price is:" + price + ". from:" + owner + ". from store:" + store.GetName());
            UserLogic.AddUserNotificationoffer(user.UserName, "offer for:" + product.Barcode + ". the Amount:" + amount + ". the offered price is:" + price + ". from:" + owner + ". from store:" + store.GetName());
            var owners = store.GetOwners();
            for (int i = 0; i < owners.Count; i++)
            {
                UserLogic.removeuserNotification(owners[i], "offer for:" + product.Barcode + ". the Amount:" + amount + ". the offered price is:" + oldprice + ". from:" + user.UserName + ". from store:" + store.GetName());
                
            }
            UserLogic.removeuserNotification(owner, "offer for:" + product.Barcode + ". the Amount:" + amount + ". the offered price is:" + oldprice + ". from:"+ user.UserName + ". from store:" + store.GetName());
        }

        public void counterofferifnotowner(string owner, string oldprice)
        {
            UserLogic.removeuserNotification(user.UserName, "offer for:" + product.Barcode + ". the Amount:" + amount + ". the offered price is:" + oldprice + ". from:" + owner + ". from store:" + store.GetName()); var owners = store.GetOwners();
            for (int i = 0; i < owners.Count; i++)
            {
                UserLogic.removeuserNotification(owners[i], "offer for:" + product.Barcode + ". the Amount:" + amount + ". the offered price is:" + oldprice + ". from:" + user.UserName + ". from store:" + store.GetName());
                UserLogic.AddUserNotification(owners[i], "offer for:" + product.Barcode + ". the Amount:" + amount + ". the offered price is:" + price + ". from:" + user.UserName + ". from store:" + store.GetName());
                UserLogic.AddUserNotificationoffer(owners[i], "offer for:" + product.Barcode + ". the Amount:" + amount + ". the offered price is:" + price + ". from:" + user.UserName + ". from store:" + store.GetName());
            }
           
        }

        public bool checkequals(Product pr, User us, Store st, double price, int amount)
        {
            return this.product.Barcode.CompareTo(pr.Barcode) == 0 && this.user.UserName.CompareTo(us.UserName) == 0 && this.store.GetName().CompareTo(st.GetName()) == 0 && this.price == price && this.amount == amount;
        }
    }
}

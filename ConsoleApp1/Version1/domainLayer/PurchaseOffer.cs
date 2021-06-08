using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Version1.domainLayer.DataStructures;
using Version1.LogicLayer;

namespace Version1.domainLayer
{
    class PurchaseOffer
    {
        private Product product;
        private Store store;
        private User user;
        private double price;
        private int amount;
        
        public PurchaseOffer(Product pr,User us,Store st, double price,int amount)
        {
            this.store = st;
            this.product = pr;
            this.price = price;
            this.user = us;
            this.amount = amount;
            
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

        public void acceptOffer()
        {
            UserLogic.AddUserNotification(user.UserName, "offer for: " + product.Barcode + " with the price: " + price + " was accepted");
            var owners = store.GetOwners();
            for (int i = 0; i < owners.Count; i++)
            {
                UserLogic.AddUserNotification(owners[i], "offer for: " + product.Barcode + " with the price: " + price + " was accepted");
                UserLogic.removeuserNotification(owners[i], "offer for:" + product.Barcode + ". the Amount:" + amount + ". the offered price is:" + price + ". from:" + user.UserName + ". from store:" + store.GetName());
                UserLogic.removeuserNotification(user.UserName, "offer for:" + product.Barcode + ". the Amount:" + amount + ". the offered price is:" + price + ". from:" + owners[i] + ". from store:" + store.GetName());
            }

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
    }
}

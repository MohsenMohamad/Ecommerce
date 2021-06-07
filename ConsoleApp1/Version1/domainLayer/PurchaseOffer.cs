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
        public PurchaseOffer(Product pr,User us,Store st, double price)
        {
            this.store = st;
            this.product = pr;
            this.price = price;
            this.user = us;
            
        }

        public void makeOffer()
        {
            var owners = store.GetOwners();
            for (int i = 0; i < owners.Count; i++)
            {
                UserLogic.AddUserNotification(owners[i], "offer for:" + product.Barcode + ". the offered price is:" + price + ". from:" + user.UserName + ". from store:" + store.GetName());
                UserLogic.AddUserNotificationoffer(owners[i], "offer for:" + product.Barcode +  ". the offered price is:" + price + ". from:" + user.UserName+". from store:"+store.GetName());
            }
        }

        public void acceptOffer()
        {
            UserLogic.AddUserNotification(user.UserName, "offer for: " + product.Barcode + " with the price: " + price + " was accepted");
            var owners = store.GetOwners();
            for (int i = 0; i < owners.Count; i++)
            {
                UserLogic.removeuserNotification(owners[i], "offer for:" + product.Barcode + ". the offered price is:" + price + ". from:" + user.UserName + ". from store:" + store.GetName());
            }
            /*add product to cart
             * 
             * 
             * */
        }
    }
}

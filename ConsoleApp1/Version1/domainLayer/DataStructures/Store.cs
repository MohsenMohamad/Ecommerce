using System.Collections.Concurrent;
using System.Collections.Generic;
using Version1.DataAccessLayer;
using Version1.domainLayer.CompositeDP;

namespace Version1.domainLayer.DataStructures
{
    public class Store
    {
        private string name { get; set; }
        private List<Component> purchasePolicies { get; set; }
        public Node<string, int> staff;
        private List<string> notifications;
        private List<string> paymentInfo{ get; set; }
        private List<Discount> discounts { get; }
        private List<Purchase> history { get; }
        private ConcurrentDictionary<Product, int> inventory; // key : product , value : amount
        public DTO_Policies discountPolicy { get; set; }


        public Store(string owner,string name)
        {
            staff = new Node<string,int>(owner,-1);
            purchasePolicies = new List<Component>();
            inventory = new ConcurrentDictionary<Product, int>();
            discounts = new List<Discount>();
            history = new List<Purchase>();
            paymentInfo = new List<string>();
            this.name = name;
            notifications = new List<string>();
        }

        public override string ToString()
        {
            string output = "";
            output += "Store name: " + name;
            output += "/nStore Owner: " + GetOwner();
            output += "/nmanagers:/n ";
            foreach (var manager in GetManagers())
            {
                output += "/n " + manager;
            }
            output += "/n--------------------------------------/n";
            output += "/nco owners:/n ";
            foreach (var owner in GetOwners())
            {
                output += "/n " + owner;
            }
            output += "/n--------------------------------------/n";
            output += inventory.ToString();

            return output;
        }
        
//----------------------------------- Getters -----------------------------------//

        public string GetName()
        {
            return name;
        }
        
        public List<Component> GetPurchasePolicies()
        {
            return purchasePolicies;
        }

        public string GetOwner()
        {
            return staff.Key;
        }

        public List<Purchase> GetHistory()
        {
            return history;
        }

        public List<string> GetManagers()
        {
            return staff.GetNotNull();
        }
        
        public List<string> GetOwners()
        {
            return staff.GetByValue(-1); // -1 = no specified permission = owner
        }

        public List<string> GetNotifications()
        {
            return notifications;
        }

        public List<Discount> GetDiscounts()
        {
            return discounts;
        }
        
        public ConcurrentDictionary<Product, int> GetInventory()
        {
            return inventory;
        }
        
        public Node<string, int> GetStaffTree()
        {
            return staff;
        }

        public List<string> GetPaymentsInfo()
        {
            return paymentInfo;
        }
        
//----------------------------------- Setters -----------------------------------//
        
        public void SetPurchasePolicies(List<Component> newPolicies)
        {
            purchasePolicies = newPolicies;
        }


        public int addPublicDiscount(string storeName, int percentage)
        {
            discountPolicy = new DTO_Policies();

            foreach (var x in inventory) {
                x.Key.discountPolicy.percentage = percentage;
                x.Key.discountPolicy.discount_description = string.Format("discount {0}% off ", percentage);
            }

            discountPolicy.discount_description = string.Format("discount {0}% off ", percentage);
            discountPolicy.percentage = percentage;

            return 1;
        }
    }
}

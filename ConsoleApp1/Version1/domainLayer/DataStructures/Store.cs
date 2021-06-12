using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Version1.DataAccessLayer;
using Version1.domainLayer.CompositeDP;
using Version1.domainLayer.DiscountPolicies;

namespace Version1.domainLayer.DataStructures
{
    public class Store
    {
        public string name { get; set; }
        public List<Component> purchasePolicies { get; set; }
        public Node<string, int> staff;
        public List<string> notifications { get; set; }
        public List<string> paymentInfo { get; set; }
        public List<Purchase> history { get; }

        public ConcurrentDictionary<Product, int> inventory; // key : product , value : amount

        public List<DTO_Policies> discountPolicies { get; set; }


        public Store(string owner, string name)
        {
            staff = new Node<string, int>(owner, -1);
            purchasePolicies = new List<Component>();
            history = new List<Purchase>();
            paymentInfo = new List<string>();
            inventory = new ConcurrentDictionary<Product, int>();
            this.name = name;
            notifications = new List<string>();

            discountPolicies = new List<DTO_Policies>();
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
            DTO_Policies discountPolicy = new DTO_Policies();

            foreach (var x in inventory)
            {
                x.Key.discountPolicy.discount_description += string.Format(" discount {0}% off for all the shop", percentage);
            }

            discountPolicy.SetPublic(percentage);
            discountPolicy.discount_description = string.Format("discount {0}% off ", percentage);
            this.discountPolicies.Add(discountPolicy);
            return 1;

        }
        public int addConditionalDiscount(string storeName, int percentage, string condition)
        {
            int res;
            try { Condition.Parse(condition); }
            catch (Exception e) { return -13; }
            DTO_Policies p = new DTO_Policies();

            if ((res = p.SetConditional(percentage, condition)) < 0)
                return res;
            foreach (var x in inventory)
            {
                x.Key.discountPolicy.discount_description += string.Format("# discount {0} % off for if the condition : {1} accomplish#", percentage, condition);
            }
            DTO_Policies discountPolicy = new DTO_Policies(); 
            discountPolicy.SetConditional(percentage, condition);
            this.discountPolicies.Add(discountPolicy);
            return res;

        }


    }
}

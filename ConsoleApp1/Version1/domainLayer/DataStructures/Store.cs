using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Version1.domainLayer.StorePolicies;

namespace Version1.domainLayer.DataStructures
{
    public class Store
    {
        private string name { get; set; }
        private List<IPurchasePolicy> purchasePolicies { get; set; }
        private Node<string, int> staff;
        private List<string> notifications;
        private List<string> paymentInfo{ get; set; }
        private Dictionary<string,int> managers { get; } // key : manager name , value : permissions
        private List<string> owners { get; } // key : owner name , value : appointed owners
        private List<Discount> discounts { get; }
        private List<Purchase> history { get; }
        private ConcurrentDictionary<Product, int> inventory; // key : product , value : amount
        
        
        public Store(string owner,string name)
        {
            var originalOwner = new Tuple<string,int>(owner,-1);
            staff = new Node<string,int>(owner,-1);
            purchasePolicies = new List<IPurchasePolicy>();
            managers = new Dictionary<string, int>();
            inventory = new ConcurrentDictionary<Product, int>();
            discounts = new List<Discount>();
            history = new List<Purchase>();
            owners = new List<string> {owner};
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
            foreach (var manager in managers.Keys)
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
        
        public List<IPurchasePolicy> GetPurchasePolicies()
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

        public Dictionary<string,int> GetManagers()
        {
            return managers;
        }
        
        public List<string> GetOwners()
        {
            return owners;
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

        public List<string> GetPaymentsInfo()
        {
            return paymentInfo;
        }
        
//----------------------------------- Setters -----------------------------------//
        
        public void SetPurchasePolicies(List<IPurchasePolicy> newPolicies)
        {
            purchasePolicies = newPolicies;
        }
        
    }
}

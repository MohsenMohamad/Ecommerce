using System.Collections.Concurrent;
using System.Collections.Generic;
using Version1.domainLayer.StorePolicies;

namespace Version1.domainLayer.DataStructures
{
    public class Store
    {
        private string name { get; set; }
        private string originalOwner { get; }
        private List<IPurchasePolicy> purchasePolicies { get; set; }
        private List<string> notifications;
        private List<string> paymentInfo{ get; set; }
        private Dictionary<string,int> managers { get; } // key : manager name , value : permissions
        private Dictionary<string,List<string>> owners { get; } // key : owner name , value : appointed owners
        private List<Discount> discounts { get; }
        private List<Purchase> history { get; }
        private ConcurrentDictionary<string,int> inventory { get; }
        
        
        public Store(string owner,string name)
        {
            purchasePolicies = new List<IPurchasePolicy>();
            managers = new Dictionary<string, int>();
            inventory = new ConcurrentDictionary<string, int>();
            discounts = new List<Discount>();
            history = new List<Purchase>();
            owners = new Dictionary<string, List<string>> {{owner, new List<string>()}};
            originalOwner = owner;
            paymentInfo = new List<string>();
            this.name = name;
            notifications = new List<string>();
        }

        public override string ToString()
        {
            string output = "";
            output += "Store name: " + name;
            output += "/nStore Owner: " + originalOwner;
            output += "/nmanagers:/n ";
            foreach (var manager in managers.Keys)
            {
                output += "/n " + manager;
            }
            output += "/n--------------------------------------/n";
            output += "/nco owners:/n ";
            foreach (var owner in owners.Keys)
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
            return originalOwner;
        }

        public List<Purchase> GetHistory()
        {
            return history;
        }

        public Dictionary<string,int> GetManagers()
        {
            return managers;
        }
        
        public Dictionary<string,List<string>> GetOwners()
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
        
        public ConcurrentDictionary<string, int> GetInventory()
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
        

        internal void ReceiveMsg(string msg)
        {
            notifications.Add(msg);
        }

        public bool AddDiscount(Discount dis)
        {
            if (discounts.Contains(dis))
                return false;
            discounts.Add(dis);
            return true;
        }
        public bool RemoveDiscount(Discount dis)
        {
            if (!discounts.Contains(dis))
                return false;
            discounts.Remove(dis);
            return true;
        }
        public bool AddPurchase(Purchase purchase)
        {
            if (history.Contains(purchase))
                return false;
            history.Add(purchase);
            return true;
        }
        public bool RemovePurchase(Purchase purchase)
        {
            if (!history.Contains(purchase))
                return false;
            history.Remove(purchase);
            return true;
        }
        public void addProduct(string pr, int amount)
        {
            if (inventory.ContainsKey(pr))
                inventory[pr] = inventory[pr] +amount;
            else if(amount>=0) inventory[pr] = amount;

        }
        public bool RemoveProduct(string pr, int amount)
        {
            if (inventory.ContainsKey(pr) && inventory[pr] >= amount)
            {
                inventory[pr] = inventory[pr] - amount;
                return true;
            }
            return false;

        }
        public bool RemoveProduct(string pr)
        {
            if (inventory.ContainsKey(pr))
            {
                inventory[pr] = 0;
                return true;
            }
            return false;

        }
        public int Checkinventory(string pr)
        {
            if (inventory.ContainsKey(pr))
                return (int)inventory[pr];
            else return -1;
        }
    }
}

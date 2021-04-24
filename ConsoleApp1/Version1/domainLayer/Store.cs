using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Version1.domainLayer
{
    public class Store
    {
        private string name { get; set; }
        private User owner { get; set; }
        private string sellingPolicy { get; set; }
        private List<string> notifications;
        private List<string> paymentInfo{ get; set; }
        private List<User> managers { get; }
        private List<User> co_owners { get; }
        private List<Discount> discounts { get; }
        private List<Purchase> history { get; }
        private ConcurrentDictionary<Product,int> inventory { get; }
        
        
        public Store(User owner,String sellpol,string name)
        {
            this.owner = owner;
            sellingPolicy = sellpol;
            managers = new List<User>();
            inventory = new ConcurrentDictionary<Product, int>();
            discounts = new List<Discount>();
            history = new List<Purchase>();
            co_owners = new List<User>();
            this.name = name;
            notifications = new List<string>();
        }

        public override string ToString()
        {
            string output = "";
            output += "Store name: " + name;
            output += "/nStore Owner: " + owner.UserName;
            output += "/nmanagers:/n ";
            for (int i = 0; i < managers.Count; i++)
            {
                output += "/n " + managers[i].UserName;
            }
            output += "/n--------------------------------------/n";
            output += "/nco owners:/n ";
            for (int i = 0; i < managers.Count; i++)
            {
                output += "/n " + co_owners[i].UserName;
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
        
        public string GetSellingPolicy()
        {
            return sellingPolicy;
        }

        public User GetOwner()
        {
            return owner;
        }

        public List<Purchase> GetHistory()
        {
            return history;
        }

        public List<User> GetManagers()
        {
            return managers;
        }
        
        public List<User> GetOwners()
        {
            return co_owners;
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
        
        public void SetSellingPolicy(string newPolicy)
        {
            sellingPolicy = newPolicy;
        }
        
        public bool AddManager(User man)
        {
            if (managers.Contains(man))
                return false;
            managers.Add(man);
            return true;
        }
        public bool RemoveManager(User man)
        {
            if (!managers.Contains(man))
                return false;
            managers.Remove(man);
            return true;
        }
        public bool AddOwner(User own)
        {
            if (co_owners.Contains(own))
                return false;
            co_owners.Add(own);
            return true;
        }
        public bool RemoveOwner(User own)
        {
            if (!co_owners.Contains(own))
                return false;
            co_owners.Remove(own);
            return true;
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
        public void addProduct(Product pr, int amount)
        {
            if (inventory.ContainsKey(pr))
                inventory[pr] = (int)inventory[pr] +amount;
            else if(amount>=0) inventory[pr] = amount;

        }
        public bool RemoveProduct(Product pr, int amount)
        {
            if (inventory.ContainsKey(pr) && (int)inventory[pr] >= amount)
            {
                inventory[pr] = (int)inventory[pr] - amount;
                return true;
            }
            return false;

        }
        public bool RemoveProduct(Product pr)
        {
            if (inventory.ContainsKey(pr))
            {
                inventory[pr] = 0;
                return true;
            }
            return false;

        }
        public int Checkinventory(Product pr)
        {
            if (inventory.ContainsKey(pr))
                return (int)inventory[pr];
            else return -1;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Version1.domainLayer
{
    public class Store
    {
        private string name { get; set; }
        private string sellingPolicy { get; set; }
        private List<string> notifications;
        private List<string> paymentInfo{ get; set; }
        private List<string> managers { get; }
        private List<string> owners { get; }
        private List<Discount> discounts { get; }
        private List<Purchase> history { get; }
        private ConcurrentDictionary<string,int> inventory { get; }
        
        
        public Store(string owner,String sellpol,string name)
        {
            sellingPolicy = sellpol;
            managers = new List<string>();
            inventory = new ConcurrentDictionary<string, int>();
            discounts = new List<Discount>();
            history = new List<Purchase>();
            owners = new List<string> {owner};
            this.name = name;
            notifications = new List<string>();
        }

        public override string ToString()
        {
            string output = "";
            output += "Store name: " + name;
            output += "/nStore Owner: " + owners[0];
            output += "/nmanagers:/n ";
            for (int i = 0; i < managers.Count; i++)
            {
                output += "/n " + managers[i];
            }
            output += "/n--------------------------------------/n";
            output += "/nco owners:/n ";
            for (int i = 1; i < managers.Count; i++)
            {
                output += "/n " + owners[i];
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

        public string GetOwner()
        {
            return owners[0];
        }

        public List<Purchase> GetHistory()
        {
            return history;
        }

        public List<string> GetManagers()
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
        
        public ConcurrentDictionary<string, int> GetInventory()
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
        
        public bool AddManager(string manager)
        {
            if (managers.Contains(manager))
                return false;
            managers.Add(manager);
            return true;
        }
        public bool RemoveManager(string manager)
        {
            if (!managers.Contains(manager))
                return false;
            managers.Remove(manager);
            return true;
        }
        public bool AddOwner(string owner)
        {
            if (owners.Contains(owner))
                return false;
            owners.Add(owner);
            return true;
        }
        public bool RemoveOwner(string owner)
        {
            if (!owners.Contains(owner))
                return false;
            owners.Remove(owner);
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

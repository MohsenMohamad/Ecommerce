using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.domainLayer.Business_Layer
{
    class Store
    {
        private string name;
        private User owner;
        private List<User> managers;
        private List<User> co_owners;
        private Hashtable inventory;
        private List<Discount> discounts;
        private String sellingpolicy;
        private List<Purchase> history;

        public Store(User owner,String sellpol,string name)
        {
            this.owner = owner;
            this.sellingpolicy = sellpol;
            managers = new List<User>();
            inventory = new Hashtable();
            discounts = new List<Discount>();
            history = new List<Purchase>();
            co_owners = new List<User>();
            this.name = name;
        }

        public User Owner { get => owner; }
        public String SellingPolicy { get => sellingpolicy; }
        public string  Name { get => name; }
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
        public bool AddDiscount(Purchase purchase)
        {
            if (history.Contains(purchase))
                return false;
            history.Add(purchase);
            return true;
        }
        public bool RemoveDiscount(Purchase purchase)
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
            else inventory[pr] = amount;

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
        public int Checkinventory(Product pr)
        {
            if (inventory.ContainsKey(pr))
                return (int)inventory[pr];
            else return -1;
        }
    }
}

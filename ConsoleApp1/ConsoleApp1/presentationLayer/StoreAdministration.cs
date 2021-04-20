using ConsoleApp1.DataAccessLayer;
using ConsoleApp1.domainLayer;
using ConsoleApp1.domainLayer.Business_Layer;

namespace ConsoleApp1.presentationLayer
{
    public class StoreAdministration
    {
        private readonly DataHandler data;
        
        public StoreAdministration()
        {
            data = DataHandler.Instance;
        }

        public bool AddToInventory(string barcode ,int amount, string storeName)
        {
            Product pr = GetProduct(barcode);
            if (pr != null)
            {
                Store st = GetStore(storeName);
                if (st != null)
                {
                    st.addProduct(pr, amount);
                    return true;
                }
            }
            return false;

        }

        private Store GetStore(string name)
        {
            return data.GetStore(name);
        }

        private Product GetProduct(string barcode)
        {
            return data.GetProduct(barcode);
        }

        public bool AddDiscount(string storeName, Discount dc)
        {
            Store st = GetStore(storeName);
            if (st != null)
            {
                st.AddDiscount(dc);
                return true;
            }
            return false;
        }

        public bool RemoveDiscount(string storeName,string barcode)
        {
            Store st = GetStore(storeName);
            if (st != null)
            {
                for (int i = 0; i < st.discounts.Count; i++)
                {
                    if (st.discounts[i].items.Key.Barcode.CompareTo(barcode) == 0)
                    {
                        st.discounts.RemoveAt(i);
                        return true;
                    }
                }
            }
            return false;
        }

        public bool AddManager(string storeName, string username)
        {
            User us = data.GetUser(username);
            Store st = GetStore(storeName);
            if (us != null&&st!=null)
            {
                return st.AddManager(us);
            }
            return false;
        }
        public bool RemoveManager(string storeName, string username)
        {
            User us = data.GetUser(username);
            Store st = GetStore(storeName);
            if (us != null && st != null)
            {
                return st.RemoveManager(us);
            }
            return false;
        }

        public bool AddOwner(string storeName, string username)
        {
            User us = data.GetUser(username);
            Store st = GetStore(storeName);
            if (us != null && st != null)
            {
                return st.AddOwner(us);
            }
            return false;
        }
        public bool RemoveOwner(string storeName, string username)
        {
            User us = data.GetUser(username);
            Store st = GetStore(storeName);
            if (us != null && st != null)
            {
                return st.RemoveOwner(us);
            }
            return false;
        }
        public bool AddPurchase(string storeName, Purchase pr)
        {
            Store st = GetStore(storeName);
            if (st != null)
            {
                return st.AddPurchase(pr);
            }
            return false;
        }
        public bool RemovePurchase(string storeName,Purchase pr)
        {
            var st = GetStore(storeName);
            if (st != null)
            {
                return st.RemovePurchase(pr);
            }
            return false;
        }

        public bool CheckInventory(string storeName,string barcode)
        {
            var pr = GetProduct(barcode);
            if (pr != null)
            {
                var st = GetStore(storeName);
                if (st != null)
                {
                    var x= st.Checkinventory(pr);
                    return x>0;
                }
            }
            return false;

        }
    }
}

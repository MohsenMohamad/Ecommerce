using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.domainLayer.DataAccessLayer
{
    class StoreAdministration
    {
        private readonly StoreDao currentstore;
        private DataHandler data;
        public StoreAdministration(string storename)
        {
            data = DataHandler.Instance;
            currentstore = data.GetStore(storename);
        }

        public bool Add_inventory(string barcode ,int amount)
        {
            Business_Layer.Product pr = getProduct(barcode);
            if (pr != null)
            {
                Business_Layer.Store st = getStore(currentstore.Name);
                if (st != null)
                {
                    st.addProduct(pr, amount);
                    return true;
                }
            }
            return false;

        }

        private Business_Layer.Store getStore(string name)
        {
            for (int i = 0; i < data.Stores.Count; i++)
            {
                if (data.Stores[i].Name.CompareTo(name) == 0)
                    return data.Stores[i];

            }
            return null;
        }

        private Business_Layer.Product getProduct(string barcode)
        {
            for (int i = 0; i < data.Products.Count; i++)
            {
                if (data.Products[i].Barcode.CompareTo(barcode) == 0)
                    return data.Products[i];

            }
            return null;
        }

        public bool AddDiscount(Business_Layer.Discount dc)
        {
            Business_Layer.Store st = getStore(currentstore.Name);
            if (st != null)
            {
                st.AddDiscount(dc);
                return true;
            }
            return false;
        }

        public bool RemoveDiscount(Business_Layer.Discount dc)
        {
            Business_Layer.Store st = getStore(currentstore.Name);
            if (st != null)
            {
                st.RemoveDiscount(dc);
                return true;
            }
            return false;
        }

        public bool addManager(string username)
        {
            Business_Layer.User us = data.getUser(username);
            Business_Layer.Store st = getStore(currentstore.Name);
            if (us != null&&st!=null)
            {
                return st.AddManager(us);
            }
            return false;
        }
        public bool RemoveManager(string username)
        {
            Business_Layer.User us = data.getUser(username);
            Business_Layer.Store st = getStore(currentstore.Name);
            if (us != null && st != null)
            {
                return st.RemoveManager(us);
            }
            return false;
        }

        public bool addOwner(string username)
        {
            Business_Layer.User us = data.getUser(username);
            Business_Layer.Store st = getStore(currentstore.Name);
            if (us != null && st != null)
            {
                return st.AddOwner(us);
            }
            return false;
        }
        public bool removeOwner(string username)
        {
            Business_Layer.User us = data.getUser(username);
            Business_Layer.Store st = getStore(currentstore.Name);
            if (us != null && st != null)
            {
                return st.RemoveOwner(us);
            }
            return false;
        }
        public bool AddPurchase(Business_Layer.Purchase pr)
        {
            Business_Layer.Store st = getStore(currentstore.Name);
            if (st != null)
            {
                return st.AddPurchase(pr);
            }
            return false;
        }
        public bool RemovePurchase(Business_Layer.Purchase pr)
        {
            Business_Layer.Store st = getStore(currentstore.Name);
            if (st != null)
            {
                return st.RemovePurchase(pr);
            }
            return false;
        }

        public bool check_inventory(string barcode)
        {
            Business_Layer.Product pr = getProduct(barcode);
            if (pr != null)
            {
                Business_Layer.Store st = getStore(currentstore.Name);
                if (st != null)
                {
                   int x= st.Checkinventory(pr);
                    return x>0;
                }
            }
            return false;

        }

    }
}

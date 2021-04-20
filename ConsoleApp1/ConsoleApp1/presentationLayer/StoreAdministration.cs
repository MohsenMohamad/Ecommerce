using ConsoleApp1.DataAccessLayer;
using ConsoleApp1.domainLayer;

namespace ConsoleApp1.presentationLayer
{
    public class StoreAdministration
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
            domainLayer.Business_Layer.Product pr = getProduct(barcode);
            if (pr != null)
            {
                domainLayer.Business_Layer.Store st = getStore(currentstore.Name);
                if (st != null)
                {
                    st.addProduct(pr, amount);
                    return true;
                }
            }
            return false;

        }

        private domainLayer.Business_Layer.Store getStore(string name)
        {
            for (int i = 0; i < data.Stores.Count; i++)
            {
                if (data.Stores[i].Name.CompareTo(name) == 0)
                    return data.Stores[i];

            }
            return null;
        }

        private domainLayer.Business_Layer.Product getProduct(string barcode)
        {
            for (int i = 0; i < data.Products.Count; i++)
            {
                if (data.Products[i].Barcode.CompareTo(barcode) == 0)
                    return data.Products[i];

            }
            return null;
        }

        public bool AddDiscount(domainLayer.Business_Layer.Discount dc)
        {
            domainLayer.Business_Layer.Store st = getStore(currentstore.Name);
            if (st != null)
            {
                st.AddDiscount(dc);
                return true;
            }
            return false;
        }

        public bool RemoveDiscount(string barcode)
        {
            domainLayer.Business_Layer.Store st = getStore(currentstore.Name);
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

        public bool addManager(string username)
        {
            domainLayer.Business_Layer.User us = data.getUser(username);
            domainLayer.Business_Layer.Store st = getStore(currentstore.Name);
            if (us != null&&st!=null)
            {
                return st.AddManager(us);
            }
            return false;
        }
        public bool RemoveManager(string username)
        {
            domainLayer.Business_Layer.User us = data.getUser(username);
            domainLayer.Business_Layer.Store st = getStore(currentstore.Name);
            if (us != null && st != null)
            {
                return st.RemoveManager(us);
            }
            return false;
        }

        public bool addOwner(string username)
        {
            domainLayer.Business_Layer.User us = data.getUser(username);
            domainLayer.Business_Layer.Store st = getStore(currentstore.Name);
            if (us != null && st != null)
            {
                return st.AddOwner(us);
            }
            return false;
        }
        public bool removeOwner(string username)
        {
            domainLayer.Business_Layer.User us = data.getUser(username);
            domainLayer.Business_Layer.Store st = getStore(currentstore.Name);
            if (us != null && st != null)
            {
                return st.RemoveOwner(us);
            }
            return false;
        }
        public bool AddPurchase(domainLayer.Business_Layer.Purchase pr)
        {
            domainLayer.Business_Layer.Store st = getStore(currentstore.Name);
            if (st != null)
            {
                return st.AddPurchase(pr);
            }
            return false;
        }
        public bool RemovePurchase(domainLayer.Business_Layer.Purchase pr)
        {
            domainLayer.Business_Layer.Store st = getStore(currentstore.Name);
            if (st != null)
            {
                return st.RemovePurchase(pr);
            }
            return false;
        }

        public bool check_inventory(string barcode)
        {
            domainLayer.Business_Layer.Product pr = getProduct(barcode);
            if (pr != null)
            {
                domainLayer.Business_Layer.Store st = getStore(currentstore.Name);
                if (st != null)
                {
                   int x= st.Checkinventory(pr);
                    return x>0;
                }
            }
            return false;

        }

        internal int getInventory(string barcode)
        {
            return (int)getStore(currentstore.Name).inventory[DataHandler.Instance.GetProduct(barcode)];
        }
    }
}

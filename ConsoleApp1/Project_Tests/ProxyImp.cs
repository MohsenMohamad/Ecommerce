using System.Collections;
using System.Collections.Generic;
using ConsoleApp1;
using ConsoleApp1.domainLayer.Business_Layer;


namespace Project_tests
{
    public class ProxyImp : GenInterface
    {   
        private GenInterface real;

        public void SetReal(GenInterface realInstance)
        {
            real = realInstance;
        }

        public bool InitiateSystem()
        {
            if (real == null) 
                return true;    
            
            return real.InitiateSystem();
        }

        public bool GuestLogin()
        {
            if (real == null)
                return false;
            return real.GuestLogin();
        }

        public bool GuestLogout(User guest)
        {
            if (real == null)
                return true;
            return real.GuestLogout(guest);
        }


        public bool Register(string userName, string password)
        {
            if (real == null)
                return true;
            return real.Register(userName, password);
        }

        public User MemberLogin(string name, string pass)
        {
            if (real == null)
            {
                return null;    
            }
            return real.MemberLogin(name,pass);
        }

        public bool MemberLogout(User member)
        {
            if (real == null)
                return true;
            return real.MemberLogout(member);
        }


        public Store OpenStore(User manager,string policy,string name)
        {
            if (real == null)
                return null;
            return real.OpenStore(manager,policy,name);
        }

        public Store GetStoreInfo(User user, string name)
        {
            if (real == null)
                return null;
            return real.GetStoreInfo(user, name);
        }

        public bool CheckStoreInventory(Store store, Hashtable products)
        {
            if (real == null)
                return true;
            return real.CheckStoreInventory(store, products);
        }

        public bool AddProductToStore(User manager, Store store, Product product, int amount)
        {
            if (real == null)
                return true;
            return real.AddProductToStore(manager, store, product, amount);
        }

        public List<Product> SearchFilter(User user, string sortOption, List<string> filters)
        {
            if (real == null)
                return null;
            return real.SearchFilter(user, sortOption, filters);
        }

        public bool AddProductToCart(User user, Store store, Product product)
        {
            if (real == null)
                return true;
            return real.AddProductToCart(user, store, product);
        }

        public List<Product> GetCartByStore(User user, Store store)
        {
            if (real == null)
                return null;
            return real.GetCartByStore(user, store);
        }
    }
}
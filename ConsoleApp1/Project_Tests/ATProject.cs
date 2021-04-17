using System.Collections;
using System.Collections.Generic;
using ConsoleApp1;
using ConsoleApp1.domainLayer.Business_Layer;

namespace Project_tests
{
    public class ATProject
    {
        private readonly GenInterface service;

        protected ATProject()
        {
            service = Driver.getInstance();
        }

        protected bool InitiateSystem()
        {
            return service.InitiateSystem();
        }

        protected bool Register(string userName, string password)
        {
            return service.Register(userName, password);
        }

        protected User GuestLogin(string guestName, string guestPassword)
        {
            return service.GuestLogin(guestName, guestPassword);
        }

        protected User MemberLogin(string name, string pass)
        {
            return service.MemberLogin(name, pass);
        }

        protected Store OpenStore(User manager, string policy, string name)
        {
            return service.OpenStore(manager, policy, name);
        }

        protected bool AddProductToStore(User manager, Store store, Product product, int amount)
        {
            return service.AddProductToStore(manager, store, product, amount);
        }

        protected Store GetStoreInfo(User user, string name)
        {
            return service.GetStoreInfo(user, name);
        }

        protected bool CheckStoreInventory(Store store, Hashtable products)
        {
            return service.CheckStoreInventory(store, products);
        }

        protected List<Product> SearchFilter(User user, string sortOption, List<string> filters)
        {
            return service.SearchFilter(user, sortOption, filters);
        }
    }
}
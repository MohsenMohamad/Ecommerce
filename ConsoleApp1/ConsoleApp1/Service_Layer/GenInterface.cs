using System.Collections;
using System.Collections.Generic;
using ConsoleApp1.domainLayer.Business_Layer;

namespace ConsoleApp1
{
    public interface GenInterface
    {
        bool InitiateSystem();
        User GuestLogin(string guestName, string guestPassword);
        bool GuestLogout(User guest);
        bool Register(string userName, string password);
        User MemberLogin(string name, string pass);
        bool MemberLogout(User member);
        Store OpenStore(User manager, string policy, string name);
        Store GetStoreInfo(User user, string name);
        bool CheckStoreInventory(Store store, Hashtable products);
        bool AddProductToStore(User manager, Store store, Product product, int amount);
        List<Product> SearchFilter(User user, string sortOption, List<string> filters);
    }
}
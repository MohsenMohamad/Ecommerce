using System.Collections;
using System.Collections.Generic;
using ConsoleApp1.domainLayer.Business_Layer;
using ConsoleApp1.domainLayer.DataAccessLayer;

namespace ConsoleApp1
{
    public interface GenInterface
    {
        bool InitiateSystem();
        bool GuestLogin();
        bool GuestLogout(User guest);
        bool Register(string userName, string password);
        User MemberLogin(string name, string pass);
        bool MemberLogout(User member);
        Store OpenStore(User manager, string policy, string name);
        Store GetStoreInfo(User user, string name);
        bool CheckStoreInventory(Store store, Hashtable products);
        bool AddProductToStore(User manager, Store store, Product product, int amount);
        List<Product> SearchFilter(User user, string sortOption, List<string> filters);
        bool AddProductToCart(User user, Store store, Product product);
        List<Product> GetCartByStore(User user, Store store);
    }
    
}
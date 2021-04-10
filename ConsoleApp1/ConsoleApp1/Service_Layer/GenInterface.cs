using System.Collections.Generic;
using ConsoleApp1.domainLayer.Business_Layer;

namespace ConsoleApp1
{
    public interface GenInterface
    {
        //111111
        //here are the funtions that we have to implement in ServiceLayer
        bool loginUser(string name, string pass);
        bool uc_4_1_addEditRemovePruduct(string storeOwnerName, string storeName ,string productName,string desc,int amount, List<Category> categories);
        
    }
}
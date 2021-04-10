using System.Collections.Generic;
using ConsoleApp1;
using ConsoleApp1.domainLayer.Business_Layer;
using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine.Client;

namespace Tests
{
    public class ProxyImp : GenInterface
    {   //222222
        private GenInterface real;

        public void setReal(GenInterface real )
        {
            this.real = real;
        }
        public bool loginUser(string name, string pass)
        {
            if (real == null)
            {
                return false;    
            }
            return real.loginUser(name,pass);
        }

        public bool uc_4_1_addEditRemovePruduct(string storeOwnerName, string storeName, string productName, string desc, int amount,
            List<Category> categories)
        {
            return real.uc_4_1_addEditRemovePruduct(storeOwnerName,storeName,productName,desc,amount,categories);
        }
    }
}
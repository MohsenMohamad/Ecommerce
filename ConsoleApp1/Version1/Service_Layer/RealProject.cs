using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Version1.DataAccessLayer;
using Version1.domainLayer;
using Version1.domainLayer.UserRoles;
using Version1.LogicLayer;

namespace Version1
{
    public class RealProject
    {
        private readonly Logic logicInstance = new Logic();
        
        public void DeleteStore(string storeName)
        {
            TestsLogic.DeleteStore(storeName);
        }

        public void DeleteUser(string userName)
        {
            TestsLogic.DeleteUser(userName);
        }

        public void DeleteProduct(string productBarcode,string storeName)
        {
            TestsLogic.DeleteProduct(productBarcode, storeName);
        }

        public void ResetStorePolicies(string storeName)
        {
            TestsLogic.ResetStorePolicies(storeName);
        }
        
    }
}
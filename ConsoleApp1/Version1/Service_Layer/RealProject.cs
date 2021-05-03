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
            TestsLogic.DeleteStore(userName);
        }

        public void DeleteProduct(string productBarcode)
        {
            TestsLogic.DeleteProduct(productBarcode);
        }
        
    }
}
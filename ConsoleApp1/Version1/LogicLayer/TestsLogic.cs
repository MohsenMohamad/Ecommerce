using System.Collections.Generic;
using Version1.DataAccessLayer;
using Version1.domainLayer.CompositeDP;

namespace Version1.LogicLayer
{
    public static class TestsLogic
    {

        public static void DeleteStore(string storeName)
        {
            DataHandler.Instance.Stores.TryRemove(storeName, out _);
        }

        public static void DeleteUser(string userName)
        {
            DataHandler.Instance.Users.TryRemove(userName, out _);
        }

        public static void DeleteProduct(string productBarcode, string storeName)
        {
            DataHandler.Instance.RemoveProduct(productBarcode, storeName);
        }

        public static void ResetStorePolicies(string storeName)
        {
            DataHandler.Instance.GetStore(storeName).SetPurchasePolicies(new List<Component>());
        }
    }
}
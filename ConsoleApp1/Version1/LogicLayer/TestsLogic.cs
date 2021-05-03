using Version1.DataAccessLayer;

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

        public static void DeleteProduct(string productBarcode)
        {
            DataHandler.Instance.Products.TryRemove(productBarcode, out _);
        }
    }
}
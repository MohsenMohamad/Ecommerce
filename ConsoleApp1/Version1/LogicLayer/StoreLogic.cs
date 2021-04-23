using Version1.DataAccessLayer;
using Version1.domainLayer;

namespace Version1.LogicLayer
{
    public static class StoreLogic
    {
        private static readonly DataHandler DataHandler = DataHandler.Instance;

        public static bool OpenStore(string managerName ,string storeName, string policy)
        {
            
            var store = new Store(DataHandler.GetUser(managerName), policy, storeName);
            return DataHandler.AddStore(store);
        }
        
        public static bool IsManger(string storeName, string mangerName)
        {
            if (!DataHandler.Stores.ContainsKey(storeName) ||
                !DataHandler.Stores[storeName].Owner.Equals(DataHandler.GetUser(mangerName)))
                return false;
            return true;
        }
    }
}
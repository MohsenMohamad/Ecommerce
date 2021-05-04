using Version1.DataAccessLayer;
using Version1.domainLayer.DataStructures;

namespace Version1.domainLayer.UserRoles
{
    public class SystemAdmin
    {
        private readonly DataHandler data;

        public SystemAdmin()
        {
            data = DataHandler.Instance;
        }

        
        public bool InitSystem()
        {
            return true;
            //return InitSystem();
        }
    }
}
using ServiceLogic.DataAccessLayer;

namespace ServiceLogic.domainLayer.UserRoles
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
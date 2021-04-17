using ConsoleApp1;
using ConsoleApp1.domainLayer.Business_Layer;

namespace Project_tests
{
    public class ATProject
    {
        private readonly GenInterface service;

        protected ATProject()
        {
            service = Driver.getInstance();
        }

        protected bool InitiateSystem()
        {
            return service.InitiateSystem();
        }

        public bool Register(string userName, string password)
        {
            return service.Register(userName, password);
        }

        protected bool MemberLogin(string name, string pass)
        {
            return service.MemberLogin(name, pass);
        }

        protected Store OpenStore(User manager, string policy, string name)
        {
            return service.OpenStore(manager, policy, name);
        }

        protected string GetStoreInfo(User user, string name)
        {
            return service.GetStoreInfo(user, name);
        }
    }
}
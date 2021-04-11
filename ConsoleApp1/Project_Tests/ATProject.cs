using ConsoleApp1;

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
    }
}
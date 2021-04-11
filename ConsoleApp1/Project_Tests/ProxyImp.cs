using ConsoleApp1;


namespace Project_tests
{
    public class ProxyImp : GenInterface
    {   
        private GenInterface real;

        public void SetReal(GenInterface realInstance)
        {
            real = realInstance;
        }

        public bool InitiateSystem()
        {
            if (real == null) 
                return true;    
            
            return real.InitiateSystem();
        }

        public bool GuestLogin()
        {
            throw new System.NotImplementedException();
        }

        public bool GuestLogout()
        {
            throw new System.NotImplementedException();
        }

        public bool Register(string userName, string password)
        {
            if (real == null)
                return true;
            return real.Register(userName, password);
        }

        public bool MemberLogin(string name, string pass)
        {
            if (real == null)
            {
                return true;    
            }
            return real.MemberLogin(name,pass);
        }

        public bool MemberLogout()
        {
            throw new System.NotImplementedException();
        }
    }
}
using ConsoleApp1;
using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine.Client;

namespace Tests
{
    public class ProxyImp : GenInterface
    {   //222222
        private GenInterface real;

        public void setReal(GenInterface real )
        {
            this.real = real;
        }
        public bool loginUser(string name, string pass)
        {
            if (real == null)
            {
                return false;    
            }
            return real.loginUser(name,pass);
        }
        
    }
}
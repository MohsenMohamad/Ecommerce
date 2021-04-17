using ConsoleApp1;

namespace Project_tests
{
    public class Driver
    {
        public static GenInterface getInstance()
        {
            ProxyImp proxy = new ProxyImp();
            //      proxy.setReal(new RealProjectImp());
            return proxy;
        }
    }
}
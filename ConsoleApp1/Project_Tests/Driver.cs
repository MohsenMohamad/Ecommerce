using ConsoleApp1;

namespace Project_tests
{
    public static class Driver
    {
        public static GenInterface getInstance()
        {
            ProxyImp proxy = new ProxyImp();
            //      proxy.SetReal(new RealProject());
            return proxy;
        }
    }
}
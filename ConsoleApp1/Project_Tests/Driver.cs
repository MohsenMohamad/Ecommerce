using Version1;
using Version1.Service_Layer;

namespace Project_tests
{
    public static class Driver
    {
        public static GenInterface getInstance()
        {
            var proxy = new ProxyImp();
            //proxy.SetReal(new RealProject());
            return proxy;
        }
    }
}
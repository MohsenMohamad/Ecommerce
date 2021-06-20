using ServiceLogic.Service_Layer;

namespace TestProject
{
    public static class Driver
    {
        public static GenInterface getInstance()
        {
            var proxy = new ProxyImp();
            proxy.SetReal(new RealProject());
            return proxy;
        }
    }
}
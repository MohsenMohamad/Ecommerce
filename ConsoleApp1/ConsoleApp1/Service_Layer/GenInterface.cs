using ConsoleApp1.domainLayer.Business_Layer;

namespace ConsoleApp1
{
    public interface GenInterface
    {
        bool InitiateSystem();
        bool GuestLogin();
        bool GuestLogout();
        bool Register(string userName, string password);
        bool MemberLogin(string name, string pass);
        bool MemberLogout();
        Store OpenStore(User manager,string policy,string name);
        string GetStoreInfo(User user, string name);

    }
}
using ConsoleApp1.domainLayer.Business_Layer;

namespace ConsoleApp1
{
    public interface GenInterface
    {
        //111111
        //here are the funtions that we have to implement in ServiceLayer


        bool InitiateSystem();
        bool GuestLogin();
        bool GuestLogout();
        bool Register(string userName, string password);
        bool MemberLogin(string name, string pass);
        bool MemberLogout();

    }
}
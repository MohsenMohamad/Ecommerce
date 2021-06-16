using NUnit.Framework;
using Version1.domainLayer.UserRoles;

namespace TestProject.AcceptanceTests
{
    public class Uc43AddNewOwner:ATProject
    {
        private static SystemAdmin admin;
        //private static User user;
        string storeName;
        private string userName ;
        [SetUp]
        public void Setup()
        {
            admin = new SystemAdmin();
            admin.InitSystem();
            userName = "user0";
            //user = new User("user0", "userPass");
            Register(userName,"userPass");
            UserLogin(userName, "userPass");
            
            Register("user1","user1");
            Register("user2","user2");
            Register("user3","user3");
            Register("user4","user4");
            
            storeName = "storeName";
            OpenStore(userName, storeName,"sellPolicy");
        }

        [Test]
        public void Test()
        {
            //happy
            string newOwnerName = "user1";
            
            Assert.True(AddNewOwner("user0", storeName, newOwnerName));
            Assert.True(IsOwner(storeName, newOwnerName));
            
            //bad
            UserLogin(newOwnerName, "user1");
            Assert.False(AddNewOwner("user1", storeName, "user0"));
        }
       
    }
}
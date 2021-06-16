using NUnit.Framework;
using Version1.domainLayer.UserRoles;

namespace TestProject.AcceptanceTests
{
    public class Uc45AddNewManger:ATProject
    {
        private static SystemAdmin admin;
        string storeName;
        string userName;
        [SetUp]
        public void Setup()
        {
            admin = new SystemAdmin();
            admin.InitSystem();
            
            //user = new User("user0", "userPass");
            Register("user0","userPass");
            UserLogin("user0", "userPass");
            Register("user1","user1");
            Register("user2","user2");
            Register("user3", "user3");

            storeName = "myStoreName";
            userName = "user0";
            
            OpenStore(userName, storeName,"sellPolicy");
        }

        [Test]
        public void Test()
        {
            //happy
            string newOwnerName = "user1";
            
            Assert.True(AddNewManger(storeName,userName,  newOwnerName));
            Assert.True(IsManger(storeName, newOwnerName));
            
            //bad
            UserLogin(newOwnerName, "user1");
            Assert.False(AddNewManger(storeName,newOwnerName , userName));
            
        }
       
    }
}
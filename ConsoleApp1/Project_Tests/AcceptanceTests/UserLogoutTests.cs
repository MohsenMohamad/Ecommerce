using System.Linq;
using NUnit.Framework;
using Project_tests;
using Version1;


namespace Project_Tests.AcceptanceTests
{
    public class UserLogoutTests : ATProject
    {
        private const string TestUserName = "LogoutTest";
        private const string TestUserPassword = "LogoutTest";
        
        [OneTimeSetUp]
        public void Setup()
        {
            Register(TestUserName, TestUserPassword);
        }

        [Test]
        public void Happy()
        {
            // login and then logout
            UserLogin(TestUserName, TestUserPassword);
            Assert.True(UserLogout(TestUserName));
        }

        [Test]
        public void Sad()
        {
            // logout does not work
            UserLogin(TestUserName, TestUserPassword);
            Assert.True(UserLogout(TestUserName));
            Assert.False(GetAllLoggedInUsers().ToList().Contains(TestUserName));
        }

        [Test]
        public void Bad()
        {
            // you should be able to login after logging out successfully
            
            UserLogin(TestUserName, TestUserPassword);
            Assert.True(UserLogout(TestUserName));
            Assert.True(UserLogin(TestUserName,TestUserPassword));
            UserLogout(TestUserName);   // not for the test
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            var real = new RealProject();
            
            real.DeleteUser(TestUserName);
        }
        
    }
}
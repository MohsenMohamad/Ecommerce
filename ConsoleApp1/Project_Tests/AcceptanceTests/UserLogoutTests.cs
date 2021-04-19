using NUnit.Framework;
using Project_tests;


namespace Project_Tests.AcceptanceTests
{
    public class UserLogoutTests : ATProject
    {
        private const string TestUserName = "LogoutTest";
        private const string TestUserPassword = "LogoutTest";
        
        [SetUp]
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
            Assert.Null(LoggedInUserName());
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

        [Test]
        public void ShouldFail()
        {
            // 
        }
        
    }
}
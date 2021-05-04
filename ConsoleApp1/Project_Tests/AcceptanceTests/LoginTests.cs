using NUnit.Framework;
using Project_tests;
using Version1;

namespace Project_Tests.AcceptanceTests
{
    public class LoginTests:ATProject
    {
        
        [OneTimeSetUp]
        public void Setup()
        {
            Register("User1", "123");
            Register("User2", "adam");
        }

        [Test]
        public void Happy()
        {
            Assert.True(UserLogin("User1", "123"));
            UserLogout("User1");
            Assert.True(UserLogin("User2", "adam"));
            UserLogout("User2");
        }

        [Test]
        public void Sad()
        {
            // login with the wrong password OR username
            
            Assert.False(UserLogin("User1","321"));
            Assert.False(UserLogin("User2", "123"));
            Assert.False(UserLogin("User1", "adam"));
            Assert.False(UserLogin("User2", "321"));


        }

        [Test]
        public void Bad()
        {
            // a logged in user trying to login again
            
            Assert.True(UserLogin("User1","123"));
            Assert.False(UserLogin("User1","123"));
            UserLogout("User1");
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            var real = new RealProject();
            
            real.DeleteUser("User1");
            real.DeleteUser("User2");
        }
        
    }
}
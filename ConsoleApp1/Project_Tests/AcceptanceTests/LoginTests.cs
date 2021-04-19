using NUnit.Framework;
using Project_tests;

namespace Project_Tests.AcceptanceTests
{
    public class LoginTests:ATProject
    {
        
        [SetUp]
        public void Setup()
        {
            Register("asd", "123");
            Register("adam", "adam");
        }

        [Test]
        public void Happy()
        {
            Assert.True(UserLogin("asd", "123"));
            UserLogout("asd");
            Assert.True(UserLogin("adam", "adam"));
            UserLogout("adam");
        }

        [Test]
        public void Sad()
        {
            // login with the wrong password OR username
            
            Assert.False(UserLogin("asd","321"));
            Assert.False(UserLogin("adam", "123"));
            Assert.False(UserLogin("asd", "adam"));
            Assert.False(UserLogin("adam", "321"));


        }

        [Test]
        public void Bad()
        {
            // a logged in user trying to login again
            
            Assert.True(UserLogin("asd","123"));
            Assert.False(UserLogin("asd","123"));
        }

        
    }
}
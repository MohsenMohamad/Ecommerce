using NUnit.Framework;
using Project_tests;
using Version1;
using Version1.Service_Layer;

namespace Project_Tests.AcceptanceTests
{
    public class OpenStoreTests : ATProject
    {
        private const string TestUserName = "User1";
        private const string TestUserPassword = "Password1";

        [OneTimeSetUp]
        public void Setup()
        {
            Register(TestUserName, TestUserPassword);
            UserLogin(TestUserName, TestUserPassword);
        }

        [Test]
        public void Happy()
        {
            const string storePolicy = "policy";
            const string storeName = "test";
            Assert.True(OpenStore(TestUserName, storeName, storePolicy));
            
        }

        [Test]
        public void Sad()
        {
            const string storePolicy = "policy2";
            const string storeName = "test2";
            Assert.True(OpenStore(TestUserName, storeName, storePolicy));

        }

        [Test]
        public void Bad()
        {
            const string storePolicy = "policy";
            const string storeName = "test3";
            Assert.True(OpenStore(TestUserName, storeName, storePolicy));

            UserLogout(TestUserName);
            var guestId = GuestLogin();
            Assert.NotNull(GetStoreInfo(guestId.ToString(), storeName));
            GuestLogout(guestId);
        }

        [Test]
        public void ShouldFail()
        {
            // guests should not be able to open a store
            
            var guestId = GuestLogin();
            const string storePolicy = "policy";
            const string storeName = "test";
            
            Assert.False(OpenStore(guestId.ToString(), storeName, storePolicy));
            
            GuestLogout(guestId);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            var real = new RealProject();
            
            real.DeleteUser(TestUserName);
            real.DeleteStore("test");
            real.DeleteStore("test2");
            real.DeleteStore("test3");
        }
    }
}
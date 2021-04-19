using NUnit.Framework;
using Project_tests;

namespace Project_Tests.AcceptanceTests
{
    public class OpenStoreTests : ATProject
    {
        private const string TestUserName = "admin";
        private const string TestUserPassword = "admin";

        [SetUp]
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
            Assert.True(OpenStore(TestUserName, storePolicy, storeName));

            // remove the store
        }

        [Test]
        public void Sad()
        {
            const string storePolicy = "policy2";
            const string storeName = "test2";
            Assert.True(OpenStore(TestUserName, storePolicy, storeName));

        }

        [Test]
        public void Bad()
        {
            const string storePolicy = "policy";
            const string storeName = "test";
            Assert.True(OpenStore(TestUserName, storePolicy, storeName));

            UserLogout(TestUserName);
            GuestLogin();
            Assert.NotNull(GetStoreInfo(null, storeName));
            GuestLogout();
            UserLogin(TestUserName, TestUserPassword);
        }

        [Test]
        public void ShouldFail()
        {
            // guests should not be able to open a store
            
            UserLogout(TestUserName);
            GuestLogin();
            const string storePolicy = "policy";
            const string storeName = "test";
            
            Assert.False(OpenStore(null, storePolicy, storeName));
            
            GuestLogout();
        }
    }
}
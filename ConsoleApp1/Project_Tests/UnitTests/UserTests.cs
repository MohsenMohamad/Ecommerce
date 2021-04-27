using Version1.LogicLayer;
using Version1.domainLayer;
using NUnit.Framework;
using Project_tests;

namespace Project_Tests.UnitTests
{
    public class UserTests : ATProject
    {

        private const string TestUserName = "Admin";
        private const string TestUserPassword = "Admin";
        private const string TestStoreName = "AddToCartStoreTest";
        private Product bread, tea;

        [SetUp]
        public void Setup()
        {
            Register(TestUserName, TestUserPassword);
            UserLogin(TestUserName, TestUserPassword);

            OpenStore(TestUserName, "policy", TestStoreName);
            bread = new Product("Bread", "Whole wat bread", "133", 10, null);
            tea = new Product("tea", "black tea", "222", 40, null);
            const int product1Amount = 0;
            const int product2Amount = 4;
            AddProductToStore(TestUserName, TestStoreName, bread.Barcode, product1Amount);
            AddProductToStore(TestUserName, TestStoreName, tea.Barcode, product2Amount);

            UserLogout(TestUserName);

        }

        [Test]
        public void Login()
        {
            if (!Register(TestUserName, TestUserPassword))
            {
                Assert.Fail("fail to regist");
            }
            //User user1 = new User("yara", "123");
            long UserId = UserLogic.GuestLogin();
            if (UserId == -1)
            {
                Assert.Fail("fail to login ");
            }
            Assert.IsTrue(true);
        }


        [Test]
        public void Logout()
        {
            if (!Register(TestUserName, TestUserPassword))
            {
                Assert.Fail("fail to regist");
            }
            long UserId = UserLogic.GuestLogin();
            if (UserId == -1)
            {
                Assert.Fail("fail to login ");
            }
            if (!UserLogic.UserLogout(TestUserName))
            {
                Assert.Fail("fail to logout");
            }
            Assert.IsTrue(true);
        }

        [Test]
        public void Register()
        {
            if (!Register(TestUserName, TestUserPassword))
            {
                Assert.Fail("fail to regist");
            }
            Assert.IsTrue(true);
        }

    }
}

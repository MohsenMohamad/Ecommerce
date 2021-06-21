using NUnit.Framework;
using ServiceLogic.DataAccessLayer.DataStructures;

namespace TestProject.UnitTests
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
            AddProductToStore(TestUserName, TestStoreName, bread.Barcode,bread.Name,bread.Description,bread.Price,"bakes", product1Amount);
            AddProductToStore(TestUserName, TestStoreName, tea.Barcode,tea.Name,tea.Description,tea.Price,"herbal drink" ,product2Amount);

            UserLogout(TestUserName);

        }

        [Test]
        public void Login()
        {

            //User user1 = new User("yara", "123");
            var userId = GuestLogin();
            if (userId == -1)
            {
                Assert.Fail("fail to login ");
            }
            Assert.IsTrue(true);
        }


        [Test]
        public void Logout()
        {

            var userId = GuestLogin();
            if (userId == -1)
            {
                Assert.Fail("fail to login ");
            }
            if (!GuestLogout(userId))
            {
                Assert.Fail("fail to logout");
            }
            Assert.IsTrue(true);
        }
        
    }
}

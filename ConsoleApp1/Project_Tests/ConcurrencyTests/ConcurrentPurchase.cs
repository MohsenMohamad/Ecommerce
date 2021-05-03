using System.Threading.Tasks;
using NUnit.Framework;
using Version1;

namespace Project_tests.ConcurrencyTests
{
    public class ConcurrentPurchase : ATProject
    {

        [OneTimeSetUp]
        public void SetUp()
        {
            AdminInitiateSystem();
            Register("User1", "Password1");
            Register("User2", "Password2");
            Register("User3", "Password3");
        }

        [Test]
        public void Happy()
        {
            var a = AddProductToStore("Adnan", "AdnanStore", "1", 1);
            var result1 = false;
            UserLogin("User1", "Password1");
            AddProductToCart("User1", "AdnanStore", "1", 1);
            var task1 = Task.Factory.StartNew(() => result1 = Purchase("User1","Credit"));
            UserLogout("User1");

            var result2 = false;
            UserLogin("User2", "Password2");
            AddProductToCart("User2", "AdnanStore", "1", 1);
            var task2 = Task.Factory.StartNew(() => result2 = Purchase("User2","Credit"));
            UserLogout("User2");

            Task.WaitAll(task1, task2);
            
            Assert.True(result1 ^ result2);
        }

        [Test]
        public void Sad()
        {
            
        }

        [Test]
        public void Bad()
        {
            
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            var real = new RealProject();
            
            real.DeleteUser("User1");
            real.DeleteUser("User2");
            real.DeleteUser("User3");

        }
    }
}
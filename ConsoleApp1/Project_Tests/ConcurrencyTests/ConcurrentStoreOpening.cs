using System.Threading.Tasks;
using NUnit.Framework;
using Version1;

namespace Project_tests.ConcurrencyTests
{
    public class ConcurrentStoreOpening : ATProject
    {
        [SetUp]
        public void Setup()
        {
            Register("User1", "123");
            Register("User2", "321");
        }
        
        [Test]
        public void Allow()
        {
            // opening two stores with different names by the same user at the same time

            UserLogin("User1", "123");
            
            var result1 = false;
            var result2 = false;

            var task1 = Task.Factory.StartNew(() => result1 = OpenStore("User1","Store1","policy1"));
            var task2 = Task.Factory.StartNew(() => result2 = OpenStore("User1","Store2","policy2"));

            Task.WaitAll(task1, task2);

            UserLogout("User1");
            
            Assert.True(result1 & result2);

        }

        [Test]
        public void Reject()
        {
            // opening two stores by different users with the same store name
            
            var result1 = false;
            UserLogin("User1", "123");
            var task1 = Task.Factory.StartNew(() => result1 = OpenStore("User1","Store3","policy3"));
            UserLogout("User1");

            var result2 = false;
            UserLogin("User2", "321");
            var task2 = Task.Factory.StartNew(() => result2 = OpenStore("User2","Store3","policy4"));
            UserLogout("User2");

            Task.WaitAll(task1, task2);
            
            Assert.True(result1 ^ result2);
        }

        [TearDown]
        public void TearDown()
        {
            var real = new RealProject();
            
            real.DeleteUser("User1");
            real.DeleteUser("User2");
            
            real.DeleteStore("Store1");
            real.DeleteStore("Store2");
            real.DeleteStore("Store3");
        }
    }
}
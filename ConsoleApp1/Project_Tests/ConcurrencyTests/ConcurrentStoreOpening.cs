using System.Threading.Tasks;
using NUnit.Framework;

namespace Project_tests.ConcurrencyTests
{
    public class ConcurrentStoreOpening : ATProject
    {
        [SetUp]
        public void Setup()
        {
            Register("asd", "123");
            Register("dsa", "321");
        }
        
        [Test]
        public void Allow()
        {
            // opening two stores with different names by the same user at the same time

            UserLogin("asd", "123");
            
            var result1 = false;
            var result2 = false;

            var task1 = Task.Factory.StartNew(() => result1 = OpenStore("asd","policy","store1"));
            var task2 = Task.Factory.StartNew(() => result2 = OpenStore("asd","policy","store2"));

            Task.WaitAll(task1, task2);

            UserLogout("asd");
            
            Assert.True(result1 & result2);

        }

        [Test]
        public void Reject()
        {
            // opening two stores by different users with the same store name
            
            var result1 = false;
            UserLogin("asd", "123");
            var task1 = Task.Factory.StartNew(() => result1 = OpenStore("asd","policy","store3"));
            UserLogout("asd");

            var result2 = false;
            UserLogin("dsa", "321");
            var task2 = Task.Factory.StartNew(() => result2 = OpenStore("dsa","policy","store3"));
            UserLogout("dsa");

            Task.WaitAll(task1, task2);
            
            Assert.True(result1 ^ result2);
        }
    }
}
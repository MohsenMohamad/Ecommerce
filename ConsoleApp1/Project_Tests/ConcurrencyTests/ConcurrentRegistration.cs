using System.Threading.Tasks;
using NUnit.Framework;

namespace Project_tests.ConcurrencyTests
{
    public class ConcurrentRegistration : ATProject
    {
        
        [SetUp]
        public void Setup()
        {
           
        }
        
        [Test]
        public void Allow()
        {
            // Register two users with different names on the same time : should accept
            
            var result1 =false;
            var result2 = false;
            
            var task1 = Task.Factory.StartNew(() => result1 = Register("shadi","12345"));
            var task2 = Task.Factory.StartNew(() => result2 = Register("Adnan","1234"));

            Task.WaitAll(task1, task2);

            Assert.True(result1);
            Assert.True(result2);
            
        }

        [Test]
        public void Reject()
        {
            // Register two users with the same name on the same time : should reject one
            
            var result1 =false;
            var result2 = false;
            
            var task1 = Task.Factory.StartNew(() => result1 = Register("omar","54321"));
            var task2 = Task.Factory.StartNew(() => result2 = Register("omar","11111"));

            Task.WaitAll(task1, task2);
            
            Assert.True(result1 ^ result2); // XOR

        }
        
    }
}
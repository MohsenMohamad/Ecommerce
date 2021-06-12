using System.Threading.Tasks;
using NUnit.Framework;
using Version1;
using Version1.Service_Layer;

namespace Project_tests.ConcurrencyTests
{
    public class ConcurrentRegistration : ATProject
    {
        
        [OneTimeSetUp]
        public void Setup()
        {
           
        }
        
        [Test]
        public void Allow()
        {
            // Register two users with different names on the same time : should accept
            
            var result1 =false;
            var result2 = false;
            
            var task1 = Task.Factory.StartNew(() => result1 = Register("User1","12345"));
            var task2 = Task.Factory.StartNew(() => result2 = Register("User2","1234"));

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
            
            var task1 = Task.Factory.StartNew(() => result1 = Register("User3","54321"));
            var task2 = Task.Factory.StartNew(() => result2 = Register("User3","11111"));

            Task.WaitAll(task1, task2);
            
            Assert.True(result1 ^ result2); // XOR

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
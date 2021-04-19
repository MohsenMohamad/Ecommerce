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

            var manager1 = MemberLogin("asd", "123");
            var result1 = false;
            var result2 = false;

            var task1 = Task.Factory.StartNew(() => result1 = OpenStore(manager1,"policy","store1")!=null);
            var task2 = Task.Factory.StartNew(() => result2 = OpenStore(manager1,"policy","store2")!=null);

            Task.WaitAll(task1, task2);
            
            Assert.True(result1 & result2);

        }

        [Test]
        public void Reject()
        {
            // opening two stores by different users with the same store name
            
            var result1 = false;
            var manager1 = MemberLogin("asd", "123");
            var task1 = Task.Factory.StartNew(() => result1 = OpenStore(manager1,"policy","store3")!=null);
            // logout ?

            var result2 = false;
            var manager2 = MemberLogin("dsa", "321");
            var task2 = Task.Factory.StartNew(() => result2 = OpenStore(manager2,"policy","store3")!=null);
            // logout ?

            Task.WaitAll(task1, task2);
            
            Assert.True(result1 ^ result2);
        }
    }
}
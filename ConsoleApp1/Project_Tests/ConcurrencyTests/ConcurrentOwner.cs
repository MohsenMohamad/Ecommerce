using System.Threading.Tasks;
using ConsoleApp1.domainLayer.Business_Layer;
using NUnit.Framework;

namespace Project_tests.ConcurrencyTests
{
    public class ConcurrentOwner : ATProject
    {
    /*
        [SetUp]
        public void Setup()
        {
            Register("manager1", "manager1");
            Register("manager2", "manager2");
            Register("asd", "123");
            Register("dsa", "321");
            UserLogin("manager1", "manager1");
            
            OpenStore("manager1","policy","store6");
            // logout
            UserLogin("manager2", "manager2");
            OpenStore("manager2", "policy", "store7");
            // logout
        }

        [Test]
        public void Allow()
        {
            // make the same user the manager for two stores at the same time

            var result1 = false;
            var result2 = false;
            
            var manager1 = UserLogin("manager1","manager1");
            var task1 = Task.Factory.StartNew(() => result1 = AddNewOwner(manager1, "store6", "asd"));
            // logout
            
            var manager2 = UserLogin("manager2","manager2");
            var task2 = Task.Factory.StartNew(() => result2 = AddNewOwner("manager2","store7" ,"asd"));
            // logout

            Task.WaitAll(task1, task2);
            
            Assert.True(result1 & result2);
        }

        [Test]
        public void Reject()
        {
            // make two different users the manager for the same store
            
            var result1 = false;
            var result2 = false;
            
            var manager1 = UserLogin("manager1","manager1");
            var task1 = Task.Factory.StartNew(() => result1 = AddNewOwner(manager1, store1, "dsa"));
            // logout
            
            var manager2 = UserLogin("manager2","manager2");
            var task2 = Task.Factory.StartNew(() => result2 = AddNewOwner(manager2, store1, "dsa"));
            // logout

            Task.WaitAll(task1, task2);
            
            Assert.True(result1 ^ result2);
            
        }
        */
    }
}
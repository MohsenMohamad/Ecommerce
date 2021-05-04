using System.Threading.Tasks;
using NUnit.Framework;
using Version1;

namespace Project_tests.ConcurrencyTests
{
    public class ConcurrentOwner : ATProject
    {
    
        [OneTimeSetUp]
        public void Setup()
        {
            Register("owner1", "owner1");
            Register("owner2", "owner2");
            Register("owner3", "123");
            Register("owner4", "321");
            UserLogin("owner1", "owner1");
            
            OpenStore("owner1","store1","policy1");
            OpenStore("owner1","store6","policy6");
            AddNewOwner("store1", "owner1", "owner2");
            
            // logout
            UserLogin("owner2", "owner2");
            OpenStore("owner2", "store7", "policy7");
            // logout
        }

        [Test]
        public void Allow()
        {
            // make the same user the owner for two stores at the same time

            var result1 = false;
            var result2 = false;
            
            var owner1 = UserLogin("owner1","owner1");
            var task1 = Task.Factory.StartNew(() => result1 = AddNewOwner("store6", "owner1", "owner3"));
            UserLogout("owner1");
            
            var owner2 = UserLogin("owner2","owner2");
            var task2 = Task.Factory.StartNew(() => result2 = AddNewOwner("store7","owner2" ,"owner3"));
            UserLogout("owner2");

            Task.WaitAll(task1, task2);
            
            Assert.True(result1 & result2);
        }

        [Test]
        public void Reject()
        {
            // make two different users the owner for the same store
            
            var result1 = false;
            var result2 = false;
            
            var owner1 = UserLogin("owner1","owner1");
            var task1 = Task.Factory.StartNew(() => result1 = AddNewOwner("store1", "owner1", "owner3"));
            // logout
            
            var owner2 = UserLogin("owner2","owner2");
            var task2 = Task.Factory.StartNew(() => result2 = AddNewOwner( "store1","owner2", "owner4"));
            // logout

            Task.WaitAll(task1, task2);
            
            Assert.True(result1 & result2);
            Assert.True(IsOwner("store1","owner1"));
            Assert.True(IsOwner("store1","owner2"));
            
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            var real = new RealProject();
            
            // Delete Users
            
            real.DeleteUser("owner1");
            real.DeleteUser("owner2");
            real.DeleteUser("owner3");
            real.DeleteUser("owner4");
            
            // Delete Stores
            
            real.DeleteStore("store1");
            real.DeleteStore("store2");
        }
        
    }
}
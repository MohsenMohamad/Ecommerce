using NUnit.Framework;
using Project_tests;
using Version1.Service_Layer;

namespace Project_Tests.AcceptanceTests
{
    public class NotificationsTests : ATProject
    {

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            AdminInitiateSystem();
        }

        [Test]
        public void CloseStoreNotification()
        {
            OpenStore("adnan", "AdnanStore2", "policy2");
            var before = GetUserNotifications("adnan").Count;
            Assert.True(CloseStore("AdnanStore2","adnan"));
            var after = GetUserNotifications("adnan").Count;
            Assert.True(after == before+1);
            
        }

        [OneTimeTearDown]

        public void OneTimeTearDown()
        {
            var real = new RealProject();
            real.ResetMemory();
        }
        
    }
}
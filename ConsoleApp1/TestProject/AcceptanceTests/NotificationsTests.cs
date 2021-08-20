using NUnit.Framework;
using ServiceLogic.Service_Layer;

namespace TestProject.AcceptanceTests
{
    public class NotificationsTests : ATProject
    {
        
        private const string StoreName = "Test Store";
        private const string OwnerName = "Test User";
        private const string OwnerPassword = "123";
        private const string ManagerName = "Test Manager";
        private const string ManagerPassword = "12345";
        

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Register(OwnerName, OwnerPassword);
            Register(ManagerName, ManagerPassword);
            OpenStore(OwnerName, StoreName, "policy");
            var m =MakeNewManger(StoreName, OwnerName, ManagerName,1);
        }

        [Test]
        public void CloseStoreNotification()
        {
            var ownerNotificationsCount = GetUserNotifications(OwnerName).Count;
            var managerNotificationsCount = GetUserNotifications(ManagerName).Count;
            
            // not delayed
            UserLogin(OwnerName, OwnerPassword);
            Assert.True(CloseStore(StoreName,OwnerName));
            Assert.AreEqual(GetUserNotifications(OwnerName).Count,ownerNotificationsCount+1);
            UserLogout(OwnerName);
            
            // delayed
            var k = GetUserNotifications(ManagerName);
            UserLogin(ManagerName, ManagerPassword);
            Assert.AreEqual(GetUserNotifications(ManagerName).Count,managerNotificationsCount+1);
            UserLogout(ManagerName);

            
        }

        [OneTimeTearDown]

        public void OneTimeTearDown()
        {
            var real = new RealProject();
            real.ResetMemory();
        }
        
    }
}
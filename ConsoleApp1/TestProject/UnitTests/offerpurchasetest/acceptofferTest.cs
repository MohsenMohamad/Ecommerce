using System.Collections.Generic;
using NUnit.Framework;
using Version1.domainLayer.DataStructures;

namespace TestProject.UnitTests.offerpurchasetest
{
    public class acceptofferTest : ATProject
    {
        Product p1 = new Product("1", "milk", "dairy", 10, new List<string>());
        [SetUp]
        public void Setup()
        {
            AdminInitiateSystem();
            Register("mohamad", "mohamad");
            UserLogin("mohamad", "mohamad");
            Recieve_purchase_offer("mohamad", "AdnanStore", "8", "2", 1);

        }

        [Test]
        public void Happy()
        {

            Assert.True(GetUserNotificationsoffer("adnan").Count == 1);
            acceptoffer("2", "8", "mohamad", "AdnanStore", 1, "adnan");
            
            Assert.True(GetUserNotificationsoffer("adnan").Count == 0);
            
            Assert.True(GetUserNotificationsoffer("yara").Count == 1);
            
            Assert.True(GetUserNotificationsoffer("mohamad").Count == 0);
            acceptoffer("2", "8", "mohamad", "AdnanStore", 1, "yara");
            
            Assert.True(GetUserNotifications("yara").Count == 2);
            
            Assert.True(GetUserNotifications("mohamad").Count == 2);
            
            Assert.True(GetUserNotifications("adnan").Count == 2);
        }

        [Test]
        public void Sad()
        {
            
            List<string> lst = GetUserNotificationsoffer("adnan");

            Assert.True(GetUserNotificationsoffer("adnan").Count == 1);

            lst = GetUserNotificationsoffer("yara");
            acceptoffer("2", "8", "mohamad", "AdnanStore", 1, "adnan");
            lst = GetUserNotificationsoffer("yara");
            Assert.False(GetUserNotificationsoffer("adnan").Count == 1);
            
            

        }
    }
}

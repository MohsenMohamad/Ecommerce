using System.Collections.Generic;
using NUnit.Framework;
using Version1.domainLayer.DataStructures;
using Version1.Service_Layer;

namespace TestProject.UnitTests.offerpurchasetest
{
    public class counterofferTest : ATProject
    {
        Product p1 = new Product("1", "milk", "dairy", 10, new List<string>());
        [SetUp]
        public void Setup()
        {
            AdminInitiateSystem();
            Register("mohamad", "mohamad");
            UserLogin("mohamad", "mohamad");
            Recieve_purchase_offer("mohamad", "AdnanStore", "5", "2", 1);

        }

        [Test]
        public void Happy()
        {
            Assert.True(GetUserNotificationsoffer("adnan").Count == 1);
            CounterOffer("2", "8", "mohamad", "AdnanStore", 1, "adnan", "5");
            List<string> lst = GetUserNotificationsoffer("adnan");
            
            Assert.True(GetUserNotificationsoffer("adnan").Count == 0);
            lst = GetUserNotificationsoffer("yara");
            Assert.True(GetUserNotificationsoffer("yara").Count == 0);


            
            lst = GetUserNotificationsoffer("adnan");
            lst = GetUserNotificationsoffer("mohamad");
            Assert.True(GetUserNotificationsoffer("mohamad").Count == 1);

        }

        [Test]
        public void Sad()
        {
            Assert.True(GetUserNotificationsoffer("adnan").Count == 1);
            CounterOffer("2", "8", "mohamad", "AdnanStore", 1, "adnan", "5");
            List<string> lst = GetUserNotificationsoffer("adnan");

            Assert.True(GetUserNotificationsoffer("adnan").Count == 0);
            lst = GetUserNotificationsoffer("yara");
            Assert.True(GetUserNotificationsoffer("yara").Count == 0);



            lst = GetUserNotificationsoffer("adnan");
            lst = GetUserNotificationsoffer("mohamad");
            Assert.False(GetUserNotificationsoffer("mohamad").Count == 0);


        }

        [TearDown]
        public void TearDown()
        {
            new RealProject().ResetMemory();
        }
    }
}

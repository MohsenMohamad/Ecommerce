using System.Collections.Generic;
using NUnit.Framework;
using Version1.domainLayer.DataStructures;
using Version1.Service_Layer;

namespace TestProject.IntegrationTests.offersPurchaseTest
{
    public class offerintegrationTests : ATProject
    {
        Product p1 = new Product("1", "milk", "dairy", 10, new List<string>());
        [SetUp]
        public void Setup()
        {
            AdminInitiateSystem();
            Register("mohamad", "mohamad");
            UserLogin("mohamad", "mohamad");
            

        }

        [Test]
        public void reject_test()
        {

            Assert.True(GetUserNotificationsoffer("adnan").Count == 0);
            Assert.True(GetUserNotificationsoffer("yara").Count == 0);
            Recieve_purchase_offer("mohamad", "AdnanStore", "8", "2", 1);
            Assert.True(GetUserNotificationsoffer("adnan").Count == 1);
            Assert.True(GetUserNotificationsoffer("yara").Count == 1);
            rejectoffer("2", "8", "mohamad", "AdnanStore", 1, "adnan");

            Assert.True(GetUserNotificationsoffer("adnan").Count == 0);

            Assert.True(GetUserNotificationsoffer("yara").Count == 0);

            Assert.True(GetUserNotificationsoffer("mohamad").Count == 0);


            Assert.True(GetUserNotifications("mohamad").Count == 2);

            Assert.True(GetUserNotifications("yara").Count == 2);

            Assert.True(GetUserNotifications("adnan").Count == 2);
        }
        [Test]
        public void accept_test()
        {

            Assert.True(GetUserNotificationsoffer("adnan").Count == 0);
            Assert.True(GetUserNotificationsoffer("yara").Count == 0);
            Recieve_purchase_offer("mohamad", "AdnanStore", "8", "2", 1);
            Assert.True(GetUserNotificationsoffer("adnan").Count == 1);
            Assert.True(GetUserNotificationsoffer("yara").Count == 1);
            acceptoffer("2", "8", "mohamad", "AdnanStore", 1, "adnan");

            Assert.True(GetUserNotificationsoffer("adnan").Count == 0);

            Assert.True(GetUserNotificationsoffer("yara").Count == 1);

            Assert.True(GetUserNotificationsoffer("mohamad").Count == 0);
            acceptoffer("2", "8", "mohamad", "AdnanStore", 1, "yara");
            Assert.True(GetUserNotificationsoffer("adnan").Count == 0);

            Assert.True(GetUserNotificationsoffer("yara").Count == 0);

            Assert.True(GetUserNotificationsoffer("mohamad").Count == 0);

            Assert.True(GetUserNotifications("mohamad").Count == 2);

            Assert.True(GetUserNotifications("yara").Count == 2);

            Assert.True(GetUserNotifications("adnan").Count == 2);
        }

        [Test]
        public void counter_accept_test()
        {

            Assert.True(GetUserNotificationsoffer("adnan").Count == 0);
            Assert.True(GetUserNotificationsoffer("yara").Count == 0);
            Recieve_purchase_offer("mohamad", "AdnanStore", "5", "2", 1);
            Assert.True(GetUserNotificationsoffer("adnan").Count == 1);
            Assert.True(GetUserNotificationsoffer("yara").Count == 1);
            CounterOffer("2", "8", "mohamad", "AdnanStore", 1, "adnan","5");

            Assert.True(GetUserNotificationsoffer("adnan").Count == 0);

            Assert.True(GetUserNotificationsoffer("yara").Count == 0);

            Assert.True(GetUserNotificationsoffer("mohamad").Count == 1);
            acceptoffer("2", "8", "adnan", "AdnanStore", 1, "mohamad");
            Assert.True(GetUserNotificationsoffer("adnan").Count == 0);

            Assert.True(GetUserNotificationsoffer("yara").Count == 0);

            Assert.True(GetUserNotificationsoffer("mohamad").Count == 0);

            Assert.True(GetUserNotifications("mohamad").Count == 2);

            Assert.True(GetUserNotifications("yara").Count == 2);

            Assert.True(GetUserNotifications("adnan").Count == 2);
        }

        [Test]
        public void counter_reject_test()
        {

            Assert.True(GetUserNotificationsoffer("adnan").Count == 0);
            Assert.True(GetUserNotificationsoffer("yara").Count == 0);
            Recieve_purchase_offer("mohamad", "AdnanStore", "5", "2", 1);
            Assert.True(GetUserNotificationsoffer("adnan").Count == 1);
            Assert.True(GetUserNotificationsoffer("yara").Count == 1);
            CounterOffer("2", "8", "mohamad", "AdnanStore", 1, "adnan", "5");

            Assert.True(GetUserNotificationsoffer("adnan").Count == 0);

            Assert.True(GetUserNotificationsoffer("yara").Count == 0);

            Assert.True(GetUserNotificationsoffer("mohamad").Count == 1);
            rejectoffer("2", "8", "adnan", "AdnanStore", 1, "mohamad");
            Assert.True(GetUserNotificationsoffer("adnan").Count == 0);

            Assert.True(GetUserNotificationsoffer("yara").Count == 0);

            Assert.True(GetUserNotificationsoffer("mohamad").Count == 0);

            Assert.True(GetUserNotifications("mohamad").Count == 2);

            Assert.True(GetUserNotifications("yara").Count == 2);

            Assert.True(GetUserNotifications("adnan").Count == 2);
        }

        [TearDown]
        public void TearDown()
        {
            new RealProject().ResetMemory();
        }


    }
}

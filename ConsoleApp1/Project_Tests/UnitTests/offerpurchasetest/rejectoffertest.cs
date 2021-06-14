using NUnit.Framework;
using Project_tests;
using System;
using System.Collections.Generic;
using System.Text;
using Version1.domainLayer.DataStructures;

namespace Project_Tests.UnitTests.offerpurchasetest
{
    public class rejectoffertest : ATProject
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
            rejectoffer("2", "8", "mohamad", "AdnanStore", 1, "adnan");

            Assert.True(GetUserNotificationsoffer("adnan").Count == 0);

            Assert.True(GetUserNotificationsoffer("yara").Count == 0);

            Assert.True(GetUserNotificationsoffer("mohamad").Count == 0);
            

            Assert.True(GetUserNotifications("mohamad").Count == 2);

            Assert.True(GetUserNotifications("yara").Count == 2);

            Assert.True(GetUserNotifications("adnan").Count == 2);
        }

        [Test]
        public void Sad()
        {

            Assert.True(GetUserNotificationsoffer("adnan").Count == 1);
            rejectoffer("2", "8", "mohamad", "AdnanStore", 1, "adnan");

            Assert.False(GetUserNotificationsoffer("adnan").Count == 1);

            Assert.False(GetUserNotificationsoffer("yara").Count == 1);

            Assert.True(GetUserNotificationsoffer("mohamad").Count == 0);




        }
    }
}

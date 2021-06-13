using NUnit.Framework;
using Project_tests;
using System;
using System.Collections.Generic;
using System.Text;
using Version1.domainLayer.DataStructures;

namespace Project_Tests.UnitTests.offerpurchasetest
{
    public class recievepurchaseTest : ATProject
    {
        Product p1 = new Product("1", "milk", "dairy",10, new List<string>());
        [SetUp]
        public void Setup()
        {
            AdminInitiateSystem();
           
            
            Register("mohamad", "mohamad");
            
        }

        [Test]
        public void Happy()
        {
            UserLogin("mohamad", "mohamad");
            
            
            Assert.True(GetUserNotificationsoffer("adnan").Count == 0);
            Recieve_purchase_offer("mohamad", "AdnanStore", "8", "2", 1);
            
            
           
        
            
            Assert.True(GetUserNotificationsoffer("adnan").Count == 1);


        }

        [Test]
        public void Sad()
        {
            UserLogin("mohamad", "mohamad");

            List<string> lst = GetUserNotificationsoffer("adnan");
            Assert.True(GetUserNotificationsoffer("adnan").Count == 1);
            Recieve_purchase_offer("mohamad", "AdnanStore", "8", "2", 1);

            lst = GetUserNotificationsoffer("adnan");



            Assert.False(GetUserNotificationsoffer("adnan").Count == 1);

        }
    }
}

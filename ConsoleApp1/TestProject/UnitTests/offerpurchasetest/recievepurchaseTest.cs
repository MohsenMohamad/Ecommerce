using System.Collections.Generic;
using NUnit.Framework;
using Version1.domainLayer.DataStructures;
using Version1.Service_Layer;

namespace TestProject.UnitTests.offerpurchasetest
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
            Assert.True(lst.Count == 0);
            Recieve_purchase_offer("mohamad", "AdnanStore", "8", "2", 1);
            
            Assert.False(GetUserNotificationsoffer("adnan").Count == 0);

        }

        [TearDown]
        public void TearDown()
        {
            new RealProject().ResetMemory();
        }
    }
}

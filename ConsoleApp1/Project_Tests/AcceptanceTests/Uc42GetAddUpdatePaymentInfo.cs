using System.Collections.Generic;
using Version1.domainLayer;
using Version1.presentationLayer;
using Version1.domainLayer.UserRoles;
using NUnit.Framework;
using Project_tests;

namespace Project_Tests.AcceptanceTests
{
    public class Uc42GetAddUpdatePaymentInfo:ATProject
    {
        private static User user;
        private static Store store;
        private static SystemAdmin admin;

        private static string initialPolicy;
        private static string storeName;
        private List<string> info;
        private List<string> emptyList;
        //private static string selling pol
        [SetUp]
        public void Setup()
        {
            admin = new SystemAdmin();
            initSystem(admin);
            
            //user = new User("user", "userPass");
            Register("user","userPass");
            user = loginGuest("user","userPass");
            
            initialPolicy = "10% sales";
            storeName = "helloMarket";
            emptyList = new List<string>();
            
            OpenStore(user.UserName,initialPolicy, storeName);
            info = new List<string>();
        }

        [Test]
        public void TestGet()
        {
            //check get after init the store policy in the constructor
            Assert.Equals(emptyList, getPaymentInfo(user,storeName));
        }
        
        [Test]
        public void TestAdd()
        {
            string newInfo = "newInfo";
            addPaymentInfo(user, storeName, newInfo);
            
            // happy
            Assert.True(getPaymentInfo(user,storeName).Contains(newInfo));
            //bad
            Assert.False(getPaymentInfo(user,storeName).Contains(""));
        }
        [Test]
        public void TestUpdate()
        {
            string newInfo = "secend new info";
            List<string> newinfo = new List<string>();
            newinfo.Add(newInfo);
            updatePaymentInfo(user, storeName, newinfo);
            
            //happy
            Assert.True(getPaymentInfo(user,storeName).Contains(newInfo));
            
            //bad the old info is not removed
            Assert.False(getPaymentInfo(user,storeName).Contains("newInfo"));
        }
    }
}
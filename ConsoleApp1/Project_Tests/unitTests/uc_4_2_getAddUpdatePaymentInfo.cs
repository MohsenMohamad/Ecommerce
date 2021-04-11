using System.Collections.Generic;
using ConsoleApp1;
using ConsoleApp1.domainLayer.Business_Layer;
using ConsoleApp1.domainLayer.DataAccessLayer;
using NUnit.Framework;

namespace Tests
{
    public class uc_4_2_getAddUpdatePaymentInfo:ATProject
    {
        private static User user;
        private static Guest guest;
        private static Store store;
        private static SystemAdmin admin;

        private static string initialPolicy;
        private static string storeName;
        //private static string selling pol
        [SetUp]
        public void Setup()
        {
            user = new User("user", "userPass");
            guest = new Guest();
            initialPolicy = "10% sales";
            storeName = "helloMarket";
            
            admin = new SystemAdmin();
            initSystem(admin);
            OpenStore(user,initialPolicy, storeName);
        }

        [Test]
        public void Test()
        {
            
            //check get after init the store policy in the constructor
            Assert.Equals(new List<string> (), getPaymentInfo(user,storeName));
            
            List<string> info = new List<string>();
            string newInfo = "newInfo";
            info.Add(newInfo);
            addPaymentInfo(user, storeName, newInfo);
            
            //check add Payment info
            Assert.True(getPaymentInfo(user,storeName).Contains(newInfo));
            info.Add("secend new info");
            
            //check update Payment info
            Assert.Equals(updatePaymentInfo(user,storeName,info),info);
        }
    }
}
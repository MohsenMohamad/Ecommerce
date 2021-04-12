using System.Collections.Generic;
using ConsoleApp1.domainLayer.Business_Layer;
using ConsoleApp1.domainLayer.DataAccessLayer;
using NUnit.Framework;
using Tests;

namespace Project_Tests.unitTests
{
    public class Uc49getInfo:ATProject
    {
        private static SystemAdmin admin;
        private static User ownerUser;
        private static Store store;
        string storeName;
        
        [SetUp]
        public void Setup()
        {
            admin = new SystemAdmin();
            initSystem(admin);
            ownerUser = new User("user0", "userPass");
            signUpGuest("user1","user1");
            storeName = "amazon";
            OpenStore(ownerUser,"sellPolicy", storeName);
            store = getUsersStore(ownerUser,storeName);
        }

        [Test]
        public void Test()
        {
            //happy
            Assert.NotNull(getInfo(ownerUser, store));
        }
       
    }
}
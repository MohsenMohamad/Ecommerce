using System.Collections.Generic;
using ConsoleApp1.domainLayer.Business_Layer;
using ConsoleApp1.domainLayer.DataAccessLayer;
using NUnit.Framework;
using Tests;

namespace Project_Tests.unitTests
{
    public class Uc47DeleteManger:ATProject
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
            signUpGuest("user2","user2");
            signUpGuest("user3", "user3");

            storeName = "ebay";
           
            
            OpenStore(ownerUser,"sellPolicy", storeName);
            store = getUsersStore(ownerUser,storeName);
            
                
        }

        [Test]
        public void Test()
        {
            //happy
            string newMangerName = "user1";
            
            Assert.True(AddNewManger(ownerUser, store, newMangerName));
            Assert.True(IsManger(store, newMangerName));
            //successful delete
            Assert.True(deleteManger(ownerUser, storeName, newMangerName));
            
            
            //bad
            Assert.False(IsManger(store,newMangerName));
        }
       
    }
}
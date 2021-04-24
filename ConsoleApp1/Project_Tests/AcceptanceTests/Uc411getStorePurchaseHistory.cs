using System.Collections.Generic;
using Version1.domainLayer;
using Version1.Service_Layer;
using Version1.domainLayer.UserRoles;
using NUnit.Framework;
using Project_tests;

namespace Project_Tests.AcceptanceTests
{
    public class Uc411getStorePurchaseHistory:ATProject
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
            Register("user1","user1");
            Register("user2","user2");
            storeName = "aliExpress";
            OpenStore(ownerUser.UserName,"sellPolicy", storeName);
            store = getUsersStore(ownerUser,storeName);
        }

        [Test]
        public void Test()
        {
            User buyer1 = loginGuest("user1","user1");
            User buyer2 = loginGuest("user2","user2");
            Product product = new Product("shampoo", "des", "15", new List<Category>());
            addProductsToShop(ownerUser, storeName, product, 13);

            Assert.True(buyProduct(buyer1, store, product, 2));
            Assert.True(buyProduct(buyer2, store, product, 3));
            //happy
            Assert.NotNull(getStorePurchaseHistory(ownerUser, store));
        }
       
    }
}
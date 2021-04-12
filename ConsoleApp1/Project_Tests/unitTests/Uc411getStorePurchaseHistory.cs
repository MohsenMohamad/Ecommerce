using System.Collections.Generic;
using ConsoleApp1.domainLayer.Business_Layer;
using ConsoleApp1.domainLayer.DataAccessLayer;
using NUnit.Framework;
using Tests;

namespace Project_Tests.unitTests
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
            signUpGuest("user1","user1");
            signUpGuest("user2","user2");
            storeName = "aliExpress";
            OpenStore(ownerUser,"sellPolicy", storeName);
            store = getUsersStore(ownerUser,storeName);
        }

        [Test]
        public void Test()
        {
            User buyer1 = loginGuest("user1","user1");
            User buyer2 = loginGuest("user2","user2");
            Product product = new Product("shampoo", "des", 15, new List<Category>());
            addProductsToShop(ownerUser, storeName, product, 13);

            Assert.True(buyProduct(buyer1, store, product, 2));
            Assert.True(buyProduct(buyer2, store, product, 3));
            //happy
            Assert.NotNull(getStorePurchaseHistory(ownerUser, store));
        }
       
    }
}
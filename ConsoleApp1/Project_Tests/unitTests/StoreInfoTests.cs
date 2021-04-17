using System.Collections;
using ConsoleApp1.domainLayer.Business_Layer;
using NUnit.Framework;

namespace Project_tests.unitTests
{
    public class StoreInfoTests : ATProject
    {
        private User guest;
        private Store store;
        private Hashtable storeProducts;

        [SetUp]
        public void Setup()
        {
            var member = new User("member", "member");
        //    member.Login();
            store = OpenStore(member, "policy", "test");
            var product1 = new Product("salt", "kosher salt", 111, null);
            var product2 = new Product("tea", "black tea", 222, null);
            const int product1Amount = 2;
            const int product2Amount = 4;
            storeProducts = new Hashtable();
            storeProducts.Add(product1, product1Amount);
            storeProducts.Add(product2, product2Amount);
            AddProductToStore(member, store, product1, product1Amount);
            AddProductToStore(member, store, product2, product2Amount);
    //        member.logout();

            guest = new User("guest", "guest");
   //         guest.Login();
        }

        [Test]
        public void Happy()
        {
            var testInfo = GetStoreInfo(guest, store.Name);
            Assert.NotNull(testInfo);
            Assert.Equals(testInfo.Name, store.Name);
            Assert.Equals(testInfo.Owner, store.Owner);
            Assert.Equals(testInfo.SellingPolicy, store.SellingPolicy);
            Assert.True(CheckStoreInventory(testInfo, storeProducts));
        }

        [Test]
        public void Sad()
        {
            //
        }

        [Test]
        public void Bad()
        {
        }

        [Test]
        public void ShouldFail()
        {
            var info = GetStoreInfo(guest, "non-existing_store");
            Assert.IsNull(info);
        }
    }
}
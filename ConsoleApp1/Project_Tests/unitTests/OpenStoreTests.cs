using ConsoleApp1.domainLayer.Business_Layer;
using NUnit.Framework;

namespace Project_tests.unitTests
{
    public class OpenStoreTests : ATProject
    {
        private User member;

        [SetUp]
        public void Setup()
        {
            member = new User("admin", "admin");
            member.Login();
        }

        [Test]
        public void Happy()
        {
            const string policy = "policy";
            const string name = "test";
            var store = OpenStore(member, policy, name);
            Assert.NotNull(store);
            Assert.True(store.SellingPolicy.Equals(policy));
            Assert.True(store.Owner.Equals(member));
            Assert.True(store.Name.Equals(name));

            // remove the store
        }

        [Test]
        public void Sad()
        {
            const string policy = "policy2";
            const string name = "test2";
            var store = OpenStore(member, policy, name);
            Assert.NotNull(store);
            Assert.False(!store.SellingPolicy.Equals(policy));
            Assert.False(!store.Owner.Equals(member));
            Assert.False(!store.Name.Equals(name));
        }

        [Test]
        public void Bad()
        {
            const string policy = "policy";
            const string name = "test";
            var store = OpenStore(member, policy, name);
            Assert.NotNull(store);
            Assert.True(store.SellingPolicy.Equals(policy));
            Assert.True(store.Owner.Equals(member));
            Assert.True(store.Name.Equals(name));

            var guest = new User("guest", "guest");
            Assert.NotNull(GetStoreInfo(guest, name));
        }

        [Test]
        public void ShouldFail()
        {
            member.logout();
            const string policy = "policy";
            const string name = "test";
            var store = OpenStore(member, policy, name);
            Assert.IsNull(store);
        }
    }
}
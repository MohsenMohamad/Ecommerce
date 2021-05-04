using NUnit.Framework;
using Project_tests;

namespace Project_Tests.AcceptanceTests
{
    public class GuestLoginTests:ATProject
    {

        [SetUp]
        public void Setup()
        {
           
        }

        [Test]
        public void Happy()
        {
            var id = GuestLogin();
            Assert.True(id > 0);
            GuestLogout(id);
        }

    }
}
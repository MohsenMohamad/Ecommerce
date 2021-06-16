using NUnit.Framework;

namespace TestProject.AcceptanceTests
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
using NUnit.Framework;


namespace Project_tests.unitTests
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
            Assert.True(GuestLogin());
            Assert.False(!GuestLogin());
        }

    }
}
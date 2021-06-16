using NUnit.Framework;

namespace TestProject.AcceptanceTests
{
    public class InitSystemTests : ATProject
    {
        [SetUp]
        public void Setup()
        {
                
        }

        [Test]
        public void Happy()
        {
            Assert.True(InitiateSystem());
        }

        [Test]
        public void Bad()
        {
            Assert.False(InitiateSystem());
        }

        [Test]
        public void Sad()
        {
            Assert.True(InitiateSystem());
            Assert.False(InitiateSystem());
        }
    }
}
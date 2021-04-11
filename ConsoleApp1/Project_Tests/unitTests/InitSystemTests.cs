using NUnit.Framework;
using Project_tests;

namespace Project_tests.unitTests
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
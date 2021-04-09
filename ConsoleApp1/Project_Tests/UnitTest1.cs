using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.AreEqual(3,3);
        }

        [Test]
        public void Test2()
        {
            Assert.AreEqual(2, 3);
        }
    }
}
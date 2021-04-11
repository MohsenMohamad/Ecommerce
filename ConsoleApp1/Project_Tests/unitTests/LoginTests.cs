using NUnit.Framework;
using Project_tests;

namespace Project_tests.unitTests
{
    public class LoginTests:ATProject
    {
        
        [SetUp]
        public void Setup()
        {
                
        }

        [Test]
        public void Happy()
        {
            Assert.True(MemberLogin("asd", "123"));
        }

        [Test]
        public void Bad()
        {
            Assert.False(MemberLogin("asd","321"));
        }

        [Test]
        public void Sad()
        {
            Assert.True(MemberLogin("asd","123"));
            Assert.False(MemberLogin("asd","123"));
        }
        
    }
}
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
            Assert.NotNull(MemberLogin("asd", "123"));
        }

        [Test]
        public void Bad()
        {
            Assert.IsNull(MemberLogin("asd","321"));
        }

        [Test]
        public void Sad()
        {
            Assert.NotNull(MemberLogin("asd","123"));
            Assert.IsNull(MemberLogin("asd","123"));
        }
        
    }
}
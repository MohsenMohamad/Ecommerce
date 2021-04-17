using NUnit.Framework;

namespace Project_tests.unitTests
{
    public class RegisterTests : ATProject
    {
        [SetUp]
        public void Setup()
        {
                
        }

        [Test]
        public void Happy()
        {
            Assert.True(Register("dsa", "321"));
        }

        [Test]
        public void Sad()
        {
            Assert.True(MemberLogin("asd","123"));
            Assert.False(MemberLogin("asd","123"));
        }
        
        [Test]
        public void Bad()
        {
            Assert.False(Register("dsa","321"));
        }
    }
}
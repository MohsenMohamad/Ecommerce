/*using NUnit.Framework;
using Project_tests;

namespace Project_Tests.AcceptanceTests
{
    public class RegisterTests : ATProject
    {
        [SetUp]
        public void Setup()
        {
            Register("adam", "adam");
        }

        [Test]
        public void Happy()
        {
            // register new users
            
            Assert.True(Register("dsa", "321"));
            Assert.True(Register("aaa", "111"));
            Assert.True(Register("bbb", "222"));
        }

        [Test]
        public void Sad()
        {
            // try to register existing users
            
            Assert.True(Register("asd","123"));
            Assert.False(Register("asd","123"));
        }

        public void ShouldFail()
        {
            Assert.False(Register(null, null));
        }

    }
}*/
using NUnit.Framework;
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
            Assert.True(Register("dsa", "321"));
            Assert.True(Register("aaa", "111"));
            Assert.True(Register("bbb", "222"));
        }

        [Test]
        public void Sad()
        {
            Assert.NotNull(MemberLogin("asd","123"));
            Assert.IsNull(MemberLogin("asd","123"));
        }

        public void ShouldFail()
        {
            Assert.False(Register("adam", "adam"));
        }

    }
}
using NUnit.Framework;
using Project_tests;

namespace Project_Tests.AcceptanceTests
{
    public class LoginTests:ATProject
    {
        
        [SetUp]
        public void Setup()
        {
            Register("asd", "123");
            Register("adam", "adam");
        }

        [Test]
        public void Happy()
        {
            Assert.NotNull(MemberLogin("asd", "123"));
            Assert.NotNull(MemberLogin("adam", "adam"));
        }

        [Test]
        public void Bad()
        {
            Assert.IsNull(MemberLogin("asd","321"));
            Assert.IsNull(MemberLogin("adam", "123"));
            Assert.IsNull(MemberLogin("asd", "adam"));
            Assert.IsNull(MemberLogin("adam", "321"));


        }

        [Test]
        public void Sad()
        {
            Assert.NotNull(MemberLogin("asd","123"));
            Assert.IsNull(MemberLogin("asd","123"));
        }

        
    }
}
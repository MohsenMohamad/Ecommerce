using NUnit.Framework;
using Version1.Service_Layer;

namespace TestProject.AcceptanceTests
{
    public class RegisterTests : ATProject
    {
        [OneTimeSetUp]
        public void Setup()
        {
            Register("User1", "adam");
        }

        [Test]
        public void Happy()
        {
            // register new users
            
            Assert.True(Register("User2", "321"));
            Assert.True(Register("User3", "111"));
            Assert.True(Register("User4", "222"));
        }

        [Test]
        public void Sad()
        {
            // try to register existing users
            
            Assert.True(Register("User5","123"));
            Assert.False(Register("User5","123"));
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            var real = new RealProject();
            
            real.DeleteUser("User1");
            real.DeleteUser("User2");
            real.DeleteUser("User3");
            real.DeleteUser("User4");
            real.DeleteUser("User5");

        }

    }
}
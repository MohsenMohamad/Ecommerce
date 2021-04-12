using NUnit.Framework;
using Tests;

namespace Project_Tests.unitTests
{
    public class loginUser:ATProject
    {
        
        [SetUp]
        public void Setup()
        {
                
        }

        [Test]
        public void Test()
        {
            Assert.False(loginUser("shady", "12345"));
        }
        
    }
}
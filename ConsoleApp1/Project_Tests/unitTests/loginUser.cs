using NUnit.Framework;

namespace Tests
{
    public class loginUser:ATProject
    {
        
        [SetUp]
        public void Setup()
        {
                
        }

        [Test]
        public void Test1()
        {
            Assert.False(loginUser("shady", "12345"));
        }
        
    }
}
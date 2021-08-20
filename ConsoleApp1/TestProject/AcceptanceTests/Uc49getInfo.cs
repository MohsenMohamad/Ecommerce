using NUnit.Framework;

namespace TestProject.AcceptanceTests
{
    public class Uc49getInfo:ATProject
    {
        private string ownerUser;
        string storeName;
        
        [SetUp]
        public void Setup()
        {

            //ownerUser = new User("user0", "userPass");
            Register("user0","userPass");
            ownerUser = "user0";
            UserLogin("user0", "userPass");
            
            Register("user1","user1");
            storeName = "ToysRus";
            OpenStore(ownerUser, storeName,"sellPolicy");
        }

        [Test]
        public void Test()
        {
            //happy
            Assert.Null(getInfo(ownerUser, storeName));
        }
       
    }
}
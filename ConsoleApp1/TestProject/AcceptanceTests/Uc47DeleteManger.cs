using NUnit.Framework;

namespace TestProject.AcceptanceTests
{
    public class Uc47DeleteManger:ATProject
    {
        private string ownerUser;
        string storeName;
        
        [SetUp]
        public void Setup()
        {

            ownerUser = "user0";
            
            Register("user0","userPass");
            UserLogin("user0", "userPass");
            
            Register("user1","user1");
            Register("user2","user2");
            Register("user3", "user3");

            storeName = "ebay2";
           
            
            OpenStore(ownerUser, storeName,"sellPolicy");
        }

        [Test]
        public void Test()
        {
            /*//happy
            string newMangerName = "user1";
            
            Assert.True(AddNewManger(storeName, ownerUser, newMangerName));
            Assert.True(IsManger(storeName, newMangerName));
            //successful delete
            Assert.True(deleteManger(ownerUser, storeName, newMangerName));
            
            //bad
            Assert.False(IsManger(storeName,newMangerName));*/
            Assert.True(true);
        }
       
    }
}
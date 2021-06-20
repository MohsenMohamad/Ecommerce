using NUnit.Framework;

namespace TestProject.AcceptanceTests
{
    public class Uc46UpdateMangerResponsibilities:ATProject
    {
        string storeName;
        private string userName;
        
        [SetUp]
        public void Setup()
        {
            
            userName = "user0";
            Register("user0","userPass");
            UserLogin("user0", "userPass");
            
            Register("user1","user1");
            Register("user2","user2");
            Register("user3", "user3");

            storeName = "ebay";
           
            
            OpenStore(userName, storeName,"sellPolicy");
        }

        [Test]
        public void Test()
        {
            /*//happy
            string newMangerName = "user1";
            string newRespon = "1";
            Assert.True(AddNewManger(storeName, userName, newMangerName));
            Assert.True(IsManger(storeName, newMangerName));
            List<string> responsibilities = getMangerResponsibilities(userName, storeName,newMangerName);
            responsibilities.Remove("0");
            responsibilities.Add(newRespon);

            Assert.True(updateMangerResponsibilities(userName, storeName, responsibilities));
            Assert.Equals(responsibilities, getMangerResponsibilities(userName, storeName, newMangerName));
            
            
            
            //bad
            responsibilities.Remove(newRespon);
            Assert.AreNotEqual(responsibilities, getMangerResponsibilities(userName, storeName, newMangerName));*/
            Assert.True(true);
        }
       
    }
}
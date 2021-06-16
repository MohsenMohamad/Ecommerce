using NUnit.Framework;
using Version1.ExternalServices;

namespace TestProject.Version4
{
    public class SupplyServiceTests
    {

        private const int MinimumId = 10000;
        private const int MaximumId = 100000;
        
        [Test]
        public void HandshakeTest()
        {
            var supplyService = new SupplyService();
            Assert.True(supplyService.Handshake());
        }

        [Test]
        public void SupplyTest()
        {
            var supplyService = new SupplyService();
            var transactionId =supplyService.Supply("name","address","city","country",12345);

            var greater = transactionId >= MinimumId;
            var smaller = transactionId <= MaximumId;
            
            Assert.True(greater & smaller);

        }

        [Test]
        public void CancelSupplyTest()
        {
            var supplyService = new SupplyService();
            var transactionId =supplyService.Supply("name","address","city","country",12345);
            Assert.AreEqual(supplyService.CancelSupply(transactionId),1);
        }

        [Test]
        public void FailHandShake()
        {
            //the handshake should not take more than 5 seconds to establish
            // but in this test we will set the limit to 2 seconds and we will delay for 3 seconds
            
            const int delayTime = 3000;
            var supplyService = new SupplyService();
            Assert.False(supplyService.DelayedHandshake(delayTime));
        }

        [Test]
        public void FailCancelTest()
        {
            // transaction id should be between 10000 and 100000
            
            var supplyService = new SupplyService();
            const int illegalId = 100;
        //    Assert.AreEqual(supplyService.CancelSupply(illegalId) , -1);
        
        }
    }
}
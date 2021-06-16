using NUnit.Framework;
using Version1.ExternalServices;

namespace TestProject.Version4
{
    public class FinanceServiceTests
    {
        private const int MinimumId = 10000;
        private const int MaximumId = 100000;
        
        [Test]
        public void HandshakeTest()
        {
            var financeService = new FinanceService();
            Assert.True(financeService.Handshake());
        }

        [Test]
        public void SupplyTest()
        {
            var financeService = new FinanceService();
            var transactionId =financeService.Pay("123",11,2026,"Mohsen",321,207545322);

            var greater = transactionId >= MinimumId;
            var smaller = transactionId <= MaximumId;
            
            Assert.True(greater & smaller);

        }

        [Test]
        public void CancelSupplyTest()
        {
            var financeService = new FinanceService();
            var transactionId =financeService.Pay("123",11,2026,"Mohsen",321,207545322);
            Assert.AreEqual(financeService.CancelPay(transactionId),1);
        }

        [Test]
        public void FailHandShake()
        {
            //the handshake should not take more than 5 seconds to establish
            // but in this test we will set the limit to 2 seconds and we will delay for 3 seconds
            
            const int delayTime = 3000;
            var financeService = new FinanceService();
            Assert.False(financeService.DelayedHandshake(delayTime));
        }

        [Test]
        public void FailCancelTest()
        {
            // transaction id should be between 10000 and 100000
            
            var financeService = new FinanceService();
            const int illegalId = 100;
            Assert.AreEqual(financeService.CancelPay(illegalId) , -1);
        }
    }
}
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
        public void PayTest()
        {
            // ccv 512 should succeed
            var financeService = new FinanceService();
            var transactionId =financeService.Pay("123",11,2026,"Mohsen",512,207545322);

            var greater = transactionId >= MinimumId;
            var smaller = transactionId <= MaximumId;
            
            Assert.True(greater & smaller);

        }

        [Test]
        public void CancelPayTest()
        {
            var financeService = new FinanceService();
            var transactionId =financeService.Pay("123",11,2026,"Mohsen",321,207545322);
            Assert.AreEqual(financeService.CancelPay(transactionId),1);
        }

        [Test]
        public void FailHandShake()
        {
            //the handshake should not take more than 5 seconds to establish

            const int delayTime = 3000;
            var financeService = new FinanceService();
            Assert.False(financeService.DelayedHandshake(delayTime));
        }

        [Test]
        public void FailPayTest()
        {
            // ccv 986 should fail
            
            var financeService = new FinanceService();
            var transactionId =financeService.Pay("123",11,2026,"Mohsen",986,207545322);

            Assert.AreEqual(transactionId , -1);
        }
    }
}
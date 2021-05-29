using System.Collections.Generic;

namespace Version1.ExternalServices
{
    public class MockUpFinanceService : IFinanceServiceAdapter
    {
        public static List<string> log;
        private MockUpFinanceService()
        {
            log = new List<string> {"connected"};
        }

        public static MockUpFinanceService CreateConnection()
        {
            return new MockUpFinanceService();
        }

        public bool AcceptPurchase(double totalPrice,string cardNumber)
        {
            log.Add("accept");
            return true;
        }

        public bool DenyPurchase(double totalPrice, string cardNumber)
        {
            log.Add("deny");
            return false;
        }

        public bool ReturnPayment(double totalPrice,string cardNumber)
        {
            log.Add("return");
            return true;
        }

        public bool Handshake()
        {
            throw new System.NotImplementedException();
        }

        public bool Pay()
        {
            throw new System.NotImplementedException();
        }

        public bool CancelPay()
        {
            throw new System.NotImplementedException();
        }
    }
}
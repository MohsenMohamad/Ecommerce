using System.Collections.Generic;

namespace Version1.ExternalServices
{
    public class ExternalFinanceService
    {
        public static List<string> log;
        private ExternalFinanceService()
        {
            log = new List<string> {"connected"};
        }

        public static ExternalFinanceService CreateConnection()
        {
            return new ExternalFinanceService();
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
    }
}
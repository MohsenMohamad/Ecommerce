namespace Version1.ExternalServices
{
    public class ExternalFinanceService
    {
        private ExternalFinanceService()
        {

        }

        public static ExternalFinanceService createConnection()
        {
            return new ExternalFinanceService();
        }

        public bool acceptPurchase(double total_price,string card_number)
        {
            return true;
        }

        public bool denyPurchase(double total_price, string card_number)
        {
            return false;
        }

        public bool returnPayment(double total_price,string card_number)
        {
            return true;
        }
    }
}
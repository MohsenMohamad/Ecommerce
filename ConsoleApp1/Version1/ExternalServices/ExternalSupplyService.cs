namespace Version1.ExternalServices
{
    public class ExternalSupplyService
    {
        private ExternalSupplyService() { }

        public static ExternalSupplyService createConnection() {
            return new ExternalSupplyService();
        }

        public bool makeOrder()
        {
            return true;
        }

        public bool ErrmakeOrder()
        {
            return false;
        }
    }
}
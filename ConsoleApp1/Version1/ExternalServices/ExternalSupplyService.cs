using System.Collections.Generic;

namespace Version1.ExternalServices
{
    public class ExternalSupplyService
    {
        public static List<string> log;

        private ExternalSupplyService()
        {
            log = new List<string> {"connected"};
        }
        
        
        public static ExternalSupplyService CreateConnection() {
            return new ExternalSupplyService();
        }

        public bool MakeOrder()
        {
            log.Add("make");
            return true;
        }

        public bool ErrorMakeOrder()
        {
            log.Add("err");
            return false;
        }
    }
}
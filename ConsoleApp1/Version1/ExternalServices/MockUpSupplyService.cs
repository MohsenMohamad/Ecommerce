using System.Collections.Generic;

namespace Version1.ExternalServices
{
    public class MockUpSupplyService : ISupplyServiceAdapter
    {
        public static List<string> log;

        private MockUpSupplyService()
        {
            log = new List<string> {"connected"};
        }
        
        
        public static MockUpSupplyService CreateConnection() {
            return new MockUpSupplyService();
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

        public bool Handshake()
        {
            throw new System.NotImplementedException();
        }

        public bool Supply()
        {
            throw new System.NotImplementedException();
        }

        public bool CancelSupply()
        {
            throw new System.NotImplementedException();
        }
    }
}
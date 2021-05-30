using System.Threading.Tasks;
using Flurl.Http;


namespace Version1.ExternalServices
{
    public class SupplyService : ISupplyServiceAdapter
    {
        private const string SystemUrl = "https://cs-bgu-wsep.herokuapp.com/";


        private static async Task<string> AsyncHandShake()
        {
            var systemResponse = await SystemUrl
                .PostUrlEncodedAsync(new { action_type = "handshake" })
                .ReceiveString();
            return systemResponse;
        }
        
        private static async Task<int> AsyncSupply(string nameF,string addressF,string cityF,string countryF,int zipF)
        {
            if (await AsyncHandShake() != "OK") return -2;  // connection error

            var systemResponse = await SystemUrl
                .PostUrlEncodedAsync(new
                {
                    action_type = "supply",
                    name = nameF,
                    address = addressF,
                    city = cityF,
                    country = countryF,
                    zip= zipF
                })
                .ReceiveString();
            return int.Parse(systemResponse);
        }
        
        
        private static async Task<int> AsyncCancelSupply(int transactionId)
        {
            if (await AsyncHandShake() != "OK") return -2;  // connection error

            var systemResponse = await SystemUrl
                .PostUrlEncodedAsync(new
                {
                    action_type = "cancel_supply",
                    transaction_id = transactionId
                                   
                })
                .ReceiveString();
            return int.Parse(systemResponse);
        }
        
        public bool Handshake()
        {
            var task = Task.Run(async () => await AsyncHandShake());
            var result = task.Result;
            return result.Equals("OK");
        }

        public int Supply(string nameF,string addressF,string cityF,string countryF,int zipF)
        {
            var task = Task.Run(async () => await AsyncSupply(nameF,addressF,cityF,countryF,zipF));
            var result = task.Result;
            return result;
        }

        public int CancelSupply(int transactionId)
        {
            var task = Task.Run(async () => await AsyncCancelSupply(transactionId));
            var result = task.Result;
            return result;
        }
    }
}
using System.Threading.Tasks;
using Flurl.Http;


namespace Version1.ExternalServices
{
    public class FinanceService : IFinanceServiceAdapter
    {
        private const string SystemUrl = "https://cs-bgu-wsep.herokuapp.com/";
        private static async Task<string> AsyncHandShake()
        {
            var systemResponse = await SystemUrl
                .PostUrlEncodedAsync(new { action_type = "handshake" })
                .ReceiveString();
            return systemResponse;
        }
        
        private static async Task<int> AsyncPay(string cardNumber, int expMonth, int expYear, string cardHolder, int cardCcv, int holderId)
        {
            if (await AsyncHandShake() != "OK") return -2;  // connection error

            var systemResponse = await SystemUrl
                .PostUrlEncodedAsync(new
                {
                    action_type = "pay",
                    card_number = cardNumber,
                    month = expMonth,
                    year = expYear,
                    holder = cardHolder,
                    ccv = cardCcv,
                    id = holderId
                })
                .ReceiveString();
            return int.Parse(systemResponse);
        }
        
        private static async Task<int> AsyncCancelPay(int transactionId)
        {
            if (await AsyncHandShake() != "OK") return -2;  // connection error

            var systemResponse = await SystemUrl
                .PostUrlEncodedAsync(new
                {
                    action_type = "cancel_pay",
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

        public int Pay(string cardNumber, int expMonth, int expYear, string cardHolder, int cardCcv, int holderId)
        {
            var task = Task.Run(async () => await AsyncPay(cardNumber,expMonth,expYear,cardHolder,cardCcv,holderId));
            var result = task.Result;
            return result;
        }

        public int CancelPay(int transactionId)
        {
            var task = Task.Run(async () => await AsyncCancelPay(transactionId));
            var result = task.Result;
            return result;
        }
    }
}
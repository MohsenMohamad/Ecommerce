using System;
using System.Threading;
using System.Threading.Tasks;
using Flurl.Http;
using System.Configuration;

namespace ServiceLogic.ExternalServices
{
    public class FinanceService : IFinanceServiceAdapter
    {
        private static string SystemUrl = ConfigurationManager.AppSettings["finance"];

        private static async Task<string> AsyncHandShake()
        {
            var systemResponse = await SystemUrl
                .PostUrlEncodedAsync(new {action_type = "handshake"})
                .ReceiveString();
            return systemResponse;
        }

        private static async Task<int> AsyncPay(string cardNumber, int expMonth, int expYear, string cardHolder,
            int cardCcv, int holderId)
        {
            if (await AsyncHandShake() != "OK") return -2; // connection error

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
            if (await AsyncHandShake() != "OK") return -2; // connection error

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
            var task = Task.Run(
                async () => await AsyncPay(cardNumber, expMonth, expYear, cardHolder, cardCcv, holderId));
            try
            {
                var result = task.Result;
                return result;
            }
            catch (AggregateException aggregateException)
            {
                return -1;
            }
        }

        public int CancelPay(int transactionId)
        {
            var task = Task.Run(async () => await AsyncCancelPay(transactionId));
            var result = task.Result;
            return result;
        }
        
        // --------------------------------- for tests ---------------------------------- //
        
        private static async Task<string> DelayedAsyncHandShake(int timeout,CancellationToken token)
        {
            await Task.Delay(timeout,token);
            var systemResponse = await SystemUrl
                .PostUrlEncodedAsync(new {action_type = "handshake"}, cancellationToken: token)
                .ReceiveString();
            return systemResponse;
        }
        
        public bool DelayedHandshake(int delayTime)
        {
            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;
            const int timeout = 2000;

            var task = DelayedAsyncHandShake(delayTime,token);
            var z = Task.Factory.StartNew(async () =>
            {
                try
                {
                    if (await Task.WhenAny(task, Task.Delay(timeout, token)) == task)
                    {
                        // Task completed within timeout.

                        await task;
                        tokenSource.Cancel();
                    }
                    else
                    {
                        // timeout / cancellation logic
                        tokenSource.Cancel();
                    }
                }
                catch (TaskCanceledException canceledException)
                {
                    Console.WriteLine(canceledException.Message);
                }
            }, token);

            Task.WaitAll(z);

            return task.IsCompleted && task.Result.Equals("OK");
            
        }


    }
}
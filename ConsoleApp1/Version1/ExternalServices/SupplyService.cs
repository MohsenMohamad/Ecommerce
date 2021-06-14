using System;
using System.Threading;
using System.Threading.Tasks;
using Flurl.Http;


namespace Version1.ExternalServices
{
    public class SupplyService : ISupplyServiceAdapter
    {
        private const string SystemUrl = "https://cs-bgu-wsep.herokuapp.com/";


        private static async Task<string> AsyncHandShake(CancellationToken token)
        {
            var systemResponse = await SystemUrl
                .PostUrlEncodedAsync(new { action_type = "handshake" }, cancellationToken: token)
                .ReceiveString();
            return systemResponse;
        }
        
        private static async Task<int> AsyncSupply(string nameF,string addressF,string cityF,string countryF,int zipF)
        {
            if (await AsyncHandShake(new CancellationTokenSource().Token) != "OK") return -2;  // connection error

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
            if (await AsyncHandShake(new CancellationTokenSource().Token) != "OK") return -2;  // connection error

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
            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;
            const int timeout = 2000;

            var task = AsyncHandShake(token);
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
            
            
            
            /*
            var task = Task.Run(async () => await AsyncHandShake());
            var result = task.Result;
            return result.Equals("OK");
            */
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
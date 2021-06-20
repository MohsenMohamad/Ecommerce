namespace ServiceLogic.ExternalServices
{
    public interface IFinanceServiceAdapter
    {
        bool Handshake();
        int Pay(string cardNumber, int expMonth, int expYear, string cardHolder, int cardCcv, int holderId);
        int CancelPay(int transactionId);
    }
}
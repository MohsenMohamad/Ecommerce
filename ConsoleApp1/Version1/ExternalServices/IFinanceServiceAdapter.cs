namespace Version1.ExternalServices
{
    public interface IFinanceServiceAdapter
    {
        bool Handshake();
        bool Pay();
        bool CancelPay();
    }
}
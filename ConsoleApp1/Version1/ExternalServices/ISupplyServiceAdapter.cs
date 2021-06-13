namespace Version1.ExternalServices
{
    public interface ISupplyServiceAdapter
    {
        bool Handshake();
        int Supply(string nameF,string addressF,string cityF,string countryF,int zipF);
        int CancelSupply(int transactionId);
    }
}
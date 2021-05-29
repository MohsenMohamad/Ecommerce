namespace Version1.ExternalServices
{
    public interface ISupplyServiceAdapter
    {
        bool Handshake();
        bool Supply();
        bool CancelSupply();
    }
}
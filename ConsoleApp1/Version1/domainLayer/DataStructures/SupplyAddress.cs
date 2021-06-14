namespace Version1.domainLayer.DataStructures
{
    public class SupplyAddress
    {
        public readonly string NameF;
        public readonly string AddressF;
        public readonly string CityF;
        public readonly string CountryF;
        public readonly int ZipF;

        public SupplyAddress(string nameF, string addressF, string cityF, string countryF, int zipF)
        {
            NameF = nameF;
            AddressF = addressF;
            CityF = cityF;
            CountryF = countryF;
            ZipF = zipF;
        }
    }
}
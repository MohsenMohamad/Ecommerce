namespace Version1.DataAccessLayer
{
    public class DAProduct
    {
        public int Barcode { get; }
        public string Name { get ; }
        public string Description { get ; }

        public DAProduct(string name, string desc, int barcode)
        {
            this.Description = desc;
            this.Barcode = barcode;
            this.Name = name;
           
        }
    }
}

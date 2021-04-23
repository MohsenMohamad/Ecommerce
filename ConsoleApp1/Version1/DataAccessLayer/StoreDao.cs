namespace Version1.DataAccessLayer
{
    public class StoreDao
    {
        private string name;
        public StoreDao(string name)
        {
            this.name = name;

        }
        public string Name { get; set; }


    }
}

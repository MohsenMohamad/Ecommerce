namespace Version1.domainLayer.DataStructures
{
    public class Review
    {
        public string Username { get; }
        public string Reviews { get; set; }
        public Review(string user,string desc)
        {
            this.Username = user;
            this.Reviews = desc;
        }

    }
}

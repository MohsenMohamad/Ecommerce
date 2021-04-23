namespace Version1.DataAccessLayer
{
    public class ReviewDao
    {
        public string Username { get; }
        public string Reviews { get; set; }
        public ReviewDao(string user,string desc)
        {
            this.Username = user;
            this.Reviews = desc;
        }

    }
}

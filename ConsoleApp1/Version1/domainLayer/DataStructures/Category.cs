namespace Version1.domainLayer.DataStructures
{
    public class Category
    {
        public string name;
        public Category(string name)
        {
            this.name = name;
        }
        public string Name { get => name; }
        public override bool Equals(object obj)
        {
            return obj is Category && ((Category)obj).Name.CompareTo(Name) == 0;
        }
        public override string ToString()
        {
            return "Category name: " + Name;
        }
    }
}
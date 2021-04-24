using System.Collections.Generic;

namespace Version1.domainLayer
{
    public class Product
    {
        private string name,description;
        private string barcode;
        private List<Category> categories;
        private double price;
        public Product(string name,string desc,string barcode, List<Category> categories,int price)
        {
            this.description = desc;
            this.barcode = barcode;
            this.name = name;
            this.categories = categories;
            this.price = price;
        }
       //getters
        public string Barcode { get => barcode;  }
        public string Name { get => name; }
        public string Description { get => description; }
        public List<Category> Categories { get => categories; }
        public double Price { get => price;  }
        // functions
        public bool AddCategory(Category cat)
        {
            if (Categories.Contains(cat))
            {
                Categories.Add(cat);
                return true;
            }
            else return false;
        }
        public bool RemoveCategory(Category cat)
        {
            if (Categories.Contains(cat))
            {
                Categories.Remove(cat);
                return true;
            }
            else return false;
        }
        public override bool Equals(object obj)
        {
            if (obj is Product)
            {
                Product cat = (Product)obj;
                return cat.Description.CompareTo(Description) == 0 && cat.Name.CompareTo(Name) == 0 && cat.Barcode == Barcode && cat.Categories.Equals(Categories);
            }
            else return false;
        }
        public override string ToString()
        {
            string output = "";
            output += "details of " + name + ":/n";
            output += "Bar Code: " + Barcode + "/t Description: " + Description+"/n";
            for (int i = 0; i < Categories.Count; i++)
            {
                output += "/n" + Categories[i].ToString();
            }

            return output;
        }
    }
}

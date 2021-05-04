using System.Collections.Generic;

namespace Version1.domainLayer.DataStructures
{
    public class Product
    {
        private string name,description;
        private string barcode;
        private List<string> categories;
        private double price;
        
        public Product(string name,string desc,string barcode,double price, List<string> categories)
        {
            description = desc;
            this.barcode = barcode;
            this.name = name;
            this.categories = categories;
            this.price = price;
        }
       //getters
        public string Barcode { get => barcode;  }
        public string Name { get => name; }
        public string Description { get => description; }
        public List<string> Categories { get => categories; }
        public double Price { get => price;  }
        // functions
        public bool AddCategory(string cat)
        {
            if (Categories.Contains(cat))
            {
                Categories.Add(cat);
                return true;
            }
            
            return false;
        }
        public bool RemoveCategory(string cat)
        {
            if (Categories.Contains(cat))
            {
                Categories.Remove(cat);
                return true;
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

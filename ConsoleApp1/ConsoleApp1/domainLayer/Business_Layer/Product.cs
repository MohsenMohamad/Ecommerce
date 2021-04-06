using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.domainLayer.Business_Layer
{
    class Product
    {
        private string name,description;
        private int barcode;
        private List<Category> categories;
        public Product(string name,string desc,int barcode, List<Category> categories)
        {
            this.description = desc;
            this.barcode = barcode;
            this.name = name;
            this.categories = categories;
        }
       //getters
        public int Barcode { get => barcode;  }
        public string Name { get => name; }
        public string Description { get => description; }
        public List<Category> Categories { get => categories; }
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

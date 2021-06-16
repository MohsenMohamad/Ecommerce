using System.Collections.Generic;
using Version1.domainLayer.DiscountPolicies;


namespace Version1.domainLayer.DataStructures
{
    public class Product
    {
        public string name,description;
        public string barcode;
        public List<string> categories{ get; set; }
        public  double price { get; set; }
        public DtoPolicy DiscountPolicy { get; set; }


        public Product(string barcode,string name,string desc,double price, List<string> categories)
        {
            description = desc;
            this.barcode = barcode;
            this.name = name;
            this.categories = categories;
            this.price = price;
            this.DiscountPolicy = new DtoPolicy();

        }
        //getters
        public string Barcode { get => barcode;  }
        public string Name { get => name; }
        public string Description { get => description; }
        public List<string> Categories { get => categories; }
        public double Price { get => price;  }
        
        

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

        
        /*internal int addConditionalDiscount_toItem(int percentage, string condition)
        {
            int res;

            try { Condition.Parse(condition); }
            catch (Exception e) { return -13; }
            DTO_Policies p = new DTO_Policies();
            if ((res = p.SetConditional(percentage, condition)) < 0)
                return res;

            *//*if ((res = db.Add_Discount_Policy(p)) < 0)
                return res;*//*
            discountPolicy.productBarCode = barcode;
            discountPolicy.discount_description = string.Format("condition discount {0}% off ", percentage);
            Condition cond = Condition.Parse(condition);

            discountPolicy.discount_description += string.Format("[{0}]\n", cond.get_description());

            *//*db.update_item_in_shop(iis);*//*
            return res;
        }*/
        
    }
}

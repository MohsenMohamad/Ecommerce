using System;
using System.Collections.Generic;
using System.Linq;
using Version1.domainLayer.DataStructures;

namespace Version1.domainLayer.DiscountPolicies
{
    //A
    public class Buy_a_of_X : Condition
    {
        private int a;
        private string barcode;//item_in_shop id
        public Buy_a_of_X(int a, string barcode)
        {
            this.a = a;
            this.barcode = barcode;
        }
        public Buy_a_of_X(string s)
        {
            try
            {
                int[] _params = s.Split(';').Select(element => int.Parse(element)).ToArray();
                this.a = _params[0];
                this.barcode = _params[1].ToString();

            }
            catch
            {
                throw new Exception("bad format");
            }

        }

        public override bool evaluate(ShoppingCart cart, User user, Product item, int amount_of_item)
        {
            int counter = 0;
            // <storeName,ShoppingBasket>
            foreach (KeyValuePair<string, ShoppingBasket> entry in cart.shoppingBaskets)
            {
                foreach (KeyValuePair<string, int> product in entry.Value.Products)
                {
                    if (product.Key == barcode)
                        counter += product.Value;
                }

            }

            if (counter >= a)
            {
                return true;
            }
            return false;
        }

        public override string get_description()
        {
            return string.Format("buy {0} of the item [{1}]", a, barcode);
        }
    }
}
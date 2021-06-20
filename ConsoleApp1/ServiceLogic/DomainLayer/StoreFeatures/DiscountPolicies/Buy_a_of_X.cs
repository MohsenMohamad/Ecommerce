using System;
using System.Collections.Generic;
using System.Linq;
using ServiceLogic.DataAccessLayer.DataStructures;

namespace ServiceLogic.DomainLayer.StoreFeatures.DiscountPolicies
{
    //A
    public class BuyAOfX : Condition
    {
        private int a;
        private string barcode;
        
        public BuyAOfX(int a, string barcode)
        {
            this.a = a;
            this.barcode = barcode;
        }
        public BuyAOfX(string s)
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
            return $"buy {a} of the item [{barcode}]";
        }
    }
}
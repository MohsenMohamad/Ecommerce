﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using Version1.DataAccessLayer;
using Version1.domainLayer.DataStructures;

namespace Version1.domainLayer.DiscountPolicies
{
    public class Spend_More_Than_Y : Condition   //B
    {

        private int threshold;

        public Spend_More_Than_Y(int threshold)
        {
            this.threshold = threshold;
        }
        public Spend_More_Than_Y(string threshold)
        {
            if (!int.TryParse(threshold, out this.threshold))
            {
                throw new Exception("bad format");
            }
        }
        public override bool evaluate(ShoppingCart cart, User user, Product item, int amount_of_item)
        {
            try
            {
                double total = 0;
                // <storeName,ShoppingBasket>
                foreach (KeyValuePair<string, ShoppingBasket> entry in cart.shoppingBaskets)
                {
                    foreach (KeyValuePair<string, int> product in entry.Value.Products)
                    {
                        if (product.Key != item.barcode)
                        {
                            total += DataHandler.Instance.GetProduct(product.Key,entry.Key).price * product.Value;
                        }

                    }

                }


                return total >= threshold;
            }
            catch
            {
                throw new Exception("Unknown iis id in cart");
            }
        }

        public override string get_description()
        {
            return string.Format("buy more than {0}", threshold);
        }
    }
}
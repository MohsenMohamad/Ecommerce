using System;
using Version1.domainLayer.CompositeDP;
using Version1.domainLayer.DataStructures;

namespace Version1.domainLayer.StorePolicies
{
    public class MaxAmountPolicy : Component
    {
        private readonly int maxAmount;
        private readonly string barcode;

        public MaxAmountPolicy(string barcode, int maxAmount)
        {
            this.barcode = barcode;
            this.maxAmount = maxAmount;
        }
        
        public override bool Validate(ShoppingBasket shoppingBasket)
        {
            foreach (var productSet in shoppingBasket.Products)
            {
                if(productSet.Key.Equals(barcode) && productSet.Value > maxAmount)
                    return false;
            }

            return true;
        }
    }
}
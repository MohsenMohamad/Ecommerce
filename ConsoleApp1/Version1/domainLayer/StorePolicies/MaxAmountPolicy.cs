using System;
using Version1.domainLayer.DataStructures;

namespace Version1.domainLayer.StorePolicies
{
    public class MaxAmountPolicy : IPurchasePolicy
    {
        private int maxAmount;

        public MaxAmountPolicy(int maxAmount)
        {
            this.maxAmount = maxAmount;
        }
        
        public bool Validate(ShoppingBasket shoppingBasket)
        {
            foreach (var amount in shoppingBasket.Products.Values)
            {
                if (amount > maxAmount) return false;
            }

            return true;
        }
    }
}
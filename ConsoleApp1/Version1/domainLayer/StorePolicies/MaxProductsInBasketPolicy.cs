using Version1.domainLayer.CompositeDP;
using Version1.domainLayer.DataStructures;

namespace Version1.domainLayer.StorePolicies
{
    public class MaxProductsInBasketPolicy : Component
    {

        private int amount;

        public MaxProductsInBasketPolicy(int amount)
        {
            this.amount = amount;
        }
        
        public override bool Validate(ShoppingBasket shoppingBasket)
        {
            return shoppingBasket.Products.Count <= amount;
        }

        public void SetAmount(int newAmount)
        {
            amount = newAmount;
        }
    }
}
using ServiceLogic.DataAccessLayer.DataStructures;
using ServiceLogic.DomainLayer.StoreFeatures.StorePolicies.CompositeDP;

namespace ServiceLogic.DomainLayer.StoreFeatures.StorePolicies
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
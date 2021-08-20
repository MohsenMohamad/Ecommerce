using ServiceLogic.DataAccessLayer.DataStructures;

namespace ServiceLogic.DomainLayer.StoreFeatures.DiscountPolicies
{

    public class SimplePolicy : DiscountPolicy
    {
        int percentage;

        public SimplePolicy( int percentage)
        {
            this.percentage = percentage;
        }

        public override double GetTotal(ShoppingCart cart, User user, Product product, int amount_of_item)
        {
            return (double)percentage;
        }
    }
}
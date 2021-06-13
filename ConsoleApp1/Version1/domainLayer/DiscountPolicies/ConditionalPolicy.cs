using Version1.domainLayer.DataStructures;

namespace Version1.domainLayer.DiscountPolicies
{
    public class ConditionalPolicy : DiscountPolicy
    {
        private Condition condition;
        
        private int percentage;
        
        public ConditionalPolicy(string cond, int percentage)
        {
            this.percentage = percentage;
            condition = Condition.Parse(cond);

        }

        public override double GetTotal(ShoppingCart cart, User user, Product item, int amount_of_item)
        {
            if (condition.evaluate(cart, user, item, amount_of_item))
                return percentage;
            
            return 0;
        }
    }
}
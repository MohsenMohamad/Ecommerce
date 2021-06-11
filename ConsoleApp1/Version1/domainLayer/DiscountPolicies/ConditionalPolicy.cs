using Version1.domainLayer.DataStructures;

namespace Version1.domainLayer.DiscountPolicies
{
    public class ConditionalPolicy : DiscountPolicy
    {
        Condition condition;
        int percentage;
        public ConditionalPolicy(string cond, int percentage)
        {
            this.percentage = percentage;
            condition = Condition.Parse(cond);

        }

        public override double getTotal(ShoppingCart cart, User user, Product item, int amount_of_item)
        {
            double res = 0;
            bool good = condition.evaluate(cart, user, item, amount_of_item);
            if (good)
            {
                res = percentage;
            }
            else
            {
                res = 0;
            }
            return res;
        }
    }
}
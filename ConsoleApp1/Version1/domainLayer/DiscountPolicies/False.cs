using Version1.domainLayer.DataStructures;

namespace Version1.domainLayer.DiscountPolicies
{
    public class False : Condition

    {
        public override bool evaluate(ShoppingCart cart, User user, Product item, int amount_of_item)
        {
            return false;
        }
        public override string get_description()
        {
            return "false";
        }

    }
}
using Version1.domainLayer.DataStructures;

namespace Version1.domainLayer.DiscountPolicies
{
    public class True : Condition
    {
        public override bool evaluate(ShoppingCart cart, User user, Product item, int amount_of_item)
        {
            return true;
        }
        public override string get_description()
        {
            return "true always";
        }
    }
}
using Version1.DataAccessLayer;
using Version1.domainLayer.DataStructures;

namespace Version1.domainLayer.DiscountPolicies
{

    public abstract class DiscountPolicy
    {
        public abstract double getTotal(ShoppingCart cart, User user, Product item, int amount_of_item);

        public static DiscountPolicy GetPolicy(DTO_Policies type)
        {
            switch (type.Type)
            {
                case 0://no Discount policy
                    return null;
                case 1://normal simple discount policy
                    return new SimplePolicy(type.fromdate, type.todate, type.percentage, type.bound);
                case 2://conditional policy
                    return new ConditionalPolicy(type.conditoin, type.conditoin_percentage);
                default:
                    return null;
            }
        }


    }
}
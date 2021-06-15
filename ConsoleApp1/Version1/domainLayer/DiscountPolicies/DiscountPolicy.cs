using Version1.DataAccessLayer;
using Version1.domainLayer.DataStructures;

namespace Version1.domainLayer.DiscountPolicies
{

    public abstract class DiscountPolicy
    {
        public abstract double getTotal(ShoppingCart cart, User user, Product item, int amount_of_item);

        public static DiscountPolicy GetPolicy(DtoPolicy type)
        {
            switch (type.TypeOfPolicy)
            {
                case 0://no Discount policy
                    return null;
                case 1://normal simple discount policy
                    return new SimplePolicy(type.Percentage);
                case 2://conditional policy
                    return new ConditionalPolicy(type.Conditoin, type.ConditoinPercentage);
                default:
                    return null;
            }
        }


    }
}
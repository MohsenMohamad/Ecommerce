using Version1.DataAccessLayer;
using Version1.domainLayer.DataStructures;

namespace Version1.domainLayer.DiscountPolicies
{

    public abstract class DiscountPolicy
    {
        public abstract double GetTotal(ShoppingCart cart, User user, Product item, int amount_of_item);

        public static DiscountPolicy GetPolicy(DtoPolicy type)
        {
            if (type.TypeOfPolicy == 0)
                return null;
            else if (type.TypeOfPolicy == 1)
                return new SimplePolicy(type.Percentage);
            else if (type.TypeOfPolicy == 2)
                return new ConditionalPolicy(type.Conditoin, type.ConditoinPercentage);
            else
                return null;
        }


    }
}
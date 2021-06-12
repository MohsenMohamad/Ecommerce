using System;
using Version1.domainLayer.DataStructures;

namespace Version1.domainLayer.DiscountPolicies
{

    public class SimplePolicy : DiscountPolicy
    {
        //private IDB db = DB_Singelton.get_db();
        int percentage;

        public SimplePolicy( int percentage)
        {
            this.percentage = percentage;
        }

        public override double getTotal(ShoppingCart cart, User user, Product product, int amount_of_item)
        {
            return (double)percentage;
        }
    }
}
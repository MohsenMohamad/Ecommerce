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

            double a = 0;
            a = ((product.Price * (100 - percentage)) / 100) * amount_of_item;
            return a;

        }
    }
}
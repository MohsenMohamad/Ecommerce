using System;
using Version1.domainLayer.DataStructures;

namespace Version1.domainLayer.DiscountPolicies
{

    public class SimplePolicy : DiscountPolicy
    {
        //private IDB db = DB_Singelton.get_db();
        DateTime from;
        DateTime to;
        int percentage;
        bool bound;
        public SimplePolicy(string from, string to, int percentage, bool bound)
        {
            if (bound)
            {
                this.from = DateTime.Parse(from);
                this.to = DateTime.Parse(to);
            }
            this.percentage = percentage;
            this.bound = bound;
        }

        public override double getTotal(ShoppingCart cart, User user, Product product, int amount_of_item)
        {
            DateTime now = DateTime.Now;
            double a = 0;
            if (!bound || (DateTime.Compare(from, now) <= 0 && DateTime.Compare(now, to) <= 0))
                a = ((product.Price * (100 - percentage)) / 100) * amount_of_item;
            else
                a = product.price * amount_of_item;
            return a;

        }
    }
}
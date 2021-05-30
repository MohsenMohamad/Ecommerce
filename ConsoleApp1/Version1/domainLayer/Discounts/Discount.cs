using System.Collections.Generic;
using Version1.domainLayer.DataStructures;

namespace Version1.domainLayer.Discounts
{
    public abstract class Discount
    {
        private string description;
        
        private float perC;
        
        protected Discount(float dis)
        {
            perC = dis;
        }

        public abstract double NewPrice(ShoppingBasket shoppingBasket);
    }
}
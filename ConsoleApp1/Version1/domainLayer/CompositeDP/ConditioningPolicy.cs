using System;
using Version1.domainLayer.DataStructures;

namespace Version1.domainLayer.CompositeDP
{
    public class ConditioningPolicy : Composite
    {
        
        public override bool Validate(ShoppingBasket shoppingBasket)
        {
            return true;
        }
    }
}
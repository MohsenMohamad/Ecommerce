using System;
using Version1.domainLayer.DataStructures;

namespace Version1.domainLayer.CompositeDP
{
    public class ConditioningPolicy : Composite
    {
        private Component conditions;
        private Component restrictedPolicies;
        
        
        public override bool Validate(ShoppingBasket shoppingBasket)
        {
            return !BasketIsRestricted(shoppingBasket) || conditions.Validate(shoppingBasket);
        }

        public void AddCondition(Component condition)
        {
            if (conditions == null)
                conditions = condition;
            else conditions.Add(condition);
        }

        public void AddRestrictedPolicy(Component policy)
        {
            if (restrictedPolicies == null)
                restrictedPolicies = policy;
            else restrictedPolicies.Add(policy);
        }

        private bool BasketIsRestricted(ShoppingBasket shoppingBasket)
        {
            return !restrictedPolicies.Validate(shoppingBasket);
        }
    }
    
}
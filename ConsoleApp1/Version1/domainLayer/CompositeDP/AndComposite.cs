using Version1.domainLayer.DataStructures;

namespace Version1.domainLayer.CompositeDP
{
    public class AndComposite : Composite
    {
        public override bool Validate(ShoppingBasket shoppingBasket)
        {
            var result = true;
            foreach (var policy in _children)
            {
                result &= policy.Validate(shoppingBasket);
                if (!result) return false;
            }

            return true;
        }
    }
}
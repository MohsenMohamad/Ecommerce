using Version1.domainLayer.DataStructures;

namespace Version1.domainLayer.CompositeDP
{
    public class OrComposite : Composite
    {
        public override bool Validate(ShoppingBasket shoppingBasket)
        {
            var result = false;
            foreach (var policy in _children)
            {
                result |= policy.Validate(shoppingBasket);
                if (result) return true;
            }

            return false;
        }
    }
}
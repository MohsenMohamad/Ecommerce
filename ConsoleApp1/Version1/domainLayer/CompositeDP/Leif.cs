using Version1.domainLayer.DataStructures;

namespace Version1.domainLayer.CompositeDP
{
    
    public class Leif : Component
    {
        
        // The Leaf class represents the end objects of a composition. A leaf can't
        // have any children.
        //
        // Usually, it's the Leaf objects that do the actual work, whereas Composite
        // objects only delegate to their sub-components.
        
        
        public override bool Validate(ShoppingBasket shoppingBasket)
        {
            return false;
        }

        public override bool IsComposite()
        {
            return false;
        }
    }
}
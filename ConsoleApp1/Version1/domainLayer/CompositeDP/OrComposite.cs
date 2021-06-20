using System;
using System.Runtime.Serialization;
using Version1.domainLayer.DataStructures;

namespace Version1.domainLayer.CompositeDP
{
    [Serializable]
    public class OrComposite : Composite,ISerializable
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

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Type","OR");
            info.AddValue("Policies",_children);
        }
    }
}
using System;
using System.Runtime.Serialization;
using Version1.domainLayer.DataStructures;

namespace Version1.domainLayer.CompositeDP
{
    [Serializable]
    public class AndComposite : Composite,ISerializable
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

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Type","AND");
            info.AddValue("Policies",_children);
        }


    }
}
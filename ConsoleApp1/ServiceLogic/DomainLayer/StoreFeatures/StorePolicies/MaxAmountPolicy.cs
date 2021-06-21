using System;
using System.Runtime.Serialization;
using ServiceLogic.DataAccessLayer.DataStructures;
using ServiceLogic.DomainLayer.StoreFeatures.StorePolicies.CompositeDP;

namespace ServiceLogic.DomainLayer.StoreFeatures.StorePolicies
{
    [Serializable]
    public class MaxAmountPolicy : Component,ISerializable
    {
        private readonly int maxAmount;
        private readonly string barcode;

        public MaxAmountPolicy(string barcode, int maxAmount)
        {
            this.barcode = barcode;
            this.maxAmount = maxAmount;
        }
        
        public override bool Validate(ShoppingBasket shoppingBasket)
        {
            foreach (var productSet in shoppingBasket.Products)
            {
                if(productSet.Key.Equals(barcode) && productSet.Value > maxAmount)
                    return false;
            }

            return true;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Type","Max Amount");
            info.AddValue("MaxAmount",maxAmount);
            info.AddValue("Barcode",barcode);
        }
    }
}
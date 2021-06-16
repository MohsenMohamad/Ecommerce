using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Version1.domainLayer.CompositeDP;
using Version1.domainLayer.DataStructures;

namespace Version1.domainLayer.StorePolicies
{
    [Serializable]
    public class CustomerTypeRestriction : Component,ISerializable
    {
        private readonly List<string> ageRestrictedProducts;

        public CustomerTypeRestriction()
        {
            ageRestrictedProducts = new List<string>();
        }
        
        public override bool Validate(ShoppingBasket shoppingBasket)
        {
            foreach (var productSet in shoppingBasket.Products)
            {
                if(ageRestrictedProducts.Contains(productSet.Key)) // && is a user
                    return false;
            }

            return true;
        }

        public void AddRestrictedProduct(string barcode)
        {
            ageRestrictedProducts.Add(barcode);
        }

        public void AddRestrictedProducts(IEnumerable<string> productsBarcodes)
        {
            ageRestrictedProducts.AddRange(productsBarcodes);
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Type","CustomerType");
            info.AddValue("Products",ageRestrictedProducts);
        }
    }
}
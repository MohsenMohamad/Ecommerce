using System.Collections.Generic;
using Version1.domainLayer.CompositeDP;
using Version1.domainLayer.DataStructures;

namespace Version1.domainLayer.StorePolicies
{
    public class CustomerTypeRestriction : Component
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
    }
}
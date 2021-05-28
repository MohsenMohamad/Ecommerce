using System.Collections.Generic;
using Version1.domainLayer.CompositeDP;
using Version1.domainLayer.DataStructures;

namespace Version1.domainLayer.StorePolicies
{
    public class CustomerAgeRestriction : Component
    {
        private readonly int minimumAge;
        private readonly List<string> ageRestrictedProducts;

        public CustomerAgeRestriction(int minimumAge)
        {
            this.minimumAge = minimumAge;
            ageRestrictedProducts = new List<string>();
        }
        
        public override bool Validate(ShoppingBasket shoppingBasket)
        {
            foreach (var productSet in shoppingBasket.Products)
            {
                if(ageRestrictedProducts.Contains(productSet.Key) && false) // && user age < min
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
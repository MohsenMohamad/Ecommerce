using System;
using System.Collections.Generic;
using System.Linq;
using Version1.DataAccessLayer;
using Version1.domainLayer.CompositeDP;
using Version1.domainLayer.DataStructures;

namespace Version1.domainLayer.StorePolicies
{
    public class TimeRestrictedCategories : Component
    {

        private readonly List<string> restrictedCategories;
        private readonly TimeSpan restrictionTime;

        public TimeRestrictedCategories(int hour, int minute)
        {
            restrictionTime = new TimeSpan(hour, minute, 0);
            restrictedCategories = new List<string>();
        }
        
        public override bool Validate(ShoppingBasket shoppingBasket)
        {
            foreach (var productSet in shoppingBasket.Products)
            {
                var productCategories = DataHandler.Instance.GetProduct(productSet.Key, shoppingBasket.StoreName).Categories;
                var inARestrictedCategory = productCategories.Intersect(restrictedCategories).Any();
                if(inARestrictedCategory && TooLate())
                    return false;
            }

            return true;
        }

        private bool TooLate()
        {
            var currentTime = DateTime.Now.TimeOfDay;
            return currentTime < restrictionTime;
        }

        public void AddRestrictedCategory(string category)
        {
            restrictedCategories.Add(category);
        }

        public void AddRestrictedCategories(IEnumerable<string> categories)
        {
            restrictedCategories.AddRange(categories);
        }
    }
}
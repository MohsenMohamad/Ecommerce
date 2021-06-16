using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Version1.DataAccessLayer;
using Version1.domainLayer.CompositeDP;
using Version1.domainLayer.DataStructures;

namespace Version1.domainLayer.StorePolicies
{
    [Serializable]
    public class TimeRestrictedCategories : Component,ISerializable
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

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Type","Time");
            info.AddValue("Hour",restrictionTime.Hours);
            info.AddValue("Minute",restrictionTime.Minutes);
            info.AddValue("Categories",restrictedCategories);
        }
    }
}
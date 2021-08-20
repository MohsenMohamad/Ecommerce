using ServiceLogic.DataAccessLayer.DataStructures;

namespace ServiceLogic.DomainLayer.StoreFeatures.DiscountPolicies
{
    public class Item_Category : Condition
    {
        private readonly string Category;

        public Item_Category(string cat)
        {
            Category = cat;
        }

        public override bool evaluate(ShoppingCart cart, User user, Product item, int amount_of_item)
        {
            var str = item.Categories[0];
            var output = str.Contains(Category);
            return output;
        }

        public override string get_description()
        {
            return $"item from category: ({Category})";
        }
    }
}
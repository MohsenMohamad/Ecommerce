using Version1.domainLayer.DataStructures;

namespace Version1.domainLayer.DiscountPolicies
{
    public class Item_Category : Condition
    {
        private string Category;
        public Item_Category(string cat)
        {
            Category = cat;
        }
        public override bool evaluate(ShoppingCart cart, User user, Product item, int amount_of_item)
        {
            return item.Categories.Contains(Category);
        }

        public override string get_description()
        {
            return string.Format("item from category ({0})", Category);
        }
    }
}
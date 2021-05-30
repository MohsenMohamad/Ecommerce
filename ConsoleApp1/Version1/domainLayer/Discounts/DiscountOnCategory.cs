using Version1.domainLayer.DataStructures;

namespace Version1.domainLayer.Discounts
{
    public class DiscountOnCategory : Discount
    {

        private readonly string category;
        
        public DiscountOnCategory(float dis, string category) : base(dis)
        {
            this.category = category;
        }

        public override double NewPrice(ShoppingBasket shoppingBasket)
        {
            throw new System.NotImplementedException();
        }
    }
}
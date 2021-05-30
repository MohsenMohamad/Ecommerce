using Version1.domainLayer.DataStructures;

namespace Version1.domainLayer.Discounts
{
    public class DiscountOnStore : Discount
    {
        public DiscountOnStore(float dis) : base(dis)
        {
        }

        public override double NewPrice(ShoppingBasket shoppingBasket)
        {
            throw new System.NotImplementedException();
        }
    }
}
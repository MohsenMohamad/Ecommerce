using Version1.domainLayer.DataStructures;

namespace Version1.domainLayer.Discounts
{
    public class DiscountOnProduct : Discount
    {
        private readonly string productBarcode;
        
        public DiscountOnProduct(float dis, string productBarcode) : base(dis)
        {
            this.productBarcode = productBarcode;
        }

        public override double NewPrice(ShoppingBasket shoppingBasket)
        {
            throw new System.NotImplementedException();
        }
    }
}
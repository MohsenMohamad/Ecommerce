
namespace Version1.domainLayer
{
    public abstract class Person
    {
        internal ShoppingCart shoppingCart { get; set; }

        public void SetShoppingCart(ShoppingCart cart)
        {
            shoppingCart = cart;
        }

        public ShoppingCart GetShoppingCart()
        {
            return shoppingCart;
        }
        
    }
}
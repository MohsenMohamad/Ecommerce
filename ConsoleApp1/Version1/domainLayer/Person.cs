
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
        
        public bool AddItemToBasket(string storeName, Product product, int amount)
        {
            return shoppingCart.AddProductToBasket(storeName, product, amount);
        }
        
        
        public string GetBasketInfo()
        {
            var output = "--------------------------";

            foreach (var shoppingBasket in shoppingCart.shoppingBaskets.Values)
            {
                output+= shoppingBasket.ToString()+"/n---------------------/n";
            }
            return output;
        }
    }
}
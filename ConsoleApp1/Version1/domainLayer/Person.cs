
namespace Version1.domainLayer
{
    public abstract class Person
    {
        internal ShoppingCart shoppingCart { get; set; }

        public void SetShoppingCart(ShoppingCart cart)
        {
            shoppingCart = cart;
        }
        
        public bool AddItemToBasket(string storeName, Product product, int amount)
        {
            return shoppingCart.AddProductToBasket(storeName, product, amount);
        }
        
        public bool RemoveItemFromBasket(string storeName, Product product)
        {
            return shoppingCart.RemoveProductFromBasket(storeName, product);
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
namespace Version1.domainLayer.StorePolicies
{
    public interface IPurchasePolicy
    {
        bool IsValid(ShoppingBasket shoppingBasket);
    }
}
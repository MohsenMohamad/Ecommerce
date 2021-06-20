using ServiceLogic.DataAccessLayer.DataStructures;

namespace ServiceLogic.DomainLayer.StoreFeatures.StorePolicies
{
    public interface IPurchasePolicy
    {
        bool Validate(ShoppingBasket shoppingBasket);
    }
}
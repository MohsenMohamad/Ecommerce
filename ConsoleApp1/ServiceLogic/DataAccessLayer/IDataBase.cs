using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLogic.DataAccessLayer.DataStructures;
using ServiceLogic.DomainLayer.StoreFeatures.DiscountPolicies;

namespace ServiceLogic.DataAccessLayer
{
    public interface IDataBase
    {
        bool InsertUser(User u);
        bool InsertDTO_PoliciesDB(DtoPolicy dp);
        bool deleteBasket(string userName, string storeName);
        
        bool UpdateUser(User u);
        bool DeleteUser(string userName);


        void updateNotification(string userName, List<string> list);
        void updateNotificationsoffer(string userName, List<string> list);
        void UpdateProductDiscountDiscreption(string barcode, string discount_description);
        void updateStoreStaff(string storeName, Node<string, int> node);
        bool InsertStore(Store s);
        bool DeleteStore(Store store);
        bool UpdateStore(Store s);
        bool AddDiscountToStore(string storeName, DtoPolicy dp);
        bool InsertPurchaseToUser(string userName, Purchase p);
        bool InsertPurchaseToStore(string storeName, Purchase p);
        bool UpdatePurchase(Purchase p);
        bool DeletePurchase(long pid);
        bool InsertShoppingCart(ShoppingCart sh);
        bool InsertShoppingBasket(ShoppingBasket pr);
        bool UpdateShoppingBasket(ShoppingBasket sh);
        bool InsertProduct(Product p);
        bool InsertProductToStore(string storeName, Product p, int amount);
        bool UpdateProductPolicy(Product p);
        bool InsertReview(Review r);
        bool InsertCategory(Category c);
        bool InsertNode(Node<string, int> n, string storeName);
        bool UpdateNode(Node<string, int> n, string storeName);
        bool AddProductToBasket(string userName, string storeName, string productCode, int amount, double priceofone);
        bool UpdateCartProductAmountInBasket(string userName, string storeName, string productBarcode, int newAmount);
        bool RemoveProductFromCart(string userName, string storeName, string productBarcode, int amount);
        bool TakeFromStoreInventory(string StoreName, string productBarcode, int amount);
        bool makePurchaseTransaction(ShoppingBasket basket, string userName);
        bool UpdateUserPassword(string userName, string newPassword);
        bool DeleteStore(string storeName);



    }
}

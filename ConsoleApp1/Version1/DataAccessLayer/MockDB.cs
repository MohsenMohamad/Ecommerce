using System.Collections.Generic;
using Version1.domainLayer.DataStructures;
using Version1.domainLayer.DiscountPolicies;

namespace Version1.DataAccessLayer
{
    public class MockDB : IDataBase
    {
        public bool AddDiscountToStore(string storeName, DtoPolicy dp)
        {
            return true;
        }

        public bool AddProductToBasket(string userName, string storeName, string productCode, int amount,
            double priceofone)
        {
            return true;
        }

        public bool deleteBasket(string userName, string storeName)
        {
            return true;
        }

        public bool DeletePurchase(long pid)
        {
            return true;
        }

        public bool DeleteStore(Store store)
        {
            return true;
        }

        public bool DeleteUser(string userName)
        {
            return true;
        }

        public bool InsertCategory(Category c)
        {
            return true;
        }

        public bool InsertDTO_PoliciesDB(DtoPolicy dp)
        {
            return true;
        }

        public bool InsertNode(Node<string, int> n, string storeName)
        {
            return true;
        }

        public bool InsertProduct(Product p)
        {
            return true;
        }

        public bool InsertProductToStore(string storeName, Product p, int amount)
        {
            return true;
        }

        public bool InsertPurchaseToStore(string storeName, Purchase p)
        {
            return true;
        }

        public bool InsertPurchaseToUser(string userName, Purchase p)
        {
            return true;
        }

        public bool InsertReview(Review r)
        {
            return true;
        }

        public bool InsertShoppingBasket(ShoppingBasket pr)
        {
            return true;
        }

        public bool InsertShoppingCart(ShoppingCart sh)
        {
            return true;
        }

        public bool InsertStore(Store s)
        {
            return true;
        }

        public bool InsertUser(User u)
        {
            return true;
        }

        public bool makePurchaseTransaction(ShoppingBasket basket, string userName)
        {
            return true;
        }

        public bool UpdateUserPassword(string userName, string newPassword)
        {
            return true;
        }

        public bool DeleteStore(string storeName)
        {
            return true;
        }

        public bool RemoveProductFromCart(string userName, string storeName, string productBarcode, int amount)
        {
            return true;
        }

        public bool TakeFromStoreInventory(string StoreName, string productBarcode, int amount)
        {
            return true;
        }

        public bool UpdateCartProductAmountInBasket(string userName, string storeName, string productBarcode,
            int newAmount)
        {
            return true;
        }

        public bool UpdateNode(Node<string, int> n, string storeName)
        {
            return true;
        }

        public void updateNotification(string userName, List<string> list)
        {
            return;
        }

        public void updateNotificationsoffer(string userName, List<string> list)
        {
            return;
        }

        public void UpdateProductDiscountDiscreption(string barcode, string discount_description)
        {
            return;
        }

        public bool UpdateProductPolicy(Product p)
        {
            return true;
        }

        public bool UpdatePurchase(Purchase p)
        {
            return true;
        }

        public bool UpdateShoppingBasket(ShoppingBasket sh)
        {
            return true;
        }

        public bool UpdateStore(Store s)
        {
            return true;
        }

        public void updateStoreStaff(string storeName, Node<string, int> node)
        {
            return;
        }

        public bool UpdateUser(User u)
        {
            return true;
        }
    }
}
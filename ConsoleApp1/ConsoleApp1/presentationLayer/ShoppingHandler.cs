using System;
using ConsoleApp1.DataAccessLayer;
using ConsoleApp1.domainLayer;
using ConsoleApp1.domainLayer.Business_Layer;

namespace ConsoleApp1.presentationLayer
{
    public class ShoppingHandler
    {
        private DataHandler data;
        public Purchase purchase;

        public ShoppingHandler()
        {
            data = DataHandler.Instance;
            purchase = new Purchase();
            
        }

        private Store GetStore(string name)
        {
            return data.GetStore(name);
        }

        public bool BuyProduct(string barcode, int amount, string storeName)
        {
            var pr = GetProduct(barcode);
            var st = GetStore(storeName);
            if (pr != null && st != null && st.Checkinventory(pr) >= amount)
            {
                purchase.addProduct(pr, amount);
                st.RemoveProduct(pr, amount);
                return true;
            }

            return false;
        }

        public bool RemoveProduct(string barcode, int amount, string storeName)
        {
            Product pr = GetProduct(barcode);
            Store st = GetStore(storeName);
            if (pr != null && st != null)
            {
                purchase.removeProduct(pr, amount);
                st.addProduct(pr, amount);
                return true;
            }

            return false;
        }

        public bool contactPaymentCompany()
        {
            return true;
        }

        public bool contactDeliveryCompany()
        {
            return true;
        }

        public Purchase checkout()
        {
            purchase.date = DateTime.Now;
            int purchaseType = getPurchaseType();
            if (checkAgreement(purchaseType))
            {
                contactPaymentCompany();
                contactDeliveryCompany();
                return purchase;
            }

            return null;
        }

        private int getPurchaseType()
        {
            throw new NotImplementedException();
        }

        private bool checkAgreement(int option)
        {
            if (option == 1)
            {
                return instantPurchase(purchase);
            }
            else if (option == 2)
            {
                return suggestedPurchase(purchase);
            }
            else if (option == 3)
            {
                return bidingPurchase(purchase);
            }
            else if (option == 4)
            {
                return RandomPurchase(purchase);
            }
            else
            {
                return false;
            }
        }

        private bool RandomPurchase(Purchase purchase)
        {
            throw new NotImplementedException();
        }

        private bool bidingPurchase(Purchase purchase)
        {
            throw new NotImplementedException();
        }

        private bool suggestedPurchase(Purchase purchase)
        {
            throw new NotImplementedException();
        }

        private bool instantPurchase(Purchase purchase)
        {
            throw new NotImplementedException();
        }

        private Product GetProduct(string barcode)
        {
            return data.GetProduct(barcode);
        }
    }
}
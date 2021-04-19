using ConsoleApp1.domainLayer.Business_Layer;
using ConsoleApp1.domainLayer.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.domainLayer.DataAccessLayer
{
    public class ShoppingHandler
    {
        public UserDao user;
        private DataHandler data;
        public Business_Layer.Purchase purchase;
        public ShoppingHandler(string username) {
            data = DataHandler.Instance;
            purchase = new Business_Layer.Purchase();
            Business_Layer.User us = data.getUser(username);
            if(us!=null)
            user = new UserDao(username, us.Password);
        }
        private Business_Layer.Store getStore(string name)
        {
            for (int i = 0; i < data.Stores.Count; i++)
            {
                if (data.Stores[i].Name.CompareTo(name) == 0)
                    return data.Stores[i];

            }
            return null;
        }
        public bool buyProduct(string  barcode,int amount,string store_name)
        {
            Business_Layer.Product pr = getProduct(barcode);
            Business_Layer.Store st = getStore(store_name);
            if (pr != null&&st!=null&&st.Checkinventory(pr)>=amount)
            {
                this.purchase.addProduct(pr, amount);
                st.RemoveProduct(pr, amount);

                return true;
            }
            
            return false;
        }

        public bool removeProduct(string barcode, int amount, string store_name)
        {
            Business_Layer.Product pr = getProduct(barcode);
            Business_Layer.Store st = getStore(store_name);
            if (pr != null && st != null)
            {
                this.purchase.removeProduct(pr, amount);
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

        public Business_Layer.Purchase checkout()
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

        private Business_Layer.Product getProduct(string barcode)
        {
            for (int i = 0; i < data.Products.Count; i++)
            {
                if (data.Products[i].Barcode.CompareTo(barcode) == 0)
                    return data.Products[i];

            }
            return null;
        }
    }
}

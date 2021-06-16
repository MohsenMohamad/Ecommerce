using System;
using System.Collections.Generic;
using System.Linq;
using Version1.DataAccessLayer;
using Version1.domainLayer.DataStructures;
using Version1.ExternalServices;


namespace Version1.LogicLayer
{
    public static class CartLogic
    {
        public static bool Purchase(string userName, PaymentInfo paymentInfo, SupplyAddress supplyAddress)
        {
            lock (DataHandler.Instance.InefficientLock)
            {
                var user = DataHandler.Instance.GetUser(userName);

                if (user == null || user.shoppingCart.shoppingBaskets.Values.Count == 0)
                {
                    return false;
                }

                foreach (var basket in user.shoppingCart.shoppingBaskets.Values.ToList())
                {
                    var storeResult = PurchaseFromStore(userName, basket, paymentInfo, supplyAddress);
                    if (!storeResult) return false;
                }
                
                return true;
            }
        }

        public static bool AddProductToBasket(string userName, string storeName, string productCode, int amount,
            double priceofone)
        {
            lock (DataHandler.Instance.InefficientLock)
            {
                var user = DataHandler.Instance.GetUser(userName);
                var store = DataHandler.Instance.GetStore(storeName);
                var product = DataHandler.Instance.GetProduct(productCode, storeName);

                if (user == null || store == null || product == null || amount < 0)
                    return false;

                var userCart = user.GetShoppingCart();
                if (!userCart.shoppingBaskets.ContainsKey(storeName))
                    userCart.shoppingBaskets.Add(storeName, new ShoppingBasket(storeName));

                var storeProducts = DataHandler.Instance.GetStore(storeName).GetInventory();

                var userStoreBasket = userCart.GetBasket(storeName);

                if (storeProducts.ContainsKey(product) && storeProducts[product] >= amount)
                {
                    double totalprice = amount * priceofone;
                    if (userStoreBasket.Products.ContainsKey(product.Barcode))
                    {
                        userStoreBasket.Products[product.Barcode] += amount;
                        userStoreBasket.priceperproduct[product.Barcode] += totalprice;
                        return DataHandler.Instance.db.AddProductToBasket(userName, storeName, productCode,
                            userStoreBasket.Products[product.Barcode],
                            userStoreBasket.priceperproduct[product.Barcode]);
                    }
                    else
                    {
                        userStoreBasket.Products.Add(product.Barcode, amount);
                        userStoreBasket.priceperproduct.Add(product.Barcode, totalprice);
                        return DataHandler.Instance.db
                            .AddProductToBasket(userName, storeName, productCode, amount, priceofone);
                    }
                }

                return false;
            }
        }

        public static bool RemoveProductFromBasket(string userName, string storeName, string productBarcode, int amount)
        {
            
            lock (DataHandler.Instance.InefficientLock)
            {
                var user = DataHandler.Instance.GetUser(userName);
                var store = DataHandler.Instance.GetStore(storeName);
                var product = DataHandler.Instance.GetProduct(productBarcode, storeName);

                if (user == null || store == null || product == null)
                    return false;

                var cart = user.GetShoppingCart();
                if (!cart.shoppingBaskets.ContainsKey(storeName))
                    return false;

                var storeBasketProducts = cart.shoppingBaskets[storeName].Products;

                if (!storeBasketProducts.ContainsKey(productBarcode) || storeBasketProducts[productBarcode] < amount)
                    return false;
                storeBasketProducts[productBarcode] -= amount;
                cart.shoppingBaskets[storeName].priceperproduct[productBarcode] = 0;

                if (storeBasketProducts[productBarcode] == 0)
                {
                    storeBasketProducts.Remove(productBarcode);
                    cart.shoppingBaskets[storeName].priceperproduct.Remove(productBarcode);
                    //to transact
                    return DataHandler.Instance.db.RemoveProductFromCart(userName, storeName, productBarcode, amount);
                }

                return true;
            }
        }

        public static bool UpdateCart(string userName, string storeName, string productBarcode, int newAmount)
        {
            lock (DataHandler.Instance.InefficientLock)
            {
                var user = DataHandler.Instance.GetUser(userName);
                var store = DataHandler.Instance.GetStore(storeName);
                var product = DataHandler.Instance.GetProduct(productBarcode, storeName);

                if (user == null || store == null || product == null || newAmount < 0) return false;

                var shoppingBasket = user.GetShoppingCart().GetBasket(storeName);
                if (shoppingBasket == null || !shoppingBasket.Products.ContainsKey(productBarcode)) return false;
                shoppingBasket.priceperproduct[productBarcode] +=
                    (newAmount - shoppingBasket.Products[productBarcode]) * product.price;
                if (shoppingBasket.priceperproduct[productBarcode] < 0)
                {
                    shoppingBasket.priceperproduct[productBarcode] = 0;
                    shoppingBasket.Products[productBarcode] = 0;
                    RemoveProductFromBasket(userName, storeName, productBarcode,
                        shoppingBasket.Products[productBarcode]);
                }
                else
                {
                    shoppingBasket.Products[productBarcode] = newAmount;
                }

                return DataHandler.Instance.db
                    .UpdateCartProductAmountInBasket(userName, storeName, productBarcode, newAmount);
            }
        }


        public static bool RemoveProductFromBasket(string userName, string storeName, string productBarcode)
        {
            lock (DataHandler.Instance.InefficientLock)
            {
                var user = DataHandler.Instance.GetUser(userName);
                var store = DataHandler.Instance.GetStore(storeName);
                var product = DataHandler.Instance.GetProduct(productBarcode, storeName);

                if (user == null || store == null || product == null)
                    return false;
                var cart = user.GetShoppingCart();

                if (!cart.shoppingBaskets.ContainsKey(storeName))
                    return false;
                var result = cart.shoppingBaskets[storeName].Products.Remove(productBarcode);
                return result;
            }
        }


        public static List<string> GetBasketProducts(string userName, string storeName)
        {
            lock (DataHandler.Instance.InefficientLock)
            {
                var userBaskets = DataHandler.Instance.GetUser(userName).shoppingCart.shoppingBaskets;
                if (userBaskets.ContainsKey(storeName))
                    return userBaskets[storeName].Products.Keys.ToList();
                return null;
            }
        }

        public static List<string> GetUserBaskets(string userName)
        {
            lock (DataHandler.Instance.InefficientLock)
            {
                var user = DataHandler.Instance.GetUser(userName);
                if (user == null)
                    return null;
                var products = new List<string>();

                foreach (var store in user.GetShoppingCart().shoppingBaskets.Keys)
                {
                    var basketProducts = GetBasketProducts(userName, store);
                    products.AddRange(basketProducts);
                }

                return products;
            }
        }

        public static double GetCartPrice(string userName)
        {
            lock (DataHandler.Instance.InefficientLock)
            {
                var user = DataHandler.Instance.GetUser(userName);
                if (user == null) return -1;

                var cart = user.GetShoppingCart();
                double total = 0;
                foreach (var basket in cart.shoppingBaskets.Values)
                {
                    var basketPrice = GetBasketPrice(userName, basket.StoreName);
                    if (basketPrice < 0) return -1;

                    total += GetBasketPrice(userName, basket.StoreName);
                }

                return total;
            }
        }

        private static bool PurchaseFromStore(string userName, ShoppingBasket basket, PaymentInfo paymentInfo,
            SupplyAddress supplyAddress)
        {
            lock (DataHandler.Instance.InefficientLock)
            {
                if (!ValidateBasketPolicies(userName, basket.StoreName)) throw new Exception("");

                var price = GetBasketPrice(userName, basket.StoreName);
                var store = DataHandler.Instance.GetStore(basket.StoreName);
                var user = DataHandler.Instance.GetUser(userName);


                var supplyService = new SupplyService();
                var financeService = new FinanceService();

                var transactionId = financeService.Pay(paymentInfo.CardNumber, paymentInfo.ExpMonth,
                    paymentInfo.ExpYear,
                    paymentInfo.CardHolder, paymentInfo.CardCcv, paymentInfo.HolderId);

                if (transactionId < 0) throw new Exception("");


                var shipmentId = supplyService.Supply(supplyAddress.NameF, supplyAddress.AddressF, supplyAddress.CityF,
                    supplyAddress.CountryF, supplyAddress.ZipF);

                if (shipmentId < 0)
                {
                    financeService.CancelPay(transactionId);
                    throw new Exception("");
                }

                //make transaction
                if (DataHandler.Instance.db.makePurchaseTransaction(basket, userName))
                {
                    //1
                    // try to take from inventory
                    if (!InventoryLogic.TakeFromStoreInventory(basket))
                    {
                        financeService.CancelPay(transactionId);
                        supplyService.CancelSupply(shipmentId);
                        throw new Exception("");
                    }


                    //add to user & store history
                    var purchase = new Purchase
                    {
                        user = userName,
                        date = DateTime.Now,
                        store = basket.StoreName,
                        purchaseType = domainLayer.DataStructures.Purchase.PurchaseType.DirectPurchase,
                        purchaseId = transactionId,
                        items = basket.Products.ToDictionary(
                            prod => DataHandler.Instance.GetProduct(prod.Key, basket.StoreName),
                            prod => prod.Value).ToList()
                    };

                    //2
                    // clear the basket
                    user.shoppingCart.shoppingBaskets.Remove(basket.StoreName);

                    store.GetHistory().Add(purchase);
                    //3
                    DataHandler.Instance.db.InsertPurchaseToStore(store.name, purchase);

                    if (DataHandler.Instance.IsGuest(userName) < 0)
                    {   //4
                        ((User)user).history.Add(purchase);
                        DataHandler.Instance.db.InsertPurchaseToUser(userName, purchase);
                    }

                    //send notifications
                    var owner = DataHandler.Instance.GetUser(store.GetOwner());
                    //5
                    ((User)owner).GetNotifications().Add("A purchase has been made at" + store.GetName());
                    DataHandler.Instance.db.updateNotification(userName, ((User)owner).GetNotifications());
                }
                else
                {
                    return false;
                }
                

            }

            return true;
        }

        public static double GetBasketPrice(string userName, string storeName)
        {
            lock (DataHandler.Instance.InefficientLock)
            {
                var user = DataHandler.Instance.GetUser(userName);
                var store = DataHandler.Instance.GetStore(storeName);
                if (user == null || store == null) return -1;

                var basket = user.GetShoppingCart().GetBasket(storeName);
                if (basket == null) return -1;

                double total = 0;
                foreach (var productPair in basket.Products)
                {
                    var product = DataHandler.Instance.GetProduct(productPair.Key, storeName);
                    if (product == null) return -1;

                    var productTotalCost = basket.priceperproduct[productPair.Key];
                    total += productTotalCost;
                }

                return total;
            }
        }

        public static bool ValidateBasketPolicies(string userName, string storeName)
        {
            var user = DataHandler.Instance.GetUser(userName);
            var store = DataHandler.Instance.GetStore(storeName);

            var basket = user.GetShoppingCart().GetBasket(storeName);

            foreach (var policy in store.GetPurchasePolicies())
            {
                if (!policy.Validate(basket))
                    return false;
            }

            return true;
        }


        public static string GetBasketInfo(string userName, string storeName)
        {
            var user = DataHandler.Instance.GetUser(userName);
            var store = DataHandler.Instance.GetStore(storeName);

            if (user == null || storeName == null)
                return null;

            var output = "--------------------------";

            foreach (var shoppingBasket in user.GetShoppingCart().shoppingBaskets.Values)
            {
                output += shoppingBasket.ToString() + "/n---------------------/n";
            }

            return output;
        }

        public static Dictionary<string, int> GetCartByStore(string userName, string storeName)
        {
            lock (DataHandler.Instance.InefficientLock)
            {
                var user = DataHandler.Instance.GetUser(userName);
                var store = DataHandler.Instance.GetStore(storeName);
                if (user == null || store == null || user.GetShoppingCart().GetBasket(storeName) == null)
                    return null;
                var basket = user.GetShoppingCart().GetBasket(storeName);
                return basket.Products;
            }
        }
    }
}
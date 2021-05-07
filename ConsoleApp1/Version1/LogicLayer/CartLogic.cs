using System.Collections.Generic;
using System.Linq;
using Version1.DataAccessLayer;
using Version1.domainLayer.DataStructures;
using Version1.ExternalServices;


namespace Version1.LogicLayer
{
    public static class CartLogic
    {
        public static bool AddProductToBasket(string userName, string storeName, string productCode, int amount)
        {
            lock (DataHandler.Instance.InefficientLock)
            {
                var user = DataHandler.Instance.GetUser(userName);
                var store = DataHandler.Instance.GetStore(storeName);
                var product = DataHandler.Instance.GetProduct(productCode);

                if (user == null || store == null || product == null)
                    return false;

                return user.GetShoppingCart().AddProductToBasket(storeName, productCode, amount);
            }
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

        public static bool Purchase(string userName, string creditCard)
        {
            lock (DataHandler.Instance.InefficientLock)
            {
                var user = DataHandler.Instance.GetUser(userName);

               if(user == null || user.shoppingCart.shoppingBaskets.Values.Count == 0)
               {
                    return false;
               }
                foreach (var basket in user.shoppingCart.shoppingBaskets.Values)
                {
                    var store = DataHandler.Instance.GetStore(basket.StoreName);
                    foreach (var productAndAmount in basket.Products)
                    {
                        var productBarcode = productAndAmount.Key;
                        var amount = productAndAmount.Value;
                        if (!store.GetInventory().ContainsKey(productBarcode) ||
                            store.GetInventory()[productBarcode] < amount)
                            return false;
                    }
                }

                var supply = ExternalSupplyService.CreateConnection();
                var finance = ExternalFinanceService.CreateConnection();

                if (supply == null || finance == null) return false;

                var cost = GetCartPrice(userName);

                if (cost < 0 || !supply.MakeOrder() || !finance.AcceptPurchase(cost, creditCard))
                    return false;

                foreach (var basket in user.shoppingCart.shoppingBaskets.Values)
                {
                    var store = DataHandler.Instance.GetStore(basket.StoreName);

                    foreach (var policy in store.GetPurchasePolicies())
                    {
                        if (!policy.Validate(basket))
                            return false;
                    }

                    foreach (var product in basket.Products.Keys.ToList())
                    {
                        var amount = basket.Products[product];

                        RemoveProductFromBasket(userName, store.GetName(), product);
                        store.GetInventory()[product] -= amount;
                    }

                    store.AddPurchase(new Purchase());
                }

                if (DataHandler.Instance.IsGuest(userName) < 0)
                {
                    ((User)user).history.Add(new Purchase());
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
                var product = DataHandler.Instance.GetProduct(productBarcode);

                if (user == null || store == null || product == null || newAmount < 0) return false;

                var shoppingBasket = user.GetShoppingCart().GetBasket(storeName);
                if (shoppingBasket == null || !shoppingBasket.Products.ContainsKey(productBarcode)) return false;
                shoppingBasket.Products[productBarcode] = newAmount;
                return true;
            }
        }

        public static bool RemoveProductFromBasket(string userName, string storeName, string productBarcode, int amount)
        {
            lock (DataHandler.Instance.InefficientLock)
            {
                var user = DataHandler.Instance.GetUser(userName);
                var store = DataHandler.Instance.GetStore(storeName);
                var product = DataHandler.Instance.GetProduct(productBarcode);

                if (user == null || store == null || product == null)
                    return false;

                var cart = user.GetShoppingCart();
                if (!cart.shoppingBaskets.ContainsKey(storeName))
                    return false;
                var result = cart.shoppingBaskets[storeName].RemoveProduct(productBarcode, amount);
                return result;
            }
        }

        public static bool RemoveProductFromBasket(string userName, string storeName, string productBarcode)
        {
            lock (DataHandler.Instance.InefficientLock)
            {
                var user = DataHandler.Instance.GetUser(userName);
                var store = DataHandler.Instance.GetStore(storeName);
                var product = DataHandler.Instance.GetProduct(productBarcode);

                if (user == null || store == null || product == null)
                    return false;
                var cart = user.GetShoppingCart();

                if (!cart.shoppingBaskets.ContainsKey(storeName))
                    return false;
                var result = cart.shoppingBaskets[storeName].RemoveProduct(productBarcode);
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
                    var product = DataHandler.Instance.GetProduct(productPair.Key);
                    if (product == null) return -1;

                    var productTotalCost = product.Price * productPair.Value;
                    total += productTotalCost;
                }

                return total;
            }
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
    }
}